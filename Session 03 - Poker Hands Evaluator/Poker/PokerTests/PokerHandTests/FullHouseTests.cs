using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class FullHouseTests
    {
        private static readonly Rank[] ExpectedFullHouseHighCards = { Rank.Ace, Rank.King };

        private readonly PokerHand strongFullHouse = 
            new PokerHand(Dealer.DealFullHouse(ExpectedFullHouseHighCards[0], ExpectedFullHouseHighCards[1]));        

        [Test]
        public void GetRankCategory_ReturnsFullHouse_WhenFullHouseExists()
        {
            Assert.AreEqual(RankCategory.FullHouse, strongFullHouse.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsTwoHighCards_WhenFullHouseExists()
        {
            List<Rank> highCards = strongFullHouse.GetHighCardsDescending();

            Assert.AreEqual(2, highCards.Count);
            Assert.AreEqual(ExpectedFullHouseHighCards[0], highCards[0]);
            Assert.AreEqual(ExpectedFullHouseHighCards[1], highCards[1]);
        }

        private readonly PokerHand weakFullHouse = new PokerHand(Dealer.DealFullHouse(Rank.King, Rank.Queen));

        [Test]
        public void StrongFullHouse_ComparedWith_WeakFullHouse_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongFullHouse.CompareWith(weakFullHouse));
        }

        [Test]
        public void WeakFullHouse_ComparedWith_StrongFullHouse_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, weakFullHouse.CompareWith(strongFullHouse));
        }

        private static readonly Dictionary<RankCategory, List<Card>> AllCategories = Dealer.DealAllCategories();

        private readonly PokerHand[] strongCases = 
        {            
            new PokerHand(AllCategories[RankCategory.FourOfAKind]),
            new PokerHand(AllCategories[RankCategory.StraightFlush]),
        };

        [Test]
        [TestCaseSource("strongCases")]
        public void FullHouse_ComparedWith_StrongCases_ReturnsWeak(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Weak, strongFullHouse.CompareWith(strongerPokerHand));
        }

        private readonly PokerHand[] weakCases = 
        {
            new PokerHand(AllCategories[RankCategory.HighCard]),
            new PokerHand(AllCategories[RankCategory.OnePair]),
            new PokerHand(AllCategories[RankCategory.TwoPairs]),
            new PokerHand(AllCategories[RankCategory.ThreeOfAKind]),
            new PokerHand(AllCategories[RankCategory.Straight]),
            new PokerHand(AllCategories[RankCategory.Flush])
        };

        [Test]
        [TestCaseSource("weakCases")]
        public void FullHouse_ComparedWith_WeakCases_ReturnsStrong(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Strong, strongFullHouse.CompareWith(strongerPokerHand));
        }
    }
}
