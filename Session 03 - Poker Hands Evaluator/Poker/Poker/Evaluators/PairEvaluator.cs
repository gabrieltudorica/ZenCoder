using System.Collections.Generic;
using System.Linq;
using Poker.Model;

namespace Poker.Evaluators
{
    public class PairEvaluator : IEvaluator
    {
        private readonly List<Card> cards;
        private readonly Dictionary<Rank, int> pairs = new Dictionary<Rank, int>();
        private RankCategory rankCategory = RankCategory.None;
        private List<Rank> highCards = new List<Rank>();

        public PairEvaluator(List<Card> cards)
        {
            this.cards = cards;
            Initialize();
        }

        public RankCategory GetRankCategory()
        {
            return rankCategory;
        }

        public List<Rank> GetHighCardsDescending()
        {
            return highCards;
        }

        private void Initialize()
        {
            FindRank();
            FindHighCards();
        }

        private void FindRank()
        {
            FindAllPairs();
            
            if (pairs.Count == 0)
            {
                return;
            }

            if (pairs.Count == 1)
            {
                rankCategory = GetPairRankCategory(pairs[pairs.Keys.First()]);
                return;
            }

            if (IsFullHouse())
            {
                rankCategory = RankCategory.FullHouse;
                return;
            }

            rankCategory = RankCategory.TwoPairs;
        }

        private static RankCategory GetPairRankCategory(int numberOfCardsInPair)
        {
            var possiblePairRanks = new Dictionary<int, RankCategory>
            {
                {2, RankCategory.OnePair},
                {3, RankCategory.ThreeOfAKind}
            };

            return possiblePairRanks[numberOfCardsInPair];
        }

        private bool IsFullHouse()
        {
            return pairs.Keys.Any(rank => GetPairRankCategory(pairs[rank]) == RankCategory.ThreeOfAKind);
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
            if (potentialPair.Value > 1)
            {
                pairs.Add(potentialPair.Key, potentialPair.Value);
            }
        }

        private void FindHighCards()
        {
            highCards = GetSingleCardFromEachPair();
            highCards.AddRange(GetHighCardsInDescendingOrder());
        }

        private List<Rank> GetSingleCardFromEachPair()
        {
            return pairs.Keys.ToList();
        }

        private IEnumerable<Rank> GetHighCardsInDescendingOrder()
        {
            return cards
                .OrderByDescending(x=>x.Rank)
                .Select(x => x.Rank)
                .Except(pairs.Keys).ToList();
        }
    }
}