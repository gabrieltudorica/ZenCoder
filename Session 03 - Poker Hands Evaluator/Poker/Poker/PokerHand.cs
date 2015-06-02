using System;
using System.Collections.Generic;
using Poker.Evaluators;
using Poker.Model;

namespace Poker
{
    public class PokerHand
    {
        private const int RequiredNumberOfCards = 5;

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
            if (cards.Count != RequiredNumberOfCards)
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
                    break;
                }
            }
        }

        public Strength CompareWith(PokerHand otherHand)
        {
            if (GetRankCategory() > otherHand.GetRankCategory())
            {
                return Strength.Strong;
            }

            if (GetRankCategory() < otherHand.GetRankCategory())
            {
                return Strength.Weak;
            }

           return GetStrengthFromTieRankCategories(otherHand.GetKeyCards());
        }

        private Strength GetStrengthFromTieRankCategories(List<Rank> otherHandKeyCards)
        {
            List<Rank> currentHandKeyCards = GetKeyCards();

            for (int i = 0; i < currentHandKeyCards.Count; i++)
            {
                if (currentHandKeyCards[i] > otherHandKeyCards[i])
                {
                    return Strength.Strong;
                }

                if (currentHandKeyCards[i] < otherHandKeyCards[i])
                {
                    return Strength.Weak;
                }
            }

            return Strength.Equal;
        }
    }
}