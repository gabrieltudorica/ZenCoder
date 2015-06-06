using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class FourOfAKindTests
    {
        private readonly PokerHand strongFourOfAKind = new PokerHand(Dealer.DealFourOfAKindOneHighCard(Rank.Ace, Rank.Two));
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
