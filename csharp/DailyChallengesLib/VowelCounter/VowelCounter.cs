using System.Collections.Generic;
using System.Linq;

namespace DailyChallengesLib.VowelCounter
{
    public class VowelCounter
    {
        /// <summary>
        /// Counts the number of vowels that are in a string.
        /// A vowel is defined as: "a, e, i, o, u" upper and lowercase.
        /// </summary>
        /// <param name="value">The string value to count the number of vowels in.</param>
        /// <returns>The number of vowels that were in the string.</returns>
        public int CountVowels(string value)
        {
            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            return value.Count(x => vowels.Contains(x));
        }
    }
}
