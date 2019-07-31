using System;

namespace DailyChallengesLib.Math
{
    public static class MathHelper
    {
        /// <summary>
        /// Preforms a summation from start to end, preforming the action on each pass.
        /// </summary>
        /// <param name="start">Where the start the summation from. Should be less than <paramref name="end"/>.</param>
        /// <param name="end">Where the summation ends at. Should be greater than <paramref name="start"/>.</param>
        /// <param name="action">The action to preform during each pass in the summation. Passes in the current index.</param>
        /// <returns>The sum of action preformed.</returns>
        public static int Summation(int start, int end, Func<int, int> action)
        {
            CheckForValidArguments(start, end);

            var sum = 0;

            for(var i = start; i <= end; i++)
            {
                sum += action(i);
            }

            return sum;
        }

        /// <summary>
        /// Checks to see if a series will be convergent based off the r value.
        /// A series will converge if r is between -1 and 1.
        /// </summary>
        /// <param name="r">The r value to check.</param>
        /// <returns>True if it converges; otherwise, false.</returns>
        public static bool IsSeriesConvergent(double r)
        {
            return (r > -1 && r < 1);
        }

        private static void CheckForValidArguments(int start, int end)
        {
            if(start > end)
            {
                throw new ArgumentException("Make sure start is before end.");
            }
        }
    }
}
