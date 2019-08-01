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

        [Fact]
        public void SimplifiesFraction_Test()
        {
            var fraction = new Fraction(2, 4);
            var expectedNumerator = 1;
            var expectedDenominator = 2;

            var result = fraction.Simplify();

            Assert.Equal(expectedNumerator, result.Numerator);
            Assert.Equal(expectedDenominator, result.Denominator);
        }

        [Fact]
        public void ReturnsSameFractionIfAlreadySimplified_Test()
        {
            var fraction = new Fraction(1, 2);
            var expectedNumerator = 1;
            var expectedDenominator = 2;

            var result = fraction.Simplify();

            Assert.Equal(expectedNumerator, result.Numerator);
            Assert.Equal(expectedDenominator, result.Denominator);
        }

        [Fact]
        public void CalculatesGreatestCommonFactor_Test()
        {
            var a = 10;
            var b = 5;
            var expected = 5;

            var result = Fraction.FindGreatestCommonFactor(a, b);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DifferentFractionsAreEqualToEachOther_Test()
        {
            var fraction1 = new Fraction(5, 10);
            var fraction2 = new Fraction(1, 2);

            var result = fraction1.Equals(fraction2);

            Assert.True(result);
        }

        [Fact]
        public void DifferentFractionsAreNotEqualToEachOther_Test()
        {
            var fraction1 = new Fraction(5, 10);
            var fraction2 = new Fraction(3, 4);

            var result = fraction1.Equals(fraction2);

            Assert.False(result);
        }

        [Fact]
        public void FractionsWithOverloadedEqualsOperatorEqualToEachOther_Test()
        {
            var fraction1 = new Fraction(5, 10);
            var fraction2 = new Fraction(1, 2);

            var result = fraction1 == fraction2;

            Assert.True(result);
        }

        [Fact]
        public void CanMultiplyFractions_Test()
        {
            var fraction1 = new Fraction(1, 2);
            var fraction2 = new Fraction(1, 2);
            var expectedFraction = new Fraction(1, 4);

            var result = fraction1 * fraction2;

            Assert.Equal(expectedFraction, result);
        }

        [Fact]
        public void CanMultiplyFractionsThenSimply_Test()
        {
            var fraction1 = new Fraction(1, 2);
            var fraction2 = new Fraction(2, 3);
            var expectedFraction = new Fraction(1, 3);

            var result = (fraction1 * fraction2).Simplify();

            Assert.Equal(expectedFraction, result);
        }

        private int SumOfWholeNumbers(int index)
        {
            return index;
        }
    }
}
