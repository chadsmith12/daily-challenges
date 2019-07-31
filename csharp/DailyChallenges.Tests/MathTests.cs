using System;
using Xunit;
using DailyChallengesLib.Math;

namespace DailyChallenges.Tests
{
    public class MathTests
    {
        [Fact]
        public void CorrectlySumsAllIntegers_Test()
        {
            // Arrange
            var testCase = 5050;

            // Act
            var result = MathHelper.Summation(1, 100, SumOfWholeNumbers);

            // Assert
            Assert.Equal(testCase, result);

        }

        [Fact]
        public void ThrowsExceptionWithStartGreaterThanEnd_Test()
        {
            var expectedMessage = "Make sure start is before end.";

            var result = Assert.Throws<ArgumentException>(() => MathHelper.Summation(100, 1, SumOfWholeNumbers));

            Assert.Equal(expectedMessage, result.Message);
        }

        [Fact]
        public void ReturnsTrueIfSeriesConverges_Test()
        {
            // Act
            var result = MathHelper.IsSeriesConvergent(0.01);

            // Assert
            Assert.True(result);
        }

        private int SumOfWholeNumbers(int index)
        {
            return index;
        }
    }
}
