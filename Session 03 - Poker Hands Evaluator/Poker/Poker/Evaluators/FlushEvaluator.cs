using System.Collections.Generic;
using System.Linq;
using Poker.Model;

namespace Poker.Evaluators
{
    public class FlushEvaluator : IEvaluator
    {
        private readonly List<Card> cards;

        public FlushEvaluator(List<Card> cards)
        {
            this.cards = cards;
        }

        public RankCategory GetRankCategory()
        {
            if (cards.All(x => x.Suit == cards[0].Suit))
            {
                return RankCategory.Flush;
            }

            return RankCategory.None;
        }

        public List<Rank> GetHighCardsDescending()
        {
            return cards.OrderByDescending(x=>x.Rank).Select(x=>x.Rank).ToList();
        }        
    }
}
