using System;
namespace DailyChallengesLib.Math
{
    public readonly struct Fraction : IEquatable<Fraction>
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
        /// Multiples two fractions together.
        /// </summary>
        /// <param name="a">lhs of the operation.</param>
        /// <param name="b">rhs of the operation.</param>
        /// <returns>A new fraction, unsimnplified, of a*b</returns>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
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
        /// Overloads the == operator to check if two fractions are equal.
        /// See <see cref="Equals(Fraction)"/> on if two fractions are equal to each other.
        /// </summary>
        /// <param name="a">Fraction on lhs.</param>
        /// <param name="b">Fraction on rhs.</param>
        /// <returns>True if the fractions are equal; otherwise, false.</returns>
        public static bool operator ==(Fraction a, Fraction b)
        {
            return Equals(a, b);
        }

        /// <summary>
        /// Overloads the != operator to check if the two fractions are not equal.
        /// </summary>
        /// <param name="a">Fraction on lhs.</param>
        /// <param name="b">Fraction on rhs.</param>
        /// <returns>True if the fractions are not equal; otherwise, false.</returns>
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !Equals(a, b);
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
        /// Finds the greatest common factor between two numbers using Euclidean algorithm.
        /// </summary>
        /// <param name="a">Factor a.</param>
        /// <param name="b">Factor b.</param>
        /// <returns>The greatest common factor between two numbers.</returns>
        public static int FindGreatestCommonFactor(int a, int b)
        {
            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;

            // while we we haven't reached zero yet.
            while(a != 0 && b != 0)
            {
                if(a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a == 0 ? b : a;
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
        /// The approximated value of a fraction.
        /// </summary>
        public double ApproximatedValue => Numerator / Denominator;

        /// <summary>
        /// Calculates the greatest common divisor of the fraction and returns the fraction fully simplified.
        /// </summary>
        /// <returns>The fraction fully simplified.</returns>
        public Fraction Simplify()
        {
            var gcd = FindGreatestCommonFactor(Numerator, Denominator);
            var numerator = Numerator / gcd;
            var denominator = Denominator / gcd;

            return new Fraction(numerator, denominator);
        }

        /// <summary>
        /// Gets the reciprocal form of this fraction.
        /// </summary>
        /// <returns>A new fraction in  the reciprocal form.</returns>
        public Fraction Reciprocal()
        {
            return new Fraction(Denominator, Numerator);
        }

        public double ToDouble()
        {
            return ApproximatedValue;
        }

        public decimal ToDecimal()
        {
            return Numerator / (decimal)Denominator;
        }

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

        /// <summary>
        /// Compares that two fractions are equal to each other.
        /// Two fractions are equal to each other if they evaluate to the same number
        /// </summary>
        /// <example>Example: 2 / 4 == 1 / 2</example>
        /// <param name="other">The other fraction to compare too.</param>
        /// <returns>True if the fractions are equal; otherwise, false.</returns>
        public bool Equals(Fraction other)
        {
            return other.ToDecimal() == ToDecimal();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            return obj is Fraction fraction && Equals(fraction);
        }

        public override int GetHashCode()
        {
            return unchecked(Denominator.GetHashCode() * 397) ^ Numerator.GetHashCode();
        }
    }
}
