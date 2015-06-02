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
            var pairEvaluator = new PairEvaluator(Dealer.DealForStrongHighCard());
            
            Assert.AreEqual(RankCategory.None, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetKeyCards_ReturnsAllCards_WhenNoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(Dealer.DealForStrongHighCard());

            Assert.AreEqual(5, pairEvaluator.GetKeyCards().Count);
        }

        [Test]
        public void GetRankCategory_ReturnsOnePair_WhenOnePairExists()
        {
            var pairEvaluator = new PairEvaluator(Dealer.DealForWeakOnePair());

            Assert.AreEqual(RankCategory.OnePair, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetKeyCards_ReturnsListWithPairCardAndHighCardsInDescendingOrder_WhenOnePairExists()
        {
            var pairEvaluator = new PairEvaluator(Dealer.DealForWeakOnePair());

            List<Rank> keyCards = pairEvaluator.GetKeyCards();
            
            Assert.AreEqual(4, keyCards.Count);
            Assert.AreEqual(Rank.Two, keyCards[0]);
            Assert.AreEqual(Rank.Eight, keyCards[1]);
            Assert.AreEqual(Rank.Seven, keyCards[2]);
            Assert.AreEqual(Rank.Four, keyCards[3]);
        }
    }
}
