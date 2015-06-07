using System.Collections.Generic;
using System.Linq;
using Poker.Model;

namespace Poker.Evaluators
{
    public class StraightEvaluator : IEvaluator
    {
        private readonly List<Card> cards;
        private readonly FlushEvaluator flushEvaluator;

        public StraightEvaluator(List<Card> cards, FlushEvaluator flushEvaluator)
        {
            this.cards = cards;
            this.flushEvaluator = flushEvaluator;
        }

        public RankCategory GetRankCategory()
        {
            if (AreConsecutive() || IsFiveHighStraight())
            {
                if (flushEvaluator.GetRankCategory() == RankCategory.Flush)
                {
                    return RankCategory.StraightFlush;
                }

                return RankCategory.Straight;
            }

            return RankCategory.None;
        }

        public List<Rank> GetHighCardsDescending()
        {
            List<Rank> descendingCards = GetDescendingCards();

            if (IsFiveHighStraight())
            {
                descendingCards.Remove(Rank.Ace);
                descendingCards.Add(Rank.Ace);
            }

            return descendingCards;
        }

        private bool AreConsecutive()
        {
            List<Rank> descendingCards = GetHighCardsDescending();

            for (int currentIndex = 0; currentIndex < descendingCards.Count; currentIndex++)
            {                
                if (currentIndex == descendingCards.Count - 1)
                {
                    break;
                }

                int nextIndex = currentIndex + 1;

                Rank currentCard = descendingCards[currentIndex];
                Rank nextCard = descendingCards[nextIndex];

                if (currentCard - nextCard != 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsFiveHighStraight()
        {
            var fiveHighStraight = new List<Rank>
            {
                Rank.Ace, Rank.Two, Rank.Three, Rank.Four, Rank.Five
            };

            return GetDescendingCards().Intersect(fiveHighStraight).Count() == cards.Count;
        }

        private List<Rank> GetDescendingCards()
        {
            return cards.OrderByDescending(x => x.Rank).Select(x => x.Rank).ToList();
        }
    }
}
