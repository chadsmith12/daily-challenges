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
    }
}
