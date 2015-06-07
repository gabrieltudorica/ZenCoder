using System.Collections.Generic;
using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class FourOfAKindTests
    {
        private static readonly Rank[] ExpectedFourOfAKindHighCards = { Rank.Ace, Rank.Two };

        private readonly PokerHand strongFourOfAKind = new PokerHand(
            Dealer.DealFourOfAKindOneHighCard(ExpectedFourOfAKindHighCards[0], ExpectedFourOfAKindHighCards[1]));              

        [Test]
        public void GetRankCategory_ReturnsFourOfAKind_WhenFourOfAKindExists()
        {
            Assert.AreEqual(RankCategory.FourOfAKind, strongFourOfAKind.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsTwoHighCards_WhenFourOfAKind()
        {
            List<Rank> highCards = strongFourOfAKind.GetHighCardsDescending();

            Assert.AreEqual(2, highCards.Count);
            Assert.AreEqual(ExpectedFourOfAKindHighCards[0], highCards[0]);
            Assert.AreEqual(ExpectedFourOfAKindHighCards[1], highCards[1]);
        }

        private readonly PokerHand weakFourOfAKind = new PokerHand(Dealer.DealFourOfAKindOneHighCard(Rank.King, Rank.Queen));

        [Test]
        public void StrongFourOfAKind_ComparedWith_WeakFourOfAKind_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongFourOfAKind.CompareWith(weakFourOfAKind));
        }

        [Test]
        public void WeakFourOfAKind_ComparedWith_StrongFourOfAKind_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, weakFourOfAKind.CompareWith(strongFourOfAKind));
        }
    }
}