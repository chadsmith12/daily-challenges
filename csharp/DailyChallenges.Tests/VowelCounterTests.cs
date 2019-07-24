using System;
using DailyChallengesLib.VowelCounter;
using Xunit;

namespace DailyChallenges.Tests
{
    public class VowelCounterTests
    {
        private readonly VowelCounter _vowelCounter;

        public VowelCounterTests()
        {
            _vowelCounter = new VowelCounter();
        }

        [Fact]
        public void CountsVowelsInLowerCaseString_Test()
        {
            // Arrange
            var test = "aeiou";
            var expected = 5;

            // Act
            var result = _vowelCounter.CountVowels(test);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountsVowelsInUperCaseString_Test()
        {
            // Arrange
            var test = "AEIOU";
            var expected = 5;

            // Act
            var result = _vowelCounter.CountVowels(test);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountsVowelsWithMixedString_Test()
        {
            // Arrange
            var test = "this is a test";
            var expected = 4;

            // Act
            var result = _vowelCounter.CountVowels(test);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
