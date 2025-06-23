using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Fraction
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0 && numerator != 0)
            {
                throw new Exception("The denominator can not be zero.");
            }

            if (numerator == 0)
            {
                this.numerator = 0;
                this.denominator = 0;
                return;
            }

            for (int i = denominator; i >= 2; i--)
            {
                if (denominator % i == 0 && numerator % i == 0)
                {
                    denominator /= i;
                    numerator /= i;
                }
            }

            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction(Fraction numerator, Fraction denominator) : this((numerator / denominator).numerator, (numerator / denominator).denominator)
        {
        }
        public Fraction(Fraction numerator, int denominator) : this((numerator / denominator).numerator, (numerator / denominator).denominator)
        {
        }
        public Fraction(int numerator, Fraction denominator) : this((numerator / denominator).numerator, (numerator / denominator).denominator)
        {
        }
        public Fraction(double num) : this(ConvertDoubleToFraction(num).Item1, ConvertDoubleToFraction(num).Item2)
        {  
        }
        public Fraction(decimal num) : this(ConvertDecimalToFraction(num).Item1, ConvertDecimalToFraction(num).Item2)
        {
        }

        private static Tuple<int, int> ConvertDoubleToFraction(double num)
        {
            int numberBeforePoint = int.Parse(num.ToString().Split(",").First());
            int numberAfterPoint = int.Parse(num.ToString().Split(",").Last());
            int countOfDigitsAfterPoint = num.ToString().Split(",").Last().Length;
            int denominator = (int)Math.Pow(10, countOfDigitsAfterPoint);

            return Tuple.Create(numberBeforePoint * denominator + numberAfterPoint, denominator);
        }
        private static Tuple<int, int> ConvertDecimalToFraction(decimal num)
        {
            int numberBeforePoint = int.Parse(num.ToString().Split(",").First());
            int numberAfterPoint = int.Parse(num.ToString().Split(",").Last());
            int countOfDigitsAfterPoint = num.ToString().Split(",").Last().Length;
            int denominator = (int)Math.Pow(10, countOfDigitsAfterPoint);

            return Tuple.Create(numberBeforePoint * denominator + numberAfterPoint, denominator);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a.denominator == b.denominator)
            {
                return new Fraction(a.numerator + b.numerator, a.denominator);
            }

            return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
        }
        public static Fraction operator +(Fraction a, int b) => new Fraction(a.numerator + a.denominator * b, a.denominator);
        public static Fraction operator +(int a, Fraction b) => b + a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator -(Fraction a, int b) => a + (-b);
        public static Fraction operator -(int a, Fraction b) => (-b) + a;
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        public static Fraction operator *(Fraction a, int b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(int a, Fraction b) => b * a;
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        public static Fraction operator /(Fraction a, int b) => a * new Fraction(1, b);
        public static Fraction operator /(int a, Fraction b) => new Fraction(a * b.numerator, b.denominator);
        public static Fraction Pow(Fraction fraction, int power)
        {
            Fraction oldFraction = new Fraction(fraction.numerator, fraction.denominator);

            for (int i = 0; i < power - 1; i++)
            {
                fraction *= oldFraction;
            }

            return new Fraction(fraction.numerator, fraction.denominator);
        }

        public override string ToString()
        {
            int integers = 0;

            while (numerator >= denominator)
            {
                numerator -= denominator;
                integers++;
            }

            if (integers == 0)
            {
                return $"{numerator}/{denominator}";
            }
            if (numerator == 0)
            {
                return integers.ToString();
            }
            return $"{integers}({numerator}/{denominator})";
        }
    }
}
