using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Poker;
using Poker.Evaluators;
using Poker.Model;

namespace PokerTests.EvaluatorsTests
{
    [TestFixture]
    public class PairEvaluatorTests
    {              
        private readonly List<Card> highCardCards = Dealer.DealStrongHighCard();

        [Test]
        public void GetRankCategory_ReturnsNone_WhenNoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(highCardCards);
            
            Assert.AreEqual(RankCategory.None, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsAllCardsInDescendingOrder_WhenNoPairsExist()
        {
            var pairEvaluator = new PairEvaluator(highCardCards);
            Rank[] expectedHighCardsDescendingOrder = GetCardRanksDescending(highCardCards.Select(x=>x.Rank).ToArray());
            
            List<Rank> highCards = pairEvaluator.GetHighCardsDescending();

            Assert.AreEqual(5, highCards.Count);
            Assert.AreEqual(expectedHighCardsDescendingOrder[0], highCards[0]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[1], highCards[1]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[2], highCards[2]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[3], highCards[3]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[4], highCards[4]);
        }

        private const Rank PairOne = Rank.Ace;
        private static readonly Rank[] ExpectedOnePairHighCards = { Rank.Three, Rank.Two, Rank.Five };
        private readonly List<Card> onePairCards = Dealer.DealOnePairThreeHighCards(PairOne, ExpectedOnePairHighCards);

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
            Rank[] expectedHighCardsDescendingOrder = GetCardRanksDescending(ExpectedOnePairHighCards);

            List<Rank> highCards = pairEvaluator.GetHighCardsDescending();
            
            Assert.AreEqual(4, highCards.Count);
            Assert.AreEqual(PairOne, highCards[0]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[0], highCards[1]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[1], highCards[2]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[2], highCards[3]);
        }

        private const Rank PairTwo = Rank.King;
        private const Rank ExpectedTwoPairsHighCard = Rank.Two;
        private readonly List<Card> twoPairsCards = Dealer.DealTwoPairsOneHighCard(PairOne, PairTwo, ExpectedTwoPairsHighCard);

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

            List<Rank> highCards = pairEvaluator.GetHighCardsDescending();

            Assert.AreEqual(3, highCards.Count);
            Assert.AreEqual(PairOne, highCards[0]);
            Assert.AreEqual(PairTwo, highCards[1]);
            Assert.AreEqual(ExpectedTwoPairsHighCard, highCards[2]);
        }

        private const Rank ThreeOfAKind = Rank.King;
        private static readonly Rank[] ExpectedThreeOfAKindHighCards = {Rank.Seven, Rank.Nine};

        private readonly List<Card> threeOfAKindCards = Dealer.DealThreeOfAKindTwoHighCards(
            ThreeOfAKind,ExpectedThreeOfAKindHighCards);

        [Test]
        public void GetRankCategory_ReturnsThreeOfAKind_WhenThreeOfAKindExists()
        {
            var pairEvaluator = new PairEvaluator(threeOfAKindCards);

            Assert.AreEqual(RankCategory.ThreeOfAKind, pairEvaluator.GetRankCategory());
        }
        
        [Test]
        public void GetHighCardsDescending_ReturnsThreeHighCards_WhenThreeOfAKindExists()
        {
            var pairEvaluator = new PairEvaluator(threeOfAKindCards);
            Rank[] expectedHighCardsDescendingOrder = GetCardRanksDescending(ExpectedThreeOfAKindHighCards);

            List<Rank> highCards = pairEvaluator.GetHighCardsDescending();

            Assert.AreEqual(3, highCards.Count);
            Assert.AreEqual(ThreeOfAKind, highCards[0]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[0], highCards[1]);
            Assert.AreEqual(expectedHighCardsDescendingOrder[1], highCards[2]);
        }

        private static readonly Rank[] ExpectedFullHouseHighCards = { Rank.Ace, Rank.King };

        private readonly List<Card> fullHouseCards = Dealer.DealFullHouse(
            ExpectedFullHouseHighCards[0],
            ExpectedFullHouseHighCards[1]);

        [Test]
        public void GetRankCategory_ReturnsFullHouse_WhenFullHouseExists()
        {
            var pairEvaluator = new PairEvaluator(fullHouseCards);

            Assert.AreEqual(RankCategory.FullHouse, pairEvaluator.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsTwoHighCards_WhenFullHouseExists()
        {
            var pairEvaluator = new PairEvaluator(fullHouseCards);

            List<Rank> highCards = pairEvaluator.GetHighCardsDescending();

            Assert.AreEqual(2, highCards.Count);
            Assert.AreEqual(ExpectedFullHouseHighCards[0], highCards[0]);
            Assert.AreEqual(ExpectedFullHouseHighCards[1], highCards[1]);
        }

        public Rank[] GetCardRanksDescending(Rank[] cards)
        {
            Array.Sort(cards);

            return cards.Reverse().ToArray();
        }
    }
}
