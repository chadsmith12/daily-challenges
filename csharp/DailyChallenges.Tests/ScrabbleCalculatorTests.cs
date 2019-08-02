using Xunit;
using DailyChallengesLib.ScrabbleCalculator;

namespace DailyChallenges.Tests
{
    public class ScrabbleCalculatorTests
    {
        [Fact]
        public void CalculatesRegularWords_Test()
        {
            var word = "Hello";
            var expected = 11;
            var calculator = new ScrabbleWordCalculator();

            var score = calculator.CalculateScore(word);

            Assert.Equal(expected, score);
        }

        [Fact]
        public void CalculatesDoubleLetters_Test()
        {
            var word = "He*llo";
            var expected = 12;
            var calculator = new ScrabbleWordCalculator();

            var score = calculator.CalculateScore(word);

            Assert.Equal(expected, score);
        }

        [Fact]
        public void CalculatesTripleLetters_Test()
        {
            var word = "He**llo";
            var expected = 13;
            var calculator = new ScrabbleWordCalculator();

            var score = calculator.CalculateScore(word);

            Assert.Equal(expected, score);
        }

        [Fact]
        public void Calculates7LetterWordBonus_Test()
        {
            var word = "Triathlete";
            var expected = 64;
            var calculator = new ScrabbleWordCalculator();

            var score = calculator.CalculateScore(word);

            Assert.Equal(expected, score);
        }

        [Fact]
        public void CalculatesBlankLetters_Test()
        {
            var word = "He^llo";
            var expected = 10;
            var calculator = new ScrabbleWordCalculator();

            var score = calculator.CalculateScore(word);

            Assert.Equal(expected, score);
        }
    }
}
