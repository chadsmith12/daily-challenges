using System;
using System.Collections.Generic;
using DailyChallengesLib.RandomExtensions;

namespace DailyChallengesLib.WalkGenerator
{
    public class WalkGenerator
    {
        private static readonly char[] WalkDirections = { 'N', 'S', 'E', 'W' };

        /// <summary>
        /// Generates a random walk that will return you to your starting position.
        /// It takes one minute to walk in direction/block.
        /// </summary>
        /// <param name="numberMinutes">
        /// The total number of minutes to walk.
        /// This must be an even number of minutes.
        /// </param>
        /// <returns>Array of directions that you can walk to make sure you always get back to where you started.</returns>
        public char[] GenerateRandomWalk(int numberMinutes)
        {
            var walk = new List<char>(numberMinutes);

            // we have to make sure this is an even number of minutes
            if(numberMinutes % 2 !=  0)
            {
                throw new ArgumentException($"{nameof(numberMinutes)} must be an even number.");
            }

            // choose a random direction
            var random = new Random();
            while(walk.Count < numberMinutes)
            {
                var index = random.Next(WalkDirections.Length);
                walk.Add(WalkDirections[index]);
                walk.Add(GetCounterDirection(WalkDirections[index]));
            }

            var walkArray = walk.ToArray();
            random.Shuffle(walkArray);

            return walkArray;
        }

        private char GetCounterDirection(char direction)
        {
            switch(direction)
            {
                case 'N':
                    return 'S';
                case 'S':
                    return 'N';
                case 'E':
                    return 'W';
                case 'W':
                    return 'E';
                default:
                    throw new ArgumentException($"{nameof(direction)} must be a valid direction of N, E, S, or W");
            }
        }
    }
}
