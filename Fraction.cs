using System;

namespace Fractions
{
    public struct Fraction
    {
        public int denominator;
        public int numerator;

        public Fraction(int _numerator, int _denominator)
        {
            this.denominator = _denominator;
            this.numerator = _numerator;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction c = new Fraction(0, 0);

            for(int i = 2; true; i++)
            {
                if (i % a.denominator == 0 && i % b.denominator == 0)
                {
                    a.numerator *= i / a.denominator;
                    a.denominator = i;

                    b.numerator *= i / b.denominator;
                    b.denominator = i;

                    c.denominator = a.denominator;
                    c.numerator = a.numerator + b.numerator;

                    break;
                }
            }

            return Fraction.Reduce(c);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction c = new Fraction(0, 0);

            for(int i = 2; true; i++)
            {
                if (i % a.denominator == 0 && i % b.denominator == 0)
                {
                    a.numerator *= i / a.denominator;
                    a.denominator = i;

                    b.numerator *= i / b.denominator;
                    b.denominator = i;

                    c.denominator = a.denominator;
                    c.numerator = a.numerator - b.numerator;

                    break;
                }
            }

            return Fraction.Reduce(c);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return Fraction.Reduce(new Fraction(a.numerator * b.numerator, a.denominator * b.denominator));
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            b = Fraction.Reverse(b);
            return Fraction.Reduce(new Fraction(a.numerator * b.numerator, a.denominator * b.denominator));
        }

        private static Fraction Reduce(Fraction a)
        {
            for(int i = 2; i <= a.denominator; i++)
            {
                if (a.denominator % i == 0 && a.numerator % i == 0)
                {
                    a.denominator /= i;
                    a.numerator /= i;
                    
                    i = 1;
                }
            }

            return a;
        }

        public static Fraction Reverse(Fraction a)
        {
            return new Fraction(a.denominator, a.numerator);
        }

        public void Print()
        {
            Console.WriteLine(this.numerator + " / " + this.denominator);
        }
    }
}