using System.Collections.Generic;
using Poker.Model;

namespace PokerTests
{
    public static class Dealer
    {
        public static List<Card> DealStrongHighCard()
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

        public static List<Card> DealWeakHighCard()
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

        public static List<Card> DealOnePairThreeHighCards(Rank pair, Rank[] highCards)
        {
            return new List<Card>
            {                
                new Card(pair, Suit.Hearts),
                new Card(pair, Suit.Diamnods),
                new Card(highCards[0], Suit.Hearts),
                new Card(highCards[1], Suit.Clubs),
                new Card(highCards[2], Suit.Hearts)
            };
        }

        public static List<Card> DealTwoPairsOneHighCard(Rank firstPair, Rank secondPair, Rank highCard)
        {
            return new List<Card>
            {                
                new Card(firstPair, Suit.Hearts),
                new Card(firstPair, Suit.Diamnods),
                new Card(secondPair, Suit.Hearts),
                new Card(secondPair, Suit.Clubs),
                new Card(highCard, Suit.Hearts)
            };
        }

        public static List<Card> DealThreeOfAKindTwoHighCards(Rank threeOfAKind, Rank[] highCards)
        {
            return new List<Card>
            {
                new Card(threeOfAKind, Suit.Clubs),
                new Card(threeOfAKind, Suit.Diamnods),
                new Card(threeOfAKind, Suit.Hearts),
                new Card(highCards[0], Suit.Spades),
                new Card(highCards[1], Suit.Hearts),
            };
        }

        public static List<Card> DealFullHouse(Rank threeOfAKind, Rank onePair)
        {
            return new List<Card>
            {
                new Card(threeOfAKind, Suit.Clubs),
                new Card(threeOfAKind, Suit.Diamnods),
                new Card(threeOfAKind, Suit.Hearts),
                new Card(onePair, Suit.Spades),
                new Card(onePair, Suit.Clubs)
            };
        }

        public static List<Card> DealFourOfAKindOneHighCard(Rank fourOfAKind, Rank highCard)
        {
            return new List<Card>
            {
                new Card(fourOfAKind, Suit.Clubs),
                new Card(fourOfAKind, Suit.Diamnods),
                new Card(fourOfAKind, Suit.Hearts),
                new Card(fourOfAKind, Suit.Spades),
                new Card(highCard, Suit.Hearts)
            };
        }

        public static List<Card> DealFlush(Rank[] flush, Suit suit)
        {
            return new List<Card>
            {
                new Card(flush[0], suit),
                new Card(flush[1], suit),
                new Card(flush[2], suit),
                new Card(flush[3], suit),
                new Card(flush[4], suit)
            };
        }
    }
}
