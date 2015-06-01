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
            var pokerHand = new PokerHand(Dealer.GetCardsForStrongHighCardRankCategory());

            Assert.AreEqual(RankCategory.HighCard, pokerHand.GetRankCategory());            
        }

        [TestMethod]
        public void GetKeyCards_ReturnsHighestCard()
        {
            var pokerHand = new PokerHand(Dealer.GetCardsForStrongHighCardRankCategory());

            Assert.AreEqual(Rank.Ace, pokerHand.GetKeyCards()[0]);
        }

        [TestMethod]
        public void CompareWith_ReturnsWeak_WhenHandIsWeakerThanTheOneComparedWith()
        {
            var weakHand = new PokerHand(Dealer.GetCardsForWeakHighCardRankCategory());
            var strongHand = new PokerHand(Dealer.GetCardsForStrongHighCardRankCategory());

            Assert.AreEqual(Strength.Weak, weakHand.CompareWith(strongHand));
        }

        [TestMethod]
        public void CompareWith_ReturnsStrong_WhenHandIsStrongerThanTheOneComparedWith()
        {
            var weakHand = new PokerHand(Dealer.GetCardsForWeakHighCardRankCategory());
            var strongHand = new PokerHand(Dealer.GetCardsForStrongHighCardRankCategory());

            Assert.AreEqual(Strength.Strong, strongHand.CompareWith(weakHand));
        }

        [TestMethod]
        public void CompareWith_ReturnsEqual_WhenHandIsEqualToTheOneComparedWith()
        {
            var firstHand = new PokerHand(Dealer.GetCardsForWeakHighCardRankCategory());
            var secondHand = new PokerHand(Dealer.GetCardsForWeakHighCardRankCategory());

            Assert.AreEqual(Strength.Equal, firstHand.CompareWith(secondHand));
        }
    }
}
