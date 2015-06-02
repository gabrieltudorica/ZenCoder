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
            new HighCardEvaluator(Dealer.GetCardsForStrongHighCardRankCategory());

        [Test]
        public void GetRankCategory_ReturnsHighCard()
        {            
            Assert.AreEqual(RankCategory.HighCard, highCardEvaluator.GetRankCategory());
        }

        [Test]
        public void GetKeyCards_ReturnsHighestCardRank()
        {
            List<Rank> keyCards = highCardEvaluator.GetKeyCards();

            Assert.AreEqual(Rank.Ace, keyCards[0]);
        }
    }
}
