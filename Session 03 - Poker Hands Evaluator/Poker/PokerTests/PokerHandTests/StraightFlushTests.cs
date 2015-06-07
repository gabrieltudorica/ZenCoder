using System.Collections.Generic;
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

        private static readonly Dictionary<RankCategory, List<Card>> AllCategories = Dealer.DealAllCategories();

        private readonly PokerHand[] weakCases = 
        {
            new PokerHand(AllCategories[RankCategory.HighCard]),
            new PokerHand(AllCategories[RankCategory.OnePair]),
            new PokerHand(AllCategories[RankCategory.TwoPairs]),
            new PokerHand(AllCategories[RankCategory.ThreeOfAKind]),
            new PokerHand(AllCategories[RankCategory.Straight]),
            new PokerHand(AllCategories[RankCategory.Flush]),
            new PokerHand(AllCategories[RankCategory.FullHouse]),
            new PokerHand(AllCategories[RankCategory.FourOfAKind])
        };

        [Test]
        [TestCaseSource("weakCases")]
        public void StraightFlush_ComparedWith_WeakCases_ReturnsStrong(PokerHand strongerPokerHand)
        {
            Assert.AreEqual(Strength.Strong, tenHighStraightFlush.CompareWith(strongerPokerHand));
        }
    }
}
