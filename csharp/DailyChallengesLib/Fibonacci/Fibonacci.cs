namespace DailyChallengesLib.Fibonacci
{
    public static class Fibonacci
    {
        public static bool IsInFibonacciSequence(int searchValue, int number1 = 0, int number2 = 1)
        {
            var nextSequence = number1 + number2;

            if(nextSequence == searchValue)
            {
                return true;
            }
            if(nextSequence > searchValue)
            {
                return false;
            }

            return IsInFibonacciSequence(searchValue, number2, nextSequence);
        }
    }
}
