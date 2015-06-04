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
        private const Rank Pair = Rank.Ace;
        private static readonly Rank[] OnePairHighCards = {Rank.Two, Rank.Three, Rank.Five};        
        private readonly List<Card> onePair = Dealer.DealOnePairThreeHighCards(Pair, OnePairHighCards);

        private readonly List<Card> highCards = Dealer.DealStrongHighCard();

        [Test]
        public void GetRankCategory_ReturnsNone_WhenNoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(highCards);
            
            Assert.AreEqual(RankCategory.None, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsAllCardsInDescendingOrder_WhenNoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(highCards);

            Assert.AreEqual(5, pairEvaluator.GetHighCardsDescending().Count);
        }

        [Test]
        public void GetRankCategory_ReturnsOnePair_WhenOnePairExists()
        {
            var pairEvaluator = new PairEvaluator(onePair);

            Assert.AreEqual(RankCategory.OnePair, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsListWithPairCardAndHighCardsInDescendingOrder_WhenOnePairExists()
        {
            var pairEvaluator = new PairEvaluator(onePair);

            List<Rank> keyCards = pairEvaluator.GetHighCardsDescending();
            
            Assert.AreEqual(4, keyCards.Count);
            Assert.AreEqual(Pair, keyCards[0]);
            Assert.AreEqual(OnePairHighCards[2], keyCards[1]);
            Assert.AreEqual(OnePairHighCards[1], keyCards[2]);
            Assert.AreEqual(OnePairHighCards[0], keyCards[3]);
        }
    }
}
