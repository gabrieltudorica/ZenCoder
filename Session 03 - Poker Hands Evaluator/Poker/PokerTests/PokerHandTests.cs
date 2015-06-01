using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using Poker.Model;

namespace PokerTests
{
    [TestClass]
    public class PokerHandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsException_WhenNumberOfCardsIsDifferentThanFive()
        {
            var cards = new List<Card>
            {
                new Card(Rank.Three, Suit.Clubs)
            };

            new PokerHand(cards);
        }

        [TestMethod]
        public void GetRankCategory_ReturnsHighCard()
        {
            var pokerHand = new PokerHand(Dealer.GetCardsForHighCardRankCategory());

            Assert.AreEqual(RankCategory.HighCard, pokerHand.GetRankCategory());            
        }

        [TestMethod]
        public void GetKeyCards_ReturnsHighestCard()
        {
            var pokerHand = new PokerHand(Dealer.GetCardsForHighCardRankCategory());

            Assert.AreEqual(1, pokerHand.GetKeyCards().Count);
            Assert.AreEqual(Rank.Ace, pokerHand.GetKeyCards()[0]);
        }
    }
}
