using System.Collections.Generic;
using Poker.Model;

namespace PokerTests
{
    public static class Dealer
    {
        public static List<Card> GetCardsForStrongHighCardRankCategory()
        {
            return new List<Card>
            {
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamnods),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts)
            };
        }

        public static List<Card> GetCardsForWeakHighCardRankCategory()
        {
            return new List<Card>
            {
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Three, Suit.Diamnods),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts)
            };
        }

        public static List<Card> GetCardsForStrongOnePairRankCategory()
        {
            return new List<Card>
            {
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.Ace, Suit.Diamnods),
                new Card(Rank.Ace, Suit.Spades),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts)
            };
        }

        public static List<Card> GetCardsForWeakOnePairRankCategory()
        {
            return new List<Card>
            {
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Two, Suit.Diamnods),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Eight, Suit.Clubs),
                new Card(Rank.Seven, Suit.Hearts)
            };
        }

        public static List<Card> GetCardsForOnePairRankCategoryWithStrongHighCards()
        {
            return new List<Card>
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Diamnods),
                new Card(Rank.Ace, Suit.Spades),
                new Card(Rank.King, Suit.Clubs),
                new Card(Rank.Queen, Suit.Hearts)
            };
        }

        public static List<Card> GetCardsForOnePairRankCategoryWithWeakHighCards()
        {
            return new List<Card>
            {                
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Diamnods),
                new Card(Rank.Ten, Suit.Hearts),
                new Card(Rank.Nine, Suit.Clubs),
                new Card(Rank.Eight, Suit.Hearts)
            };
        }
    }
}
