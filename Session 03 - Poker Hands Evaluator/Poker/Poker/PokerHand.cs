using System;

namespace Poker
{
    public class PokerHand
    {
        private const int RequiredNumberOfCards = 5;

        private readonly object[] cards;

        public PokerHand(object[] cards)
        {
            this.cards = cards;
        }

        public void GetRank()
        {
            if (cards.Length != RequiredNumberOfCards)
            {
                throw new ArgumentException();
            }
        }
    }
}
