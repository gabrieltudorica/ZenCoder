using System;

namespace Poker
{
    public class PokerHand
    {
        private readonly object[] cards;

        public PokerHand(object[] cards)
        {
            this.cards = cards;
        }

        public void GetRank()
        {
            if (cards.Length != 5)
            {
                throw new ArgumentException();
            }
        }
    }
}
