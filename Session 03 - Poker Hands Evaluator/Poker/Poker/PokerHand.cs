using System;
using System.Collections.Generic;
using Poker.Evaluators;
using Poker.Model;

namespace Poker
{
    public class PokerHand
    {                
        private readonly List<Card> cards; 
        private IEvaluator evaluator;             

        public PokerHand(List<Card> cards)
        {
            this.cards = cards;

            ValidateNumberOfCards();                     
            Initialize();
        }

        public RankCategory GetRankCategory()
        {
            return evaluator.GetRankCategory();
        }

        public List<Rank> GetKeyCards()
        {
            return evaluator.GetKeyCards();
        }

        private void ValidateNumberOfCards()
        {
            const int requiredNumberOfCards = 5;

            if (cards.Count != requiredNumberOfCards)
            {
                throw new ArgumentException();
            }
        }

        private void Initialize()
        {
            var evaluators = new List<IEvaluator>
            {
                new PairEvaluator(cards),
                new HighCardEvaluator(cards)
            };  

            FindEvaluator(evaluators);
            
        }

        private void FindEvaluator(IEnumerable<IEvaluator> evaluators)
        {
            foreach (IEvaluator currentEvaluator in evaluators)
            {
                if (currentEvaluator.GetRankCategory() != RankCategory.None)
                {
                    evaluator = currentEvaluator;
                }
            }
        }
    }
}