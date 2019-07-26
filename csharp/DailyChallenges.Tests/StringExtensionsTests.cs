using System;
using Xunit;
using DailyChallengesLib.StringExtensions;

namespace DailyChallenges.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void RemovesPunctuationFromString_Test()
        {
            // Arrange
            var testCase = "This, is, a, random, test, that has differnet punctuation?";
            var expectedResult = "This is a random test that has differnet punctuation";

            // Act
            var result = testCase.RemoveSymbols();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void RemovesSymbolsFromString_Test()
        {
            // Arrange
            var testCase = "This^ is a te$t";
            var expectedResult = "This is a tet";

            // Act
            var result = testCase.RemoveSymbols();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void WorksWithNormalString_Test()
        {
            // Arrange
            var testCase = "Hello World";
            var expectedResult = "Hello World";

            // Act
            var result = testCase.RemoveSymbols();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void WorksWithMultiLineString_Test()
        {
            // Arrange
            var testCase = "Hello\nWorld";
            var expectedResult = "Hello\nWorld";

            // Act
            var result = testCase.RemoveSymbols();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
