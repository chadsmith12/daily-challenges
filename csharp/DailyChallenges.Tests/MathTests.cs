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

        [Fact]
        public void CreatesNewFractionSetsNumerator_Test()
        {
            // Arrange
            var numerator = 5;
            var denominator = 10;

            // Act
            var fraction = new Fraction(numerator, denominator);

            // Assert
            Assert.Equal(numerator, fraction.Numerator);
        }

        [Fact]
        public void CreatesNewFractionSetsDenominator_Test()
        {
            // Arrange
            var numerator = 5;
            var denominator = 10;

            // Act
            var fraction = new Fraction(numerator, denominator);

            // Assert
            Assert.Equal(denominator, fraction.Denominator);
        }

        [Fact]
        public void ThrowsArgumentExceptionOnZeroDenominator()
        {
            // Arrange
            var numerator = 5;
            var denominator = 0;
            var expectedMessage = "Denominator can not be zero";

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new Fraction(numerator, denominator));

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void AddsFractionsWithCommonDenominators_Test()
        {
            // Arrange
            var lhs = new Fraction(5, 10);
            var rhs = new Fraction(2, 10);
            var expectedNumerator = 7;

            // Act
            var result = lhs + rhs;

            // Assert
            Assert.Equal(expectedNumerator, result.Numerator);
            Assert.Equal(10, result.Denominator);
        }

        [Fact]
        public void AddsFractionsWithoutCommonDenominators_Test()
        {
            // Arrange
            var lhs = new Fraction(1, 2);
            var rhs = new Fraction(2, 3);
            var expectedNumerator = 7;
            var expectedDenominator = 6;

            // Act
            var result = lhs + rhs;

            // Assert
            Assert.Equal(expectedNumerator, result.Numerator);
            Assert.Equal(expectedDenominator, result.Denominator);
        }

        [Fact]
        public void SubtractsFractionsWithCommonDenominators_Test()
        {
            // Arrange
            var lhs = new Fraction(5, 10);
            var rhs = new Fraction(2, 10);
            var expectedNumerator = 7;
            var expectedDenominator = 10;

            // Act
            var result = lhs + rhs;

            // Assert
            Assert.Equal(expectedNumerator, result.Numerator);
            Assert.Equal(expectedDenominator, result.Denominator);
        }

        [Fact]
        public void SubtractsFractionsWithoutCommonDenominators_Test()
        {
            // Arrange
            var lhs = new Fraction(1, 2);
            var rhs = new Fraction(2, 3);
            var expectedNumerator = -1;
            var expectedDenominator = 6;

            // Act
            var result = lhs - rhs;

            // Assert
            Assert.Equal(expectedNumerator, result.Numerator);
            Assert.Equal(expectedDenominator, result.Denominator);
        }

        [Fact]
        public void FindsCommonDenominatorBetweenFractions_Test()
        {
            // Arrange
            var lhs = new Fraction(1, 2);
            var rhs = new Fraction(2, 3);
            var expectedDenominator = 6;

            // Act
            int result = Fraction.FindCommonDenominator(lhs, rhs);

            // Assert
            Assert.Equal(expectedDenominator, result);
        }

        private int SumOfWholeNumbers(int index)
        {
            return index;
        }
    }
}
