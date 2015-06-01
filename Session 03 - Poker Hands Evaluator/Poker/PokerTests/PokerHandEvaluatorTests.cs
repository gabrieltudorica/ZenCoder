using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class PokerHandEvaluatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsException_WhenNumberOfCardsIsDifferentThanFive()
        {
            new PokerHandEvaluator(new object[] {});
        }

        [TestMethod]
        public void GetRank_ReturnsHighCard_WhenNoBetterRankExists()
        {
            var pokerHand = new PokerHandEvaluator(new object[] {"", "", "", "", ""});

            Assert.AreEqual(Rank.HighCard, pokerHand.GetRank());
        }
    }
}
