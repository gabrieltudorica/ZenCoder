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

        public List<Rank> GetHighCardsDescending()
        {
            return evaluator.GetHighCardsDescending();
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
            var flushEvaluator = new FlushEvaluator(cards);

            var evaluators = new List<IEvaluator>
            {
                new StraightEvaluator(cards, flushEvaluator),
                flushEvaluator,
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

           return GetStrengthFromTieRankCategories(otherHand.GetHighCardsDescending());
        }

        private Strength GetStrengthFromTieRankCategories(List<Rank> highCards)
        {
            List<Rank> currentHandHighCards = GetHighCardsDescending();

            for (int i = 0; i < currentHandHighCards.Count; i++)
            {
                if (currentHandHighCards[i] > highCards[i])
                {
                    return Strength.Strong;
                }

                if (currentHandHighCards[i] < highCards[i])
                {
                    return Strength.Weak;
                }
            }

            return Strength.Equal;
        }
    }
}