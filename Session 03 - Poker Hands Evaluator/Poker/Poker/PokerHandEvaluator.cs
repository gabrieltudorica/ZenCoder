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
        private PairEvaluator _pairEvaluator;
        private RankCategory rankCategory;

        public PokerHandEvaluator(List<Card> cards)
        {            
            if (cards.Count != RequiredNumberOfCards)
            {
                throw new ArgumentException();
            }

            this.cards = cards;
        }                
    }
}