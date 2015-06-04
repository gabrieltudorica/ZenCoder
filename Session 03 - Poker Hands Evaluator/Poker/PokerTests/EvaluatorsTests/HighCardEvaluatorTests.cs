using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Evaluators;
using Poker.Model;

namespace PokerTests.EvaluatorsTests
{
    [TestFixture]
    public class HighCardEvaluatorTests
    {
        private readonly HighCardEvaluator highCardEvaluator =
            new HighCardEvaluator(Dealer.DealStrongHighCard());

        [Test]
        public void GetRankCategory_ReturnsHighCard()
        {            
            Assert.AreEqual(RankCategory.HighCard, highCardEvaluator.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsHighCardsInDescendingOrder()
        {
            List<Rank> keyCards = highCardEvaluator.GetHighCardsDescending();

            Assert.AreEqual(Rank.Ace, keyCards[0]);
            Assert.AreEqual(Rank.Ace, keyCards[0]);
            Assert.AreEqual(Rank.Ace, keyCards[0]);
            Assert.AreEqual(Rank.Ace, keyCards[0]);
            Assert.AreEqual(Rank.Ace, keyCards[0]);
        }
    }
}
