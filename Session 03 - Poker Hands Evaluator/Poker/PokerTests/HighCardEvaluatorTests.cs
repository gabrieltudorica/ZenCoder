using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using Poker.Evaluators;
using Poker.Model;

namespace PokerTests
{
    [TestClass]
    public class HighCardEvaluatorTests
    {
        private readonly HighCardEvaluator highCardEvaluator =
            new HighCardEvaluator(Dealer.GetCardsForStrongHighCardRankCategory());

        [TestMethod]
        public void GetRankCategory_ReturnsHighCard()
        {            
            Assert.AreEqual(RankCategory.HighCard, highCardEvaluator.GetRankCategory());
        }

        [TestMethod]
        public void GetKeyCards_ReturnsHighestCardRank()
        {
            List<Rank> keyCards = highCardEvaluator.GetKeyCards();

            Assert.AreEqual(Rank.Ace, keyCards[0]);
        }
    }
}
