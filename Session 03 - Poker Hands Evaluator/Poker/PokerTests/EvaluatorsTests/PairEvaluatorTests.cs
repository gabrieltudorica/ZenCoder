using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Evaluators;
using Poker.Model;

namespace PokerTests.EvaluatorsTests
{
    [TestFixture]
    public class PairEvaluatorTests
    {
        [Test]
        public void GetRankCategory_ReturnsNone_WhenNoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(Dealer.GetCardsForStrongHighCardRankCategory());
            
            Assert.AreEqual(RankCategory.None, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetKeyCards_ReturnsEmptyList_WhenNoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(Dealer.GetCardsForStrongHighCardRankCategory());

            Assert.AreEqual(0, pairEvaluator.GetKeyCards().Count);
        }

        [Test]
        public void GetRankCategory_ReturnsOnePair_WhenOnePairExists()
        {
            var pairEvaluator = new PairEvaluator(Dealer.GetCardsForOnePairRankCategory());

            Assert.AreEqual(RankCategory.OnePair, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetKeyCards_ReturnsListWithPairCard_WhenOnePairExists()
        {
            var pairEvaluator = new PairEvaluator(Dealer.GetCardsForOnePairRankCategory());

            List<Rank> keyCards = pairEvaluator.GetKeyCards();
            Assert.AreEqual(1, keyCards.Count);
            Assert.AreEqual(Rank.King, keyCards[0]);
        }
    }
}
