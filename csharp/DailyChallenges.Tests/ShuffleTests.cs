using System;
using Xunit;
using DailyChallengesLib.RandomExtensions;

namespace DailyChallenges.Tests
{
    public class ShuffleTests
    {
        [Fact]
        public void ShufflesArray_Test()
        {
            var random = new Random(20);
            var array = new int[] { 1, 2, 3, 4 };

            random.Shuffle(array);

            Assert.Equal(new[] { 3, 4, 2, 1 }, array);
        }
    }
}
