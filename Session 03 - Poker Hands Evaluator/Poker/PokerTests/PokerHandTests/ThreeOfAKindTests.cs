using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class ThreeOfAKindTests
    {
        private static readonly Rank[] HighCards = { Rank.Two, Rank.Three };
        private readonly PokerHand strongThreeOfAKind = new PokerHand(Dealer.DealThreeOfAKindTwoHighCards(Rank.Ace, HighCards));
        private readonly PokerHand weakThreeOfAKind = new PokerHand(Dealer.DealThreeOfAKindTwoHighCards(Rank.King, HighCards));

        [Test]
        public void StrongThreeOfAKind_ComparedWith_WeakThreeOfAKind_ReturnsStrong()
        {          
            Assert.AreEqual(Strength.Strong, strongThreeOfAKind.CompareWith(weakThreeOfAKind));
        }

        [Test]
        public void WeakThreeOfAKind_ComparedWith_StrongThreeOfAKind_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, weakThreeOfAKind.CompareWith(strongThreeOfAKind));
        }
    }
}
