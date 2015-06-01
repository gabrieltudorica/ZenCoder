using System;

namespace Poker
{
    public class PokerHandEvaluator
    {
        private const int RequiredNumberOfCards = 5;

        private readonly object[] cards;

        public PokerHandEvaluator(object[] cards)
        {
            this.cards = cards;

            if (cards.Length != RequiredNumberOfCards)
            {
                throw new ArgumentException();
            }
        }
         
        public Rank GetRank()
        {           
            return Rank.HighCard;
        }
    }
}
