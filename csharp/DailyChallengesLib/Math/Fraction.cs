using System;
namespace DailyChallengesLib.Math
{
    public struct Fraction
    {
        /// <summary>
        /// Initializes a new fraction with the numerator and denominator.
        /// Throws an ArgumentException if the denominator is zero.
        /// </summary>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">The denomiator of the fraction.</param>
        public Fraction(int numerator, int denominator)
        {
            if(denominator == 0)
            {
                throw new ArgumentException("Denominator can not be zero");
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Unary + operator for a fraction.
        /// </summary>
        /// <param name="a">The fraction on the rhs.</param>
        /// <returns>Original fraction.</returns>
        public static Fraction operator +(Fraction a)
        {
            return a;
        }

        /// <summary>
        /// Unary - operator for a fraction.
        /// </summary>
        /// <param name="a">The fraction on the rhs.</param>
        /// <returns>OFraction negated.</returns>
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }

        /// <summary>
        /// Adds two fractions together.
        /// </summary>
        /// <param name="a">left side of the operation.</param>
        /// <param name="b">right side of the operation.</param>
        /// <returns>A new fraction, unsimplified, of a+b.</returns>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction sum;
            // we don't have a common denominator
            // get a common denominator by multplying a * b denominator and b *  a denominator
            if(a.Denominator != b.Denominator)
            {
                var leftNumerator = a.Numerator * b.Denominator;
                var leftDenominator = a.Denominator * b.Denominator;
                var rightNumerator = b.Numerator * a.Denominator;
                sum = AddFraction(leftNumerator, rightNumerator, leftDenominator);
            }
            else
            {
                sum = AddFraction(a.Numerator, b.Numerator, a.Denominator);
            }

            return sum;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction difference;
            // we don't have a common denominator
            // get a common denominator by multplying a * b denominator and b *  a denominator
            if (a.Denominator != b.Denominator)
            {
                var leftNumerator = a.Numerator * b.Denominator;
                var commonDenomiator = FindCommonDenominator(a, b);
                var rightNumerator = b.Numerator * a.Denominator;
                difference = SubtractFraction(leftNumerator, rightNumerator, commonDenomiator);
            }
            else
            {
                difference = SubtractFraction(a.Numerator, b.Numerator, a.Denominator);
            }

            return difference;
        }
        /// <summary>
        /// Returns a common denominator between two fractions.
        /// </summary>
        /// <param name="a">left hand fraction.</param>
        /// <param name="b">right hand fraction.</param>
        /// <returns>Common denomiator between fraction a and b.</returns>
        public static int FindCommonDenominator(Fraction a, Fraction b)
        {
            return a.Denominator * b.Denominator;
        }

        /// <summary>
        /// The numerator of the fraction.
        /// </summary>
        public int Numerator { get; }

        /// <summary>
        /// The denominator of the fraction.
        /// </summary>
        public int Denominator { get; }

        /// <summary>
        /// The approximated value of a fraction as a decimal.
        /// </summary>
        public double ApproximatedValue => Numerator / Denominator;

        /// <summary>
        /// The string representation of a fraction.
        /// Prints out "Numerator / Denominator"
        /// </summary>
        /// <returns>string representation of the fraction.</returns>
        public override string ToString()
        {
            return $"{Numerator} / {Denominator}";
        }

        private static Fraction AddFraction(int aNumerator, int bNumerator, int commonDenominator)
        {
            return new Fraction(aNumerator + bNumerator, commonDenominator);
        }

        private static Fraction SubtractFraction(int aNumerator, int bNumerator, int commonDenominator)
        {
            return new Fraction(aNumerator - bNumerator, commonDenominator);
        }
    }
}
