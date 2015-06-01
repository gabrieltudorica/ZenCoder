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
    }
}
