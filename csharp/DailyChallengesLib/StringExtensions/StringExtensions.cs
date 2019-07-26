using System;
using System.Text;

namespace DailyChallengesLib.StringExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method that removes all symbols and punctuation from the string.
        /// </summary>
        /// <param name="value">The string to remove the symbols and punctuation from.</param>
        /// <returns>New string sanitized with symbols and punctuation removed.</returns>
        public static string RemoveSymbols(this string value)
        {
            var builder = new StringBuilder();

            // loop over each character and see if it's a symbol or punctuation
            foreach(var character in value)
            {
                if(!char.IsPunctuation(character) && !char.IsSymbol(character))
                {
                    builder.Append(character);
                }
            }

            return builder.ToString();
        }
    }
}
