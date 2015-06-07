using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class HighCardTests
    {
        private static readonly List<Card> HighCardCards = Dealer.DealStrongHighCard();
        private readonly PokerHand strongHighCard = new PokerHand(HighCardCards);

        [Test]
        public void GetRankCategory_ReturnsHighCard()
        {
            Assert.AreEqual(RankCategory.HighCard, strongHighCard.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsHighCardsInDescendingOrder()
        {
            List<Rank> expectedHighCards = HighCardCards.OrderByDescending(x => x.Rank).Select(x => x.Rank).ToList();
            List<Rank> highCards = strongHighCard.GetHighCardsDescending();

            Assert.AreEqual(expectedHighCards[0], highCards[0]);
            Assert.AreEqual(expectedHighCards[1], highCards[1]);
            Assert.AreEqual(expectedHighCards[2], highCards[2]);
            Assert.AreEqual(expectedHighCards[3], highCards[3]);
            Assert.AreEqual(expectedHighCards[4], highCards[4]);
        }
        
        private readonly PokerHand weakHighCard = new PokerHand(Dealer.DealWeakHighCard());        
        
        [Test]
        public void StrongHighCard_ComparedWith_WeakHighCard_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongHighCard.CompareWith(weakHighCard));
        }

        [Test]
        public void WeakHighCard_ComparedWithStrongHighCard_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, weakHighCard.CompareWith(strongHighCard));
        }

        [Test]
        public void AHighCard_ComparedWith_SameHighCard_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, strongHighCard.CompareWith(strongHighCard));
        }

        private static readonly Dictionary<RankCategory, List<Card>> AllCategories = Dealer.DealAllCategories();

        private readonly PokerHand[] strongCases = 
        {
            new PokerHand(AllCategories[RankCategory.OnePair]),
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
        public void HighCard_ComparedWith_StrongCases_ReturnsWeak(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Weak, weakHighCard.CompareWith(strongerPokerHand));
        }
    }
}
