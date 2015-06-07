using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class TwoPairsTests
    {
        private const Rank PairOne = Rank.Ace;
        private const Rank PairTwo = Rank.Queen;
        private const Rank WeakHighCard = Rank.Two;

        private static readonly List<Card> CardsForTwoPairsWeakHighCard = 
            Dealer.DealTwoPairsOneHighCard(PairOne,PairTwo, WeakHighCard);
        private readonly PokerHand twoPairsWeakHighCard = new PokerHand(CardsForTwoPairsWeakHighCard);               

        [Test]
        public void GetRankCategory_ReturnsTwoPairs_WhenTwoPairsExist()
        {
            Assert.AreEqual(RankCategory.TwoPairs, twoPairsWeakHighCard.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsOneHighCard_WhenTwoPairsExist()
        {
            List<Rank> highCards = twoPairsWeakHighCard.GetHighCardsDescending();

            Assert.AreEqual(3, highCards.Count);
            Assert.AreEqual(PairOne, highCards[0]);
            Assert.AreEqual(PairTwo, highCards[1]);
            Assert.AreEqual(WeakHighCard, highCards[2]);
        }

        [Test]
        public void TwoPairsWithOneHighCard_ComparedWith_SamePairsWithSameHighCard_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, twoPairsWeakHighCard.CompareWith(twoPairsWeakHighCard));
        }

        private static readonly List<Card> CardsForTwoPairsStrongHighCard =
            Dealer.DealTwoPairsOneHighCard(PairOne, PairTwo, Rank.King);
        private readonly PokerHand twoPairsStrongHighCard = new PokerHand(CardsForTwoPairsStrongHighCard);

        [Test]
        public void TwoPairsWithWeakHighCard_ComparedWith_SamePairsWithStrongHighCard_ReturnsWeak()
        {            
            Assert.AreEqual(Strength.Weak, twoPairsWeakHighCard.CompareWith(twoPairsStrongHighCard));
        }

        [Test]
        public void TwoPairsWithStrongHighCard_ComparedWith_SamePairsWithWeakHighCard_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, twoPairsStrongHighCard.CompareWith(twoPairsWeakHighCard));
        }

        private static readonly PokerHand[] WeakCases = 
        {
            new PokerHand(Dealer.DealTwoPairsOneHighCard(Rank.King, Rank.Jack, Rank.Nine)),
            new PokerHand(Dealer.DealTwoPairsOneHighCard(Rank.Ten, Rank.Nine, Rank.Eight))
        };

        [Test]
        [TestCaseSource("WeakCases")]
        public void TwoStrongPairs_ComparedWith_TwoWeakPairs_ReturnsStrong(PokerHand weakPairs)
        {
            Assert.AreEqual(Strength.Strong, twoPairsStrongHighCard.CompareWith(weakPairs));
        }

        private readonly PokerHand[] strongPairsCases = 
        {
            new PokerHand(Dealer.DealTwoPairsOneHighCard(Rank.King, Rank.Jack, Rank.Nine)),
            new PokerHand(Dealer.DealTwoPairsOneHighCard(Rank.Ace, Rank.King, Rank.Nine))
        };

        [Test]
        [TestCaseSource("strongPairsCases")]
        public void TwoWeakPairs_ComparedWith_TwoStrongPairs_ReturnsWeak(PokerHand strongPairs)
        {
            Assert.AreEqual(Strength.Weak, WeakCases[1].CompareWith(strongPairs));
        }

        private static readonly Dictionary<RankCategory, List<Card>> AllCategories = Dealer.DealAllCategories();

        private readonly PokerHand[] strongCases = 
        {            
            new PokerHand(AllCategories[RankCategory.ThreeOfAKind]),
            new PokerHand(AllCategories[RankCategory.Straight]),
            new PokerHand(AllCategories[RankCategory.Flush]),
            new PokerHand(AllCategories[RankCategory.FullHouse]),
            new PokerHand(AllCategories[RankCategory.FourOfAKind]),
            new PokerHand(AllCategories[RankCategory.StraightFlush]),
        };

        [Test]
        [TestCaseSource("strongCases")]
        public void TwoPairs_ComparedWith_StrongCases_ReturnsWeak(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Weak, twoPairsWeakHighCard.CompareWith(strongerPokerHand));
        }

        private readonly PokerHand[] weakCases = 
        {
            new PokerHand(AllCategories[RankCategory.HighCard]),
            new PokerHand(AllCategories[RankCategory.OnePair])
        };

        [Test]
        [TestCaseSource("weakCases")]
        public void TwoPairs_ComparedWith_WeakCases_ReturnsStrong(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Strong, twoPairsWeakHighCard.CompareWith(strongerPokerHand));
        }
    }
}
