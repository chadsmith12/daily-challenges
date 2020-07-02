using Xunit;
using DailyChallengesLib.SecondLargest;

namespace DailyChallenges.Tests
{
    public class SecondLargestTests
    {
        [Fact]
        public void FindsSecondLargest_Test()
        {
            var array = new int[] { -1, 10, 8, 9, 10, 9, -8, 11 };
            var findSecondLargest = new SecondLargest();

            var secondLargest = findSecondLargest.Find2ndLargest(array);
            var expected = 10;

            Assert.Equal(expected, secondLargest);
        }

        [Fact]
        public void WorksWithSingleElementArray_Test()
        {
            var array = new int[] { 1 };
            var findSecondLargest = new SecondLargest();

            var secondLargest = findSecondLargest.Find2ndLargest(array);
            var expected = int.MinValue + 1;

            Assert.Equal(expected, secondLargest);
        }

        [Fact]
        public void WorksWithEmptyArray_Test()
        {
            var array = new int[0];
            var findSecondLargest = new SecondLargest();

            var secondLargest = findSecondLargest.Find2ndLargest(array);
            var expected = int.MinValue;

            Assert.Equal(expected, secondLargest);
        }
    }
}