using System;

namespace csharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // Trims the first and last characters from the original string.
        public string RemoveFirstAndLast(string originalString)
        {
            // return the original string if the length is not more than 2 characters in length
            if(originalString.Length <= 2)
            {
                return originalString;
            }
        }
    }
}
