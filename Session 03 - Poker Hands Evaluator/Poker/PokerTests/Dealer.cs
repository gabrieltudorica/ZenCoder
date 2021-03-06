﻿using System;
using System.Collections.Generic;
using System.Linq;
using Poker;
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

        public static List<Card> DealNineHighStraight()
        {
            return new List<Card>
            {
                new Card(Rank.Five, Suit.Clubs),
                new Card(Rank.Seven, Suit.Diamnods),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Eight, Suit.Spades),
                new Card(Rank.Nine, Suit.Clubs)
            };
        }

        public static List<Card> DealFiveHighStraight()
        {
            return new List<Card>
            {
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Three, Suit.Diamnods),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Spades),
                new Card(Rank.Ace, Suit.Clubs)
            };
        }

        public static List<Card> DealAceHighStraight()
        {
            return new List<Card>
            {
                new Card(Rank.Ace, Suit.Clubs),
                new Card(Rank.Ten, Suit.Diamnods),
                new Card(Rank.Jack, Suit.Hearts),
                new Card(Rank.Queen, Suit.Spades),
                new Card(Rank.King, Suit.Clubs)
            };
        }

        public static List<Card> DealAceHighStraightFlush(Suit suit)
        {
            return new List<Card>
            {
                new Card(Rank.Ace, suit),
                new Card(Rank.Ten, suit),
                new Card(Rank.Jack, suit),
                new Card(Rank.Queen, suit),
                new Card(Rank.King, suit)
            };
        }

        public static List<Card> DealTenHighStraightFlush(Suit suit)
        {
            return new List<Card>
            {
                new Card(Rank.Ten, suit),
                new Card(Rank.Nine, suit),
                new Card(Rank.Eight, suit),
                new Card(Rank.Six, suit),
                new Card(Rank.Seven, suit)
            };
        }

        public static Dictionary<RankCategory, List<Card>> DealAllCategories()
        {
            Rank[] highCards = {Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Eight};

            var allCategories = new Dictionary<RankCategory, List<Card>>
            {
                {RankCategory.HighCard, DealStrongHighCard()},
                {RankCategory.OnePair, DealOnePairThreeHighCards(Rank.Ace, new []{highCards[0], highCards[1], highCards[2]})},
                {RankCategory.TwoPairs, DealTwoPairsOneHighCard(Rank.Ace, Rank.King, Rank.Nine)},
                {RankCategory.ThreeOfAKind, DealThreeOfAKindTwoHighCards(Rank.Ace, new []{highCards[0], highCards[1]})},
                {RankCategory.Straight, DealAceHighStraight()},
                {RankCategory.Flush, DealFlush(highCards, Suit.Diamnods)},
                {RankCategory.FullHouse, DealFullHouse(Rank.Ace, Rank.King)},
                {RankCategory.FourOfAKind, DealFourOfAKindOneHighCard(Rank.Ace, Rank.King)},
                {RankCategory.StraightFlush, DealAceHighStraightFlush(Suit.Spades)}
            };

            return allCategories;
        }

        public static Rank[] GetCardRanksDescending(Rank[] cards)
        {
            Array.Sort(cards);

            return cards.Reverse().ToArray();
        }        
    }
}
