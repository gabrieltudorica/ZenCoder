using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class PokerHandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetRank_ThrowsException_WhenNumberOfCardsIsDifferentThanFive()
        {
            var pokerHand = new PokerHand(new object[] {});
            pokerHand.GetRank();
        }
    }
}
