using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Poker;
using Poker.Evaluators;
using Poker.Model;

namespace PokerTests.EvaluatorsTests
{
    [TestFixture]
    public class HighCardEvaluatorTests
    {
        private static readonly List<Card> HighCardCards = Dealer.DealStrongHighCard(); 
        private readonly HighCardEvaluator highCardEvaluator = new HighCardEvaluator(HighCardCards);

        [Test]
        public void GetRankCategory_ReturnsHighCard()
        {            
            Assert.AreEqual(RankCategory.HighCard, highCardEvaluator.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsHighCardsInDescendingOrder()
        {
            List<Rank> expectedHighCards = HighCardCards.OrderByDescending(x => x.Rank).Select(x => x.Rank).ToList();
            List<Rank> highCards = highCardEvaluator.GetHighCardsDescending();

            Assert.AreEqual(expectedHighCards[0], highCards[0]);
            Assert.AreEqual(expectedHighCards[1], highCards[1]);
            Assert.AreEqual(expectedHighCards[2], highCards[2]);
            Assert.AreEqual(expectedHighCards[3], highCards[3]);
            Assert.AreEqual(expectedHighCards[4], highCards[4]);
        }
    }
}
