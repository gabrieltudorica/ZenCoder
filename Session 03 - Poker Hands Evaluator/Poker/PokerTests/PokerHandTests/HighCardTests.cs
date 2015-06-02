using NUnit.Framework;
using Poker;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class HighCardTests
    {
        private readonly PokerHand strongHighCard = new PokerHand(Dealer.DealForStrongHighCard());
        private readonly PokerHand weakHighCard = new PokerHand(Dealer.DealForWeakHighCard());

        private readonly PokerHand[] weakCases = 
        {
            new PokerHand(Dealer.DealForStrongHighCard()),
            new PokerHand(Dealer.DealForWeakOnePair())
        };
        
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

        [Test]
        [TestCaseSource("weakCases")]
        public void HighCard_ComparedWith_WeakCases_ReturnsWeak(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Weak, weakHighCard.CompareWith(strongerPokerHand));
        }
    }
}
