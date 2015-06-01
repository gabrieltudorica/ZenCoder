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

        public static List<Card> GetCardsForOnePairRankCategory()
        {
            return new List<Card>
            {
                new Card(Rank.Eight, Suit.Hearts),
                new Card(Rank.King, Suit.Diamnods),
                new Card(Rank.King, Suit.Spades),
                new Card(Rank.Seven, Suit.Clubs),
                new Card(Rank.Four, Suit.Hearts)
            };
        }
    }
}
