# C# Challenges
These are the daily challenges solved using C#. All of the challenges that are done in C# will be listed at the top of this README with links to the original challenge

1. [String Peeler](https://dev.to/thepracticaldev/daily-challenge-1-string-peeler-4nep)
2. [String Diamond](https://dev.to/thepracticaldev/daily-challenge-2-string-diamond-21n2)
3. [Vowel Counter](https://dev.to/thepracticaldev/daily-challenge-3-vowel-counter-34ni)
4. [Checkbook Balancing](https://dev.to/thepracticaldev/daily-challenge-4-checkbook-balancing-hei)
5. [Walk Generator](https://dev.to/thepracticaldev/daily-challenge-5-ten-minute-walk-1188)
8. [Scrabble Word Calculator](https://dev.to/thepracticaldev/daily-challenge-8-scrabble-word-calculator-41f6)

## How Challenges Broken Up
There will be one solution with at least one class library that will hold the different functions for the challenges. There will also be a XUnit Test project that will provide the Unit Tests for the solutions.

### DailyChallengesLib
This is a class library that holds all the functions to the daily challenges.

### DailyChallenges.Tests
This is an XUnit Test Project that provides the UnitTests for the solutions. It has a reference to the  `DailyChallengesLib`  project and will unit tests all the solutions.

### Running Tests
To run the tests to check all the solutions, just run `dotnet test` from the root solution directory.