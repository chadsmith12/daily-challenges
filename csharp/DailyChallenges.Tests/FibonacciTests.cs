using Xunit;
using DailyChallengesLib.Fibonacci;

namespace DailyChallenges.Tests
{
    public class FibonacciTests
    {
        [Fact]
        public void NumberIsInFibonacciSequence_Test()
        {
            var testCase = 5;
            var expected = true;

            var actual = Fibonacci.IsInFibonacciSequence(testCase);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NumberIsNotInFibonacciSequence_Test()
        {
            var testCase = 7;
            var expected = false;

            var actual = Fibonacci.IsInFibonacciSequence(testCase);

            Assert.Equal(expected, actual);
        }
    }
}
