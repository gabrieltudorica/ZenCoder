using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Model;

namespace Poker
{
    public class PokerHandEvaluator
    {
        private const int RequiredNumberOfCards = 5;

        private readonly List<Card> cards;

        public PokerHandEvaluator(List<Card> cards)
        {
            this.cards = cards;

            if (cards.Count != RequiredNumberOfCards)
            {
                throw new ArgumentException();
            }
        }
         
        public RankCategory GetRank()
        {           
            return RankCategory.HighCard;
        }

        public List<Card> GetKeyCardInDescendingValue()
        {
            return new List<Card> {cards.OrderByDescending(x => x.Rank).First()};
        }
    }
}
