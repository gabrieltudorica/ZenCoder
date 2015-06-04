using System.Collections.Generic;
using Poker.Model;

namespace Poker.Evaluators
{
    public interface IEvaluator
    {
        RankCategory GetRankCategory();
        List<Rank> GetHighCardsDescending();
    }
}
