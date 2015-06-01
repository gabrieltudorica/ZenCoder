using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using Poker.Model;

namespace PokerTests
{
    [TestClass]
    public class PairFinderTests
    {
        [TestMethod]
        public void GetPairs_ReturnsZero_WhenNoPairsExist()
        {
            var pairFinder = new PairFinder(Dealer.GetCardsForHighCardRankCategory());
            
            Assert.AreEqual(0, pairFinder.GetPairs().Count);
        }

        [TestMethod]
        public void GetPairs_ReturnsOne_WhenOnePairExists()
        {
            var pairFinder = new PairFinder(Dealer.GetCardsForOnePairRankCategory());

            Dictionary<Rank, int> pairs = pairFinder.GetPairs();

            Assert.AreEqual(1, pairs.Count);
            Assert.AreEqual(Rank.King, pairs.Keys.First());
        }

    }
}
