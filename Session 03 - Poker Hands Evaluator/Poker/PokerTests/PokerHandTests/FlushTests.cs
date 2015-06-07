using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class FlushTests
    {
        private static readonly Rank[] StrongFlushCards = {Rank.King, Rank.Two, Rank.Five, Rank.Eight, Rank.Ten};
        private readonly PokerHand strongFlush = new PokerHand(Dealer.DealFlush(StrongFlushCards, Suit.Clubs));

        private static readonly Rank[] WeakFlushCards = { Rank.Queen, Rank.Two, Rank.Five, Rank.Eight, Rank.Ten };
        private readonly PokerHand weakFlush = new PokerHand(Dealer.DealFlush(WeakFlushCards, Suit.Diamnods));

        private readonly PokerHand equalFlush = new PokerHand(Dealer.DealFlush(StrongFlushCards, Suit.Spades));

        [Test]
        public void StrongFlush_ComparedWith_WeakFlush_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongFlush.CompareWith(weakFlush));
        }

        [Test]
        public void WeakFlush_ComparedWith_StrongFlush_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, weakFlush.CompareWith(strongFlush));
        }

        [Test]
        public void AFlush_ComparedWith_EqualFlush_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, strongFlush.CompareWith(equalFlush));
        }
    }
}
