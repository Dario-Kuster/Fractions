using System;

namespace Fractions
{
    public struct Fraction
    {
        public int Denominator { get; set; }
        public int Numerator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Denominator = denominator;
            Numerator = numerator;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction c = new Fraction(0, 0);
            int commmonDenominator = FindCommonDenominator(a, b);

            a.Numerator *= commmonDenominator / a.Denominator;
            a.Denominator = commmonDenominator;

            b.Numerator *= commmonDenominator / b.Denominator;
            b.Denominator = commmonDenominator;

            c.Denominator = a.Denominator;
            c.Numerator = a.Numerator + b.Numerator;

            c.Reduce();
            return c;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction c = new Fraction(0, 0);
            int commmonDenominator = FindCommonDenominator(a, b);

            a.Numerator *= commmonDenominator / a.Denominator;
            a.Denominator = commmonDenominator;

            b.Numerator *= commmonDenominator / b.Denominator;
            b.Denominator = commmonDenominator;

            c.Denominator = a.Denominator;
            c.Numerator = a.Numerator - b.Numerator;

            c.Reduce();
            return c;
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction c = new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            c.Reduce();
            
            return c;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            b.Reverse();
            Fraction c = new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            c.Reduce();

            return c;
        }

        public static int FindCommonDenominator(Fraction a, Fraction b)
        {
            for(int i = 2; true; i++)
            {
                if (i % a.Denominator == 0 && i % b.Denominator == 0)
                {
                    return i;
                }
            }
        }

        public void Reduce()
        {
            for(int i = 2; i <= Denominator; i++)
            {
                if (Denominator % i == 0 && Numerator % i == 0)
                {
                    Denominator /= i;
                    Numerator /= i;
                    
                    i = 1;
                }
            }
        }

        public void Reverse()
        {
            int temp = Denominator;
            Denominator = Numerator;
            Numerator = temp;
        }

        public void Print()
        {
            Console.WriteLine(Numerator + " / " + Denominator);
        }
    }
}
