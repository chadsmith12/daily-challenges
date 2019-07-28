using System;
using Xunit;
using DailyChallengesLib.WalkGenerator;

namespace DailyChallenges.Tests
{
    public class WalkGeneratorTests
    {
        [Fact]
        public void DoesNotAllowOddNumberMinutes_Test()
        {
            // Arrange
            var generator = new WalkGenerator();
            var numberMinutes = 5;
            var exceptedError = "must be an even number";

            var exception = Assert.Throws<ArgumentException>(()  => generator.GenerateRandomWalk(numberMinutes));

            Assert.Contains(exceptedError, exception.Message);
        }

        [Fact]
        public void WalksNumberMinutesSpecified_Test()
        {
            // Arrange
            var generator = new WalkGenerator();
            var testCase = 4;

            // Act
            var walk = generator.GenerateRandomWalk(testCase);

            // Assert
            Assert.Equal(testCase, walk.Length);
        }
    }
}
