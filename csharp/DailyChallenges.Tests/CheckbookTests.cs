using System;
using Xunit;
using DailyChallengesLib.Checkbook;

namespace DailyChallenges.Tests
{
    public class CheckbookTests
    {
        [Fact]
        public void CalculatesAverageExpenses_Test()
        {
            // Arrange
            var testCase = "500.00\n" +
                           "1 Market 10.00\n" +
                           "2 Hardware 20.00";
            var expected = 15d;

            // Act
            var checkbook = new Checkbook(testCase);
            var actual = checkbook.AverageExpenses;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatesTotalExpenses_Test()
        {
            // Arrange
            var testCase = "500.00\n" +
                           "1 Market 10.00\n" +
                           "2 Hardware 20.00";
            var expected = 30d;

            // Act
            var checkbook = new Checkbook(testCase);
            var actual = checkbook.TotalExpenses;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
