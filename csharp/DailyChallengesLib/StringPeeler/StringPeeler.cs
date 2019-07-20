using System;

namespace DailyChallengesLib.StringPeeler
{
    public class StringPeeler
    {
        /// <summary>
        /// Removes the first and last character of a string.
        /// If <paramref name="value"/> is 2 characters or less, then gives the original string back.
        /// </summary>
        /// <param name="value">The string to remove the first and last characters from.</param>
        /// <returns>A new string with the characters removed.
        /// or the original string, if 2 characters or less.
        /// </returns>
        public string RemoveFirstAndLast(string value)
        {
            // if the string is 2 characters or less we should just return the same string back
            if(value.Length <= 2)
            {
                return value;
            }

            var lastIndex = value.Length - 1;

            return value.Substring(1, lastIndex - 1);
        }
    }
}