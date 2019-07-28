using System;
namespace DailyChallengesLib.RandomExtensions
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Uses the random number generator to shuffle an array in place.
        /// uses a modern version of the Fisher-Yate shuffle algorithm.
        /// </summary>
        /// <typeparam name="T">The type of the array we need to shuffle.</typeparam>
        /// <param name="random">Random number generator.</param>
        /// <param name="array">The array we are to shuffle.</param>
        public static void Shuffle<T>(this Random random, T[] array)
        {
            // loop through the entire array, from back to front
            for(var i = array.Length - 1; i > 0; i--)
            {
                var randomIndex = random.Next(0, i);
                //  exchange array[i] with array[randomIndex]
                var temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }
    }
}
