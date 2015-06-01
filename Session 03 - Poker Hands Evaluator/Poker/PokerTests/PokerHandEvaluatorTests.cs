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
        public void GetRankCategory_ReturnsHighCard()
        {
            var pokerHand = new PokerHandEvaluator(Dealer.GetCardsForHighCardRankCategory());

            Assert.AreEqual(RankCategory.HighCard, pokerHand.GetRankCategory());
        }

        [TestMethod]
        public void GetKeyCardsInDescendingValue_ReturnsHighestCard_WhenRankCategoryIsHighCard()
        {           
            var pokerHand = new PokerHandEvaluator(Dealer.GetCardsForHighCardRankCategory());

            List<Rank> keyCards = pokerHand.GetKeyCardsInDescendingValue();

            Assert.AreEqual(1, keyCards.Count);
            Assert.AreEqual(Rank.Ace, keyCards[0]);
        }

        [TestMethod]
        public void GetKeyCardsInDescendingValue_ReturnsPairCard_WhenRankCategoryIsOnePair()
        {
            var pokerHand = new PokerHandEvaluator(Dealer.GetCardsForOnePairRankCategory());

            List<Rank> keyCards = pokerHand.GetKeyCardsInDescendingValue();

            Assert.AreEqual(1, keyCards.Count);
            Assert.AreEqual(Rank.King, keyCards[0]);
        }

        [TestMethod]
        public void GetRankCategory_ReturnsOnePair()
        {
            var pokerHand = new PokerHandEvaluator(Dealer.GetCardsForOnePairRankCategory());

            Assert.AreEqual(RankCategory.OnePair, pokerHand.GetRankCategory());
        }

        
    }
}
