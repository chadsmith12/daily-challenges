using System;
using System.Collections.Generic;

namespace DailyChallengesLib.ScrabbleCalculator
{
    public class InMemoryScrabbleScoreProvider : IScrabbleScoreProvider
    {
        public IDictionary<char, int> GetScores()
        {
            return new Dictionary<char, int>
            {
                {'A', 1 },
                {'B', 3 },
                {'C', 1 },
                {'D', 3 },
                {'E', 1 },
                {'F', 3 },
                {'G', 1 },
                {'H', 3 },
                {'I', 1 },
                {'J', 3 },
                {'K', 1 },
                {'L', 3 },
                {'M', 1 },
                {'N', 3 },
                {'O', 1 },
                {'P', 3 },
                {'Q', 3 },
                {'R', 1 },
                {'S', 3 },
                {'T', 1 },
                {'U', 3 },
                {'V', 3 },
                {'W', 1 },
                {'X', 3 },
                {'Y', 1 },
                {'Z', 3 }
            };
        }
    }
}
