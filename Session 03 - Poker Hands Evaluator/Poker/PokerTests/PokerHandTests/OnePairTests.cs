using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class OnePairTests
    {
        private static readonly Rank[] WeakHighCards = { Rank.Four, Rank.Three, Rank.Five };
        
        private const Rank StrongPair = Rank.Ace;
        private readonly PokerHand strongPair =
            new PokerHand(Dealer.DealOnePairThreeHighCards(StrongPair, WeakHighCards));                               

        [Test]
        public void GetRankCategory_ReturnsOnePair_WhenOnePairExists()
        {
            Assert.AreEqual(RankCategory.OnePair, strongPair.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsListWithPairCardAndHighCardsInDescendingOrder_WhenOnePairExists()
        {
            Rank[] expectedHighCardsDescendingOrder = Dealer.GetCardRanksDescending(WeakHighCards);

            List<Rank> highCards = strongPair.GetHighCardsDescending();

            Assert.AreEqual(4, highCards.Count);
            Assert.AreEqual(StrongPair, highCards[0]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[0], highCards[1]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[1], highCards[2]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[2], highCards[3]);
        }

        private readonly PokerHand weakPair =
            new PokerHand(Dealer.DealOnePairThreeHighCards(Rank.Two, WeakHighCards));

        [Test]
        public void WeakPair_ComparedWith_StrongPair_ReturnsWeak()
        {           
            Assert.AreEqual(Strength.Weak, weakPair.CompareWith(strongPair));
        }

        private static readonly Rank[] StrongHighCards = { Rank.King, Rank.Three, Rank.Five };
        private readonly PokerHand pairWithStrongHighCards =
            new PokerHand(Dealer.DealOnePairThreeHighCards(StrongPair, StrongHighCards));

        [Test]
        public void APairWithWeakHighCards_ComparedWith_SamePairWithStrongerHighCards_ReturnsWeak()
        {            
            Assert.AreEqual(Strength.Weak, weakPair.CompareWith(pairWithStrongHighCards));
        }

        [Test]
        public void APairWithStrongHighCards_ComparedWith_SamePairWithWeakHighCards_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, pairWithStrongHighCards.CompareWith(weakPair));
        }

        [Test]
        public void APairWithSomeHighCards_ComparedWith_SamePairWithSameHighCards_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, weakPair.CompareWith(weakPair));
        }

        [Test]
        public void StrongPair_ComparedWith_WeakPair_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongPair.CompareWith(weakPair));
        }

        private static readonly Dictionary<RankCategory, List<Card>> AllCategories = Dealer.DealAllCategories();

        private readonly PokerHand[] strongCases = 
        {
            new PokerHand(AllCategories[RankCategory.TwoPairs]),
            new PokerHand(AllCategories[RankCategory.ThreeOfAKind]),
            new PokerHand(AllCategories[RankCategory.Straight]),
            new PokerHand(AllCategories[RankCategory.Flush]),
            new PokerHand(AllCategories[RankCategory.FullHouse]),
            new PokerHand(AllCategories[RankCategory.FourOfAKind]),
            new PokerHand(AllCategories[RankCategory.StraightFlush]),
        };

        [Test]
        [TestCaseSource("strongCases")]
        public void OnePair_ComparedWith_StrongCases_ReturnsWeak(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Weak, weakPair.CompareWith(strongerPokerHand));
        }

        private readonly PokerHand[] weakCases = 
        {
            new PokerHand(AllCategories[RankCategory.HighCard])            
        };

        [Test]
        [TestCaseSource("weakCases")]
        public void OnePair_ComparedWith_WeakCases_ReturnsStrong(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Strong, weakPair.CompareWith(strongerPokerHand));
        }
    }
}
