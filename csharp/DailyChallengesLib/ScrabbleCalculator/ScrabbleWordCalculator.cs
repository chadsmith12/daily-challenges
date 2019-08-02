using DailyChallengesLib.StringExtensions;

namespace DailyChallengesLib.ScrabbleCalculator
{
    public class ScrabbleWordCalculator
    {
        /// <summary>
        /// Calculates the score of a word.
        /// Uses the <see cref="InMemoryScrabbleScoreProvider"/> to get the score for each letter.
        /// </summary>
        /// <param name="word">The word we need to calculate the score for.</param>
        /// <returns>Integer that is the score of the word.</returns>
        public int CalculateScore(string word)
        {
            return CalculateScore(word, new InMemoryScrabbleScoreProvider());
        }

        /// <summary>
        /// Calculates the score of a word 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="scoreProvider"></param>
        /// <returns></returns>
        public int CalculateScore(string word, IScrabbleScoreProvider scoreProvider)
        {
            int score = 0;
            for(var i = 0; i < word.Length; i++)
            {
                int scoreLetter;
                int characterMultiplier;

                // we don't care about the * or ^. We have parsed them already.
                if (word[i] == '*' || word[i] == '^')
                {
                    continue;
                }

                characterMultiplier = CalculateLetterMultiplier(word, i);
                scoreLetter = scoreProvider.GetScores()[char.ToUpper(word[i])];
                scoreLetter *= characterMultiplier;
                score += scoreLetter;
            }

            // last letter is a D, double the score
            if (word[word.Length - 1] == 'D')
            {
                score *= 2;
            }
            else if(word[word.Length - 1] == 'T')
            {
                score *= 3;
            }

            // above 7 scores 50 more
            if(word.RemoveSymbols().Length >= 7)
            {
                score += 50;
            }

            return score;
        }

        private static int CalculateLetterMultiplier(string word, int i)
        {
            // next letter is a carrot, score zero
            if (i + 1 < word.Length && word[i + 1] == '^')
            {
                return 0;
            }

            // we can still look at the next letter for double or triple points
            if (i + 1 < word.Length)
            {
                // no asteric, character only worth one.
                if(word[i + 1] != '*')
                {
                    return 1;
                }
                //  we know the next character is an *, if further is one too worth triple.
                if(i + 2 < word.Length && word[i + 2] == '*')
                {
                    return 3;
                }

                // we now know it's worth double.
                return 2;
            }

            return 1;
        }
    }
}
