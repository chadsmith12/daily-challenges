using Xunit;
using DailyChallengesLib.StringPeeler;

namespace DailyChallenges.Tests
{
    public class StringPeelerTests
    {
        private readonly StringPeeler _stringPeeler;

        public StringPeelerTests()
        {
            _stringPeeler = new StringPeeler();
        }

        [Fact]
        public void RemoveFirstAndLastCharacter_Test()
        {
            // Arrange
            var expected = "ello worl";
            var testCase = "hello world";

            // Act
            var result = _stringPeeler.RemoveFirstAndLast(testCase);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TwoCharacterStringDoesNotRemoveCharacters_Test()
        {
            // Arrange
            var expected = "aa";
            var testCase = "aa";

            // Act
            var result = _stringPeeler.RemoveFirstAndLast(testCase);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
