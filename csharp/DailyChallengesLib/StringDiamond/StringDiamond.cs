using System;
using System.Text;

namespace DailyChallengesLib.StringDiamond
{
    public class StringDiamond
    {
        /// <summary>
        /// Creates a diamond out of "*".
        /// Will return a null if <paramref name="number"/> is even or negative.
        /// </summary>
        /// <param name="number">The number of asterics to make for the middle line.
        /// This should not be negative or even.
        /// </param>
        /// <returns>Returns a diamond made out of "*"
        /// Will return null if <paramref name="number"/> is even or negative.
        /// </returns>
        public string MakeDiamond(int number)
        {
            // if the number input is even or negative we can't create the diamond
            if(IsEven(number) || number < 0)
            {
                return null;
            }

            var midPointIndex = number / 2;
            var result = new StringBuilder();

            for(var i = 0; i < number; i++)
            {
                // number of spaces to do:
                /*       *
                 *      ***
                 *     *****
                 *      ***
                 *       *
                 */
                var numberSpaces = System.Math.Abs(i - midPointIndex);
                var numberStars = number - numberSpaces * 2;
                var spacesLine = BuildLine(' ', numberSpaces);
                var starsLine = BuildLine('*', numberStars);
                result.AppendFormat("{0}{1}{0}\n", spacesLine, starsLine);
            }

            return result.ToString();
        }

        private bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private string BuildLine(char charToAdd, int number)
        {
            var lineBuilder = new StringBuilder();
            for(var i = 0; i < number; i++)
            {
                lineBuilder.Append(charToAdd);
            }

            return lineBuilder.ToString();
        }
    }
}
