using System;
using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class OnePairTests
    {
        private static readonly Rank[] HighCards = {Rank.Two, Rank.Three, Rank.Five};

        private readonly PokerHand weakPair = GetWeakPair();
        private readonly PokerHand strongPair = GetStrongPair();

        private readonly PokerHand pairWithWeakHighCards = GetPairWithWeakHighCards();
        private readonly PokerHand pairWithStrongHighCards = GetPairWithStrongHighCards();

        [Test]
        public void WeakPair_ComparedWith_StrongPair_ReturnsWeak()
        {           
            Assert.AreEqual(Strength.Weak, weakPair.CompareWith(strongPair));
        }

        [Test]
        public void APairWithWeakHighCards_ComparedWith_SamePairWithStrongerHighCards_ReturnsWeak()
        {            
            Assert.AreEqual(Strength.Weak, pairWithWeakHighCards.CompareWith(pairWithStrongHighCards));
        }

        [Test]
        public void APairWithStrongHighCards_ComparedWith_SamePairWithWeakHighCards_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, pairWithStrongHighCards.CompareWith(pairWithWeakHighCards));
        }

        [Test]
        public void APairWithSomeHighCards_ComparedWith_SamePairWithSameHighCards_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, pairWithWeakHighCards.CompareWith(pairWithWeakHighCards));
        }

        [Test]
        public void StrongPair_ComparedWith_WeakPair_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongPair.CompareWith(weakPair));
        }

        private static PokerHand GetWeakPair()
        {
            List<Card> cards = Dealer.DealOnePairThreeHighCards(Rank.Two, HighCards);
            
            return new PokerHand(cards);
        }

        private static PokerHand GetStrongPair()
        {
            List<Card> cards = Dealer.DealOnePairThreeHighCards(Rank.Ace, HighCards);
            
            return new PokerHand(cards);
        }

        private static PokerHand GetPairWithWeakHighCards()
        {
            List<Card> cards = Dealer.DealOnePairThreeHighCards(Rank.Ace, HighCards);
            
            return new PokerHand(cards);
        }

        private static PokerHand GetPairWithStrongHighCards()
        {
            Rank[] highCardsCopy = new Rank[HighCards.Length];
            Array.Copy(HighCards,highCardsCopy,HighCards.Length);
            highCardsCopy[0] = Rank.King;

            List<Card> cards = Dealer.DealOnePairThreeHighCards(Rank.Ace, highCardsCopy);

            return new PokerHand(cards);
        }
    }
}
