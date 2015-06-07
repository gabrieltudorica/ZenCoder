using System.Collections.Generic;
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

        [Test]
        public void GetRankCategory_ReturnsFlush_WhenFlushExists()
        {
            Assert.AreEqual(RankCategory.Flush, strongFlush.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsHighCardsInDescendingOrder()
        {
            Rank[] expectedHighCards = Dealer.GetCardRanksDescending(StrongFlushCards);

            List<Rank> highCards = strongFlush.GetHighCardsDescending();

            Assert.AreEqual(expectedHighCards[0], highCards[0]);
            Assert.AreEqual(expectedHighCards[1], highCards[1]);
            Assert.AreEqual(expectedHighCards[2], highCards[2]);
            Assert.AreEqual(expectedHighCards[3], highCards[3]);
            Assert.AreEqual(expectedHighCards[4], highCards[4]);
        }

        private static readonly Rank[] WeakFlushCards = { Rank.Queen, Rank.Two, Rank.Five, Rank.Eight, Rank.Ten };
        private readonly PokerHand weakFlush = new PokerHand(Dealer.DealFlush(WeakFlushCards, Suit.Diamnods));

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

        private readonly PokerHand equalFlush = new PokerHand(Dealer.DealFlush(StrongFlushCards, Suit.Spades));

        [Test]
        public void AFlush_ComparedWith_EqualFlush_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, strongFlush.CompareWith(equalFlush));
        }
    }
}
