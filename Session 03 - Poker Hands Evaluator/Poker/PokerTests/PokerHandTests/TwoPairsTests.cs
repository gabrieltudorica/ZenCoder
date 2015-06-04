using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class TwoPairsTests
    {
        private static readonly List<Card> CardsForTwoPairsWeakHighCard = 
            Dealer.DealTwoPairsOneHighCard(Rank.Ace,Rank.Queen, Rank.Two);
        private readonly PokerHand twoPairsWeakHighCard = new PokerHand(CardsForTwoPairsWeakHighCard);
        
        private static readonly List<Card> CardsForTwoPairsStrongHighCard =
            Dealer.DealTwoPairsOneHighCard(Rank.Ace, Rank.Queen, Rank.King);
        private readonly PokerHand twoPairsStrongHighCard = new PokerHand(CardsForTwoPairsStrongHighCard);

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

        private static readonly PokerHand[] WeakCases = 
        {
            new PokerHand(Dealer.DealTwoPairsOneHighCard(Rank.King, Rank.Jack, Rank.Nine)),
            new PokerHand(Dealer.DealTwoPairsOneHighCard(Rank.Ten, Rank.Nine, Rank.Eight))
        };

        [Test]
        [TestCaseSource("WeakCases")]
        public void TwoStrongPairs_ComparedWith_TwoWeakPairs_ReturnsStrong(PokerHand weakPairs)
        {
            Assert.AreEqual(Strength.Strong, twoPairsStrongHighCard.CompareWith(weakPairs));
        }

        private readonly PokerHand[] strongCases = 
        {
            new PokerHand(Dealer.DealTwoPairsOneHighCard(Rank.King, Rank.Jack, Rank.Nine)),
            new PokerHand(Dealer.DealTwoPairsOneHighCard(Rank.Ace, Rank.King, Rank.Nine))
        };

        [Test]
        [TestCaseSource("strongCases")]
        public void TwoWeakPairs_ComparedWith_TwoStrongPairs_ReturnsWeak(PokerHand strongPairs)
        {
            Assert.AreEqual(Strength.Weak, WeakCases[1].CompareWith(strongPairs));
        }
    }
}
