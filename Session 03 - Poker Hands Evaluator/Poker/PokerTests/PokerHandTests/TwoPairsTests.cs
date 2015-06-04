using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class TwoPairsTests
    {
        private readonly PokerHand twoPairsWeakHighCard = GetTwoPairsWeakHighCard();
        private readonly PokerHand twoPairsStrongHighCard = GetTwoPairsStrongHighCard();           

        [Test]
        public void TwoPairsWithOneHighCard_ComparedWith_SamePairsWithSameHighCard_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, twoPairsWeakHighCard.CompareWith(twoPairsWeakHighCard));
        }

        [Test]
        public void TwoPairsWithWeakHighCard_ComparedWith_SamePairsWithStrongHighCard_ReturnsWeak()
        {            
            Assert.AreEqual(Strength.Weak, twoPairsWeakHighCard.CompareWith(twoPairsStrongHighCard));
        }

        [Test]
        public void TwoPairsWithStrongHighCard_ComparedWith_SamePairsWithWeakHighCard_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, twoPairsStrongHighCard.CompareWith(twoPairsWeakHighCard));
        }

        private static PokerHand GetTwoPairsWeakHighCard()
        {
            List<Card> cards = Dealer.DealTwoPairsOneHighCard(Rank.Ace, Rank.King, Rank.Two);

            return new PokerHand(cards);
        }

        private static PokerHand GetTwoPairsStrongHighCard()
        {
            List<Card> cards = Dealer.DealTwoPairsOneHighCard(Rank.Ace, Rank.King, Rank.Queen);

            return new PokerHand(cards);
        }
    }
}
