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
        private readonly PairFinder pairFinder;

        public PokerHandEvaluator(List<Card> cards)
        {            
            if (cards.Count != RequiredNumberOfCards)
            {
                throw new ArgumentException();
            }

            this.cards = cards;
            pairFinder = new PairFinder(cards);
        }
         
        public RankCategory GetRankCategory()
        {
            if (pairFinder.GetPairs().Count > 0)
            {
                return RankCategory.OnePair;
            }

            return RankCategory.HighCard;
        }

        public List<Card> GetKeyCardInDescendingValue()
        {
            return new List<Card> {cards.OrderByDescending(x => x.Rank).First()};
        }        
    }
}
