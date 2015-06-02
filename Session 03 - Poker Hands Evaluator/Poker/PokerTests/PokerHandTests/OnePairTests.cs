using NUnit.Framework;
using Poker;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class OnePairTests
    {
        private readonly PokerHand weakPair = new PokerHand(Dealer.DealForWeakOnePair());
        private readonly PokerHand strongPair = new PokerHand(Dealer.DealForStrongOnePair());

        private readonly PokerHand pairWithWeakHighCards =
            new PokerHand(Dealer.DealForOnePairWithWeakHighCards());

        private readonly PokerHand pairWithStrongHighCards =
            new PokerHand(Dealer.DealForOnePairWithStrongHighCards());

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
    }
}
