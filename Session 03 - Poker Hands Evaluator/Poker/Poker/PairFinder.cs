using System.Collections.Generic;
using Poker.Model;

namespace Poker
{
    public class PairFinder
    {
        private readonly List<Card> cards;        
        private readonly Dictionary<Rank, int> pairs = new Dictionary<Rank, int>(); 

        public PairFinder(List<Card> cards)
        {
            this.cards = cards;
            FindAllPairs();
        }

        public Dictionary<Rank, int> GetPairs()
        {
            return pairs;
        }

        private void FindAllPairs()
        {
            foreach (KeyValuePair<Rank, int> potentialPair in GetPotentialPairs())
            {
                AddValidPair(potentialPair);
            }
        }

        private Dictionary<Rank, int> GetPotentialPairs()
        {
            var potentialPairs = new Dictionary<Rank, int>();

            foreach (Card card in cards)
            {
                if (potentialPairs.ContainsKey(card.Rank))
                {
                    potentialPairs[card.Rank] += 1;
                    continue;
                }

                potentialPairs.Add(card.Rank, 1);
            }

            return potentialPairs;
        }       

        private void AddValidPair(KeyValuePair<Rank, int> potentialPair)
        {
            if (potentialPair.Value == 2)
            {
                pairs.Add(potentialPair.Key, 2);
            }
        }       
    }
}