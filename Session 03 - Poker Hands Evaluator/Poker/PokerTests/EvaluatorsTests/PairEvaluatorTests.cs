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

        private const Rank PairOne = Rank.Ace;
        private static readonly Rank[] OnePairHighCards = { Rank.Two, Rank.Three, Rank.Five };
        private readonly List<Card> onePairCards = Dealer.DealOnePairThreeHighCards(PairOne, OnePairHighCards);

        [Test]
        public void GetRankCategory_ReturnsOnePair_WhenOnePairExists()
        {
            var pairEvaluator = new PairEvaluator(onePairCards);

            Assert.AreEqual(RankCategory.OnePair, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsListWithPairCardAndHighCardsInDescendingOrder_WhenOnePairExists()
        {
            var pairEvaluator = new PairEvaluator(onePairCards);

            List<Rank> keyCards = pairEvaluator.GetHighCardsDescending();
            
            Assert.AreEqual(4, keyCards.Count);
            Assert.AreEqual(PairOne, keyCards[0]);
            Assert.AreEqual(OnePairHighCards[2], keyCards[1]);
            Assert.AreEqual(OnePairHighCards[1], keyCards[2]);
            Assert.AreEqual(OnePairHighCards[0], keyCards[3]);
        }

        private const Rank PairTwo = Rank.King;
        private const Rank TwoPairsHighCard = Rank.Two;
        private readonly List<Card> twoPairsCards = Dealer.DealTwoPairsOneHighCard(PairOne, PairTwo, TwoPairsHighCard);

        [Test]
        public void GetRankCategory_ReturnsTwoPairs_WhenTwoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(twoPairsCards);

            Assert.AreEqual(RankCategory.TwoPairs, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsOneHighCard_WhenTwoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(twoPairsCards);

            List<Rank> highCard = pairEvaluator.GetHighCardsDescending();

            Assert.AreEqual(3, highCard.Count);
            Assert.AreEqual(PairOne, highCard[0]);
            Assert.AreEqual(PairTwo, highCard[1]);
            Assert.AreEqual(TwoPairsHighCard, highCard[2]);
        }
    }
}
