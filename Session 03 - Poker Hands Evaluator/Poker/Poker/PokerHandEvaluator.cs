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
        private PairFinder pairFinder;
        private RankCategory rankCategory;

        public PokerHandEvaluator(List<Card> cards)
        {            
            if (cards.Count != RequiredNumberOfCards)
            {
                throw new ArgumentException();
            }

            this.cards = cards;
            FindRankCategory();
        }
         
        public RankCategory GetRankCategory()
        {
            return rankCategory;
        }

        public List<Rank> GetKeyCardsInDescendingValue()
        {
            if (rankCategory == RankCategory.OnePair)
            {
                return new List<Rank>(pairFinder.GetPairs().Keys);
            }

            return new List<Rank> {cards.OrderByDescending(x => x.Rank).First().Rank};
        }

        private void FindRankCategory()
        {
            pairFinder = new PairFinder(cards);

            if (pairFinder.GetPairs().Count > 0)
            {
                rankCategory = RankCategory.OnePair;
                return;
            }

            rankCategory = RankCategory.HighCard;
        }
    }
}