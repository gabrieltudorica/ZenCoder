using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using Poker.Model;

namespace PokerTests
{
    [TestClass]
    public class PokerHandEvaluatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsException_WhenNumberOfCardsIsDifferentThanFive()
        {
            var cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Clubs)
            };

            new PokerHandEvaluator(cards);
        }

        [TestMethod]
        public void GetRank_ReturnsHighCard_WhenNoBetterRankExists()
        {
            var pokerHand = new PokerHandEvaluator(GetCardsForHighCardRankCategory());

            Assert.AreEqual(RankCategory.HighCard, pokerHand.GetRank());
        }

        [TestMethod]
        public void GetKeyCardsInDescendingValue_ReturnsHighestCard_WhenRankCategoryIsHighCard()
        {           
            var pokerHand = new PokerHandEvaluator(GetCardsForHighCardRankCategory());

            List<Card> keyCards = pokerHand.GetKeyCardInDescendingValue();

            Assert.AreEqual(1, keyCards.Count);
            Assert.AreEqual(Rank.Ace, keyCards[0].Rank);
            Assert.AreEqual(Suit.Diamnods, keyCards[0].Suit);
        }

        private static List<Card> GetCardsForHighCardRankCategory()
        {
            return new List<Card>
            {
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamnods),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts)
            };
        }
    }
}
