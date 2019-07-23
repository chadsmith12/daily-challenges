using DailyChallengesLib.StringDiamond;
using Xunit;

namespace DailyChallenges.Tests
{
    public class StringDiamondTests
    {
        private readonly StringDiamond _stringDiamond;

        public StringDiamondTests()
        {
            _stringDiamond = new StringDiamond();
        }

        [Fact]
        public void StringDiamondReturnNullIfEven_Test()
        {
            // Arrange
            var input = 2;

            // Act
            var result = _stringDiamond.MakeDiamond(input);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void StringDiamondReturnNullIfNegative_Test()
        {
            // Arrange
            var input = -2;

            // Act
            var result = _stringDiamond.MakeDiamond(input);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void StringDiamondMakesDiamond_Test()
        {
            // Arrange
            var input = 5;
            var expected = "  *  \n" +
                " *** \n" +
                "*****\n" +
                " *** \n" +
                "  *  \n";

            // Act
            var result = _stringDiamond.MakeDiamond(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
