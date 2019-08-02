using System;
using System.Collections.Generic;
namespace DailyChallengesLib.ScrabbleCalculator
{
    public interface IScrabbleScoreProvider
    {
        /// <summary>
        /// Gets the dictionary of the score that each letter is worth.
        /// </summary>
        /// <returns>Dictionary of the score of each letter. Key is the letter, value is the score it's worth.</returns>
        IDictionary<char, int> GetScores();
    }
}
