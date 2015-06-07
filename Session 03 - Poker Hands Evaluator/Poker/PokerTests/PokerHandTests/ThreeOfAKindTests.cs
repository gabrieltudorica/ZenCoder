using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class ThreeOfAKindTests
    {
        private const Rank ThreeOfAKindStrongPair = Rank.Ace;
        private static readonly Rank[] ExpectedThreeOfAKindHighCards = { Rank.Seven, Rank.Nine };
        
        private readonly PokerHand strongThreeOfAKind = new PokerHand(
            Dealer.DealThreeOfAKindTwoHighCards(ThreeOfAKindStrongPair, ExpectedThreeOfAKindHighCards));

        [Test]
        public void GetRankCategory_ReturnsThreeOfAKind_WhenThreeOfAKindExists()
        {
            Assert.AreEqual(RankCategory.ThreeOfAKind, strongThreeOfAKind.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsThreeHighCards_WhenThreeOfAKindExists()
        {
            Rank[] expectedHighCardsDescendingOrder = Dealer.GetCardRanksDescending(ExpectedThreeOfAKindHighCards);

            List<Rank> highCards = strongThreeOfAKind.GetHighCardsDescending();

            Assert.AreEqual(3, highCards.Count);
            Assert.AreEqual(ThreeOfAKindStrongPair, highCards[0]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[0], highCards[1]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[1], highCards[2]);
        }


        private readonly PokerHand weakThreeOfAKind = new PokerHand(
            Dealer.DealThreeOfAKindTwoHighCards(Rank.King, ExpectedThreeOfAKindHighCards));

        [Test]
        public void StrongThreeOfAKind_ComparedWith_WeakThreeOfAKind_ReturnsStrong()
        {          
            Assert.AreEqual(Strength.Strong, strongThreeOfAKind.CompareWith(weakThreeOfAKind));
        }

        [Test]
        public void WeakThreeOfAKind_ComparedWith_StrongThreeOfAKind_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, weakThreeOfAKind.CompareWith(strongThreeOfAKind));
        }
    }
}
