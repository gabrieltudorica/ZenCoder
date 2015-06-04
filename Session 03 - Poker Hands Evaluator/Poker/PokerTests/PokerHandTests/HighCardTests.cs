using NUnit.Framework;
using Poker;
using Poker.Model;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class HighCardTests
    {
        private readonly PokerHand strongHighCard = new PokerHand(Dealer.DealStrongHighCard());
        private readonly PokerHand weakHighCard = new PokerHand(Dealer.DealWeakHighCard());        
        
        [Test]
        public void StrongHighCard_ComparedWith_WeakHighCard_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, strongHighCard.CompareWith(weakHighCard));
        }

        [Test]
        public void AHighCard_ComparedWith_SameHighCard_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, strongHighCard.CompareWith(strongHighCard));
        }

        private static readonly Rank[] HighCards = { Rank.Four, Rank.Seven, Rank.Eight };
        private readonly PokerHand[] weakCases = 
        {
            new PokerHand(Dealer.DealStrongHighCard()),
            new PokerHand(Dealer.DealOnePairThreeHighCards(Rank.Two, HighCards))
        };

        [Test]
        [TestCaseSource("weakCases")]
        public void HighCard_ComparedWith_WeakCases_ReturnsWeak(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Weak, weakHighCard.CompareWith(strongerPokerHand));
        }
    }
}
