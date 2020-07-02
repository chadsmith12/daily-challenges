namespace DailyChallengesLib.SecondLargest
{
    public class SecondLargest
    {
        public int Find2ndLargest(int[] arr)
        {
            var firstMax = int.MinValue + 1;
            var secondMax = int.MinValue;

            foreach (var number in arr)
            {
                if (number > firstMax)
                {
                    secondMax = firstMax;
                    firstMax = number;
                }
                else if (number > secondMax)
                {
                    secondMax = number;
                }
            }

            return secondMax;
        }
    }
}