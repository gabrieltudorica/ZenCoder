using System.Collections.Generic;
using System.Linq;
using Poker.Model;

namespace Poker.Evaluators
{
    public class HighCardEvaluator : IEvaluator
    {
        private readonly List<Card> cards;

        public HighCardEvaluator(List<Card> cards)
        {
            this.cards = cards;        
        }

        public RankCategory GetRankCategory()
        {
            return RankCategory.HighCard;
        }

        public List<Rank> GetKeyCards()
        {
            return new List<Rank> {cards.OrderByDescending(x => x.Rank).First().Rank};
        }
    }
}
