using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class FullHouseTests
    {
        private readonly PokerHand strongFullHouse = new PokerHand(Dealer.DealFullHouse(Rank.Ace, Rank.King));
        private readonly PokerHand weakFullHouse = new PokerHand(Dealer.DealFullHouse(Rank.King, Rank.Queen));

        [Test]
        public void StrongFullHouse_ComparedWith_WeakFullHouse_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongFullHouse.CompareWith(weakFullHouse));
        }

        [Test]
        public void WeakFullHouse_ComparedWith_StrongFullHouse_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, weakFullHouse.CompareWith(strongFullHouse));
        }
    }
}
