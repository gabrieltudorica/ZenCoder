using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class FourOfAKindTests
    {
        private static readonly Rank[] ExpectedFourOfAKindHighCards = { Rank.Ace, Rank.Two };

        private readonly PokerHand strongFourOfAKind = new PokerHand(
            Dealer.DealFourOfAKindOneHighCard(ExpectedFourOfAKindHighCards[0], ExpectedFourOfAKindHighCards[1]));              

        [Test]
        public void GetRankCategory_ReturnsFourOfAKind_WhenFourOfAKindExists()
        {
            Assert.AreEqual(RankCategory.FourOfAKind, strongFourOfAKind.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsTwoHighCards_WhenFourOfAKind()
        {
            List<Rank> highCards = strongFourOfAKind.GetHighCardsDescending();

            Assert.AreEqual(2, highCards.Count);
            Assert.AreEqual(ExpectedFourOfAKindHighCards[0], highCards[0]);
            Assert.AreEqual(ExpectedFourOfAKindHighCards[1], highCards[1]);
        }

        private readonly PokerHand weakFourOfAKind = new PokerHand(Dealer.DealFourOfAKindOneHighCard(Rank.King, Rank.Queen));

        [Test]
        public void StrongFourOfAKind_ComparedWith_WeakFourOfAKind_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongFourOfAKind.CompareWith(weakFourOfAKind));
        }

        [Test]
        public void WeakFourOfAKind_ComparedWith_StrongFourOfAKind_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, weakFourOfAKind.CompareWith(strongFourOfAKind));
        }

        private static readonly Dictionary<RankCategory, List<Card>> AllCategories = Dealer.DealAllCategories();

        private readonly PokerHand[] strongCases = 
        {            
            new PokerHand(AllCategories[RankCategory.StraightFlush]),
        };

        [Test]
        [TestCaseSource("strongCases")]
        public void FourOfAKind_ComparedWith_StrongCases_ReturnsWeak(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Weak, weakFourOfAKind.CompareWith(strongerPokerHand));
        }

        private readonly PokerHand[] weakCases = 
        {
            new PokerHand(AllCategories[RankCategory.HighCard]),
            new PokerHand(AllCategories[RankCategory.OnePair]),
            new PokerHand(AllCategories[RankCategory.TwoPairs]),
            new PokerHand(AllCategories[RankCategory.ThreeOfAKind]),
            new PokerHand(AllCategories[RankCategory.Straight]),
            new PokerHand(AllCategories[RankCategory.Flush]),
            new PokerHand(AllCategories[RankCategory.FullHouse])
        };

        [Test]
        [TestCaseSource("weakCases")]
        public void FourOfAKind_ComparedWith_WeakCases_ReturnsStrong(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Strong, weakFourOfAKind.CompareWith(strongerPokerHand));
        }
    }
}