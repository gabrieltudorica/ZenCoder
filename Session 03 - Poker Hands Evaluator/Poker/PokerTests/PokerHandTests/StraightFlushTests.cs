using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class StraightFlushTests
    {
        private readonly PokerHand aceHighStraightFlush = new PokerHand(Dealer.DealAceHighStraightFlush(Suit.Spades));

        [Test]
        public void GetRankCategory_ReturnsStraightFlush_WhenStraightFlushExists()
        {
            Assert.AreEqual(RankCategory.StraightFlush, aceHighStraightFlush.GetRankCategory());
        }

        private readonly PokerHand tenHighStraightFlush = new PokerHand(Dealer.DealTenHighStraightFlush(Suit.Hearts));

        [Test]
        public void StrongStraightFlush_ComparedWith_WeakStraightFlush_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, aceHighStraightFlush.CompareWith(tenHighStraightFlush));
        }

        [Test]
        public void WeakStraightFlush_ComparedWith_StrongStraightFlush_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, tenHighStraightFlush.CompareWith(aceHighStraightFlush));
        }

        [Test]
        public void AStraightFlush_ComparedWith_SameRankStraightFlush_ReturnsEqual()
        {
            PokerHand aceHighStraightFlushHearts = new PokerHand(Dealer.DealAceHighStraightFlush(Suit.Hearts));

            Assert.AreEqual(Strength.Equal, aceHighStraightFlush.CompareWith(aceHighStraightFlushHearts));
        }
    }
}
