using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Poker;
using Poker.Model;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PokerTests.PokerHandTests
{
    [TestFixture]
    public class StraightTests
    {
        private static readonly List<Card> NineHighStraightCards = Dealer.DealNineHighStraight();
        private readonly PokerHand nineHighStraight = new PokerHand(NineHighStraightCards);

        [Test]
        public void GetRankCategory_ReturnsStraight_WhenNineHighStraightExists()
        {
            Assert.AreEqual(RankCategory.Straight, nineHighStraight.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsHighCardsInDescendingOrder_WhenNineHighStraightExists()
        {
            Rank[] expectedHighCards = Dealer.GetCardRanksDescending(NineHighStraightCards.Select(x => x.Rank).ToArray());

            List<Rank> highCards = nineHighStraight.GetHighCardsDescending();

            Assert.AreEqual(expectedHighCards[0], highCards[0]);
            Assert.AreEqual(expectedHighCards[1], highCards[1]);
            Assert.AreEqual(expectedHighCards[2], highCards[2]);
            Assert.AreEqual(expectedHighCards[3], highCards[3]);
            Assert.AreEqual(expectedHighCards[4], highCards[4]);
        }

        private static readonly List<Card> AceHighStraightCards = Dealer.DealAceHighStraight();
        private readonly PokerHand aceHighStraight = new PokerHand(AceHighStraightCards);

        [Test]
        public void GetRankCategory_ReturnsStraight_WhenAceHighStraightExists()
        {
            Assert.AreEqual(RankCategory.Straight, aceHighStraight.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsHighCardsInDescendingOrder_WhenAceHighStraightExists()
        {

            Rank[] expectedHighCards = Dealer.GetCardRanksDescending(AceHighStraightCards.Select(x => x.Rank).ToArray());

            List<Rank> highCards = aceHighStraight.GetHighCardsDescending();

            Assert.AreEqual(expectedHighCards[0], highCards[0]);
            Assert.AreEqual(expectedHighCards[1], highCards[1]);
            Assert.AreEqual(expectedHighCards[2], highCards[2]);
            Assert.AreEqual(expectedHighCards[3], highCards[3]);
            Assert.AreEqual(expectedHighCards[4], highCards[4]);
        }

        private static readonly List<Card> FiveHighStraightCards = Dealer.DealFiveHighStraight();
        private readonly PokerHand fiveHighStraight = new PokerHand(FiveHighStraightCards);

        [Test]
        public void GetRankCategory_ReturnsStraight_WhenFiveHighStraightExists()
        {
            Assert.AreEqual(RankCategory.Straight, fiveHighStraight.GetRankCategory());
        }

        [Test]
        public void GetHighCardsDescending_ReturnsHighCardsInDescendingOrder_WhenFiveHighStraightExists()
        {

            List<Rank> expectedHighCards =
                Dealer.GetCardRanksDescending(FiveHighStraightCards.Select(x => x.Rank).ToArray()).ToList();
            expectedHighCards.Remove(Rank.Ace);
            expectedHighCards.Add(Rank.Ace);

            List<Rank> highCards = fiveHighStraight.GetHighCardsDescending();

            Assert.AreEqual(expectedHighCards[0], highCards[0]);
            Assert.AreEqual(expectedHighCards[1], highCards[1]);
            Assert.AreEqual(expectedHighCards[2], highCards[2]);
            Assert.AreEqual(expectedHighCards[3], highCards[3]);
            Assert.AreEqual(expectedHighCards[4], highCards[4]);
        }

        [Test]
        public void StrongStraight_ComparedWith_WeakStraight_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, aceHighStraight.CompareWith(nineHighStraight));
        }

        [Test]
        public void WeakStraight_ComparedWith_StrongStraight_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, nineHighStraight.CompareWith(aceHighStraight));
        }

        [Test]
        public void AStraight_ComparedWith_SameStraight_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, nineHighStraight.CompareWith(nineHighStraight));
        }

        [Test]
        public void NineHighStraight_ComparedWith_FiveHighStraight_ReturnsStrong()
        {
            Assert.AreEqual(Strength.Strong, nineHighStraight.CompareWith(fiveHighStraight));
        }

        [Test]
        public void FiveHighStraight_ComparedWith_NineHightSraight_ReturnsWeak()
        {
            Assert.AreEqual(Strength.Weak, fiveHighStraight.CompareWith(nineHighStraight));
        }

        [Test]
        public void FiveHighStraight_ComparedWith_SameStraight_ReturnsEqual()
        {
            Assert.AreEqual(Strength.Equal, fiveHighStraight.CompareWith(fiveHighStraight));
        }
    }
}
