using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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

            bool isNegative = (numerator < 0 || denominator < 0) && !(numerator < 0 && denominator < 0);

            if (isNegative)
            {
                numerator = Math.Abs(numerator);
                denominator = Math.Abs(denominator);
            }

            for (int i = denominator; i >= 2; i--)
            {
                if (denominator % i == 0 && numerator % i == 0)
                {
                    denominator /= i;
                    numerator /= i;
                }
            }

            this.numerator = numerator * (isNegative ? -1 : 1);
            this.denominator = denominator;
        }
        public Fraction(Fraction fraction) : this(fraction.numerator, fraction.denominator)
        {
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
        public Fraction(double num, Fraction fraction) : this(ConvertDoubleToFraction(num).Item1 * fraction.denominator, ConvertDoubleToFraction(num).Item2 * fraction.numerator)
        {
        }
        public Fraction(Fraction fraction, double num) : this(fraction.numerator * ConvertDoubleToFraction(num).Item2, fraction.denominator * ConvertDoubleToFraction(num).Item1)
        {
        }
        public Fraction(double a, double b) : this(ConvertDoubleToFraction(a).Item1 * ConvertDoubleToFraction(b).Item2, ConvertDoubleToFraction(b).Item2 * ConvertDoubleToFraction(a).Item1)
        {
        }
        public Fraction(double a, int b) : this(ConvertDoubleToFraction(a).Item1, ConvertDoubleToFraction(a).Item2 * b)
        {
        }
        public Fraction(int a, double b) : this(a * ConvertDoubleToFraction(b).Item1, ConvertDoubleToFraction(b).Item2)
        {
        }
        public Fraction(decimal num, Fraction fraction) : this(ConvertDecimalToFraction(num).Item1 * fraction.denominator, ConvertDecimalToFraction(num).Item2 * fraction.numerator)
        {
        }
        public Fraction(Fraction fraction, decimal num) : this(fraction.numerator * ConvertDecimalToFraction(num).Item2, fraction.denominator * ConvertDecimalToFraction(num).Item1)
        {
        }
        public Fraction(decimal a, decimal b) : this(ConvertDecimalToFraction(a).Item1 * ConvertDecimalToFraction(b).Item2, ConvertDecimalToFraction(b).Item2 * ConvertDecimalToFraction(a).Item1)
        {
        }
        public Fraction(decimal a, int b) : this(ConvertDecimalToFraction(a).Item1, ConvertDecimalToFraction(a).Item2 * b)
        {
        }
        public Fraction(int a, decimal b) : this(a * ConvertDecimalToFraction(b).Item1, ConvertDecimalToFraction(b).Item2)
        {
        }
        public Fraction(float num, Fraction fraction) : this(ConvertFloatToFraction(num).Item1 * fraction.denominator, ConvertFloatToFraction(num).Item2 * fraction.numerator)
        {
        }
        public Fraction(Fraction fraction, float num) : this(fraction.numerator * ConvertFloatToFraction(num).Item2, fraction.denominator * ConvertFloatToFraction(num).Item1)
        {
        }
        public Fraction(float a, float b) : this(ConvertFloatToFraction(a).Item1 * ConvertFloatToFraction(b).Item2, ConvertFloatToFraction(b).Item2 * ConvertFloatToFraction(a).Item1)
        {
        }
        public Fraction(float a, int b) : this(ConvertFloatToFraction(a).Item1, ConvertFloatToFraction(a).Item2 * b)
        {
        }
        public Fraction(int a, float b) : this(a * ConvertFloatToFraction(b).Item1, ConvertFloatToFraction(b).Item2)
        {
        }
        public Fraction(double num) : this(ConvertDoubleToFraction(num).Item1, ConvertDoubleToFraction(num).Item2)
        {  
        }
        public Fraction(decimal num) : this(ConvertDecimalToFraction(num).Item1, ConvertDecimalToFraction(num).Item2)
        {
        }
        public Fraction(float num) : this(ConvertFloatToFraction(num).Item1, ConvertFloatToFraction(num).Item2)
        {
        }
        private static Tuple<int, int> ConvertDoubleToFraction(double num)
        {
            int numberBeforePoint = int.Parse(num.ToString().Split(",").First().Replace("-",""));
            int numberAfterPoint = int.Parse(num.ToString().Split(",").Last());
            int countOfDigitsAfterPoint = num.ToString().Split(",").Last().Length;
            int denominator = (int)Math.Pow(10, countOfDigitsAfterPoint);

            return Tuple.Create(numberBeforePoint * denominator + numberAfterPoint, denominator);
        }

        private static Tuple<int, int> ConvertFloatToFraction(float num)
        {
            int numberBeforePoint = int.Parse(num.ToString().Split(",").First().Replace("-", ""));
            int numberAfterPoint = int.Parse(num.ToString().Split(",").Last());
            int countOfDigitsAfterPoint = num.ToString().Split(",").Last().Length;
            int denominator = (int)Math.Pow(10, countOfDigitsAfterPoint);

            return Tuple.Create(numberBeforePoint * denominator + numberAfterPoint, denominator);
        }
        private static Tuple<int, int> ConvertDecimalToFraction(decimal num)
        {
            int numberBeforePoint = int.Parse(num.ToString().Split(",").First().Replace("-", ""));
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
        public static Fraction operator +(Fraction a, double b) => a + new Fraction(b);
        public static Fraction operator +(Fraction a, decimal b) => a + new Fraction(b);
        public static Fraction operator +(Fraction a, float b) => a + new Fraction(b);
        public static Fraction operator +(int a, Fraction b) => b + a;
        public static Fraction operator +(double a, Fraction b) => b + a;
        public static Fraction operator +(decimal a, Fraction b) => b + a;
        public static Fraction operator +(float a, Fraction b) => b + a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator -(Fraction a, int b) => a + (-b);
        public static Fraction operator -(Fraction a, double b) => a + (-b);
        public static Fraction operator -(Fraction a, decimal b) => a + (-b);
        public static Fraction operator -(Fraction a, float b) => a + (-b);
        public static Fraction operator -(int a, Fraction b) => (-b) + a;
        public static Fraction operator -(double a, Fraction b) => (-b) + a;
        public static Fraction operator -(decimal a, Fraction b) => (-b) + a;
        public static Fraction operator -(float a, Fraction b) => (-b) + a;
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        public static Fraction operator *(Fraction a, int b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(Fraction a, double b) => a * new Fraction(b);
        public static Fraction operator *(Fraction a, decimal b) => a * new Fraction(b);
        public static Fraction operator *(Fraction a, float b) => a * new Fraction(b);
        public static Fraction operator *(int a, Fraction b) => b * a;
        public static Fraction operator *(double a, Fraction b) => b * a;
        public static Fraction operator *(decimal a, Fraction b) => b * a;
        public static Fraction operator *(float a, Fraction b) => b * a;
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        public static Fraction operator /(Fraction a, int b) => a * new Fraction(1, b);
        public static Fraction operator /(Fraction a, double b) => a * new Fraction(1,b);
        public static Fraction operator /(Fraction a, decimal b) => a * new Fraction(1, b);
        public static Fraction operator /(Fraction a, float b) => a * new Fraction(1, b);
        public static Fraction operator /(int a, Fraction b) => b / a;
        public static Fraction operator /(double a, Fraction b) => b / a;
        public static Fraction operator /(decimal a, Fraction b) => b / a;
        public static Fraction operator /(float a, Fraction b) => b / a;
        public Fraction Pow(int power)
        {
            Fraction oldFraction = new Fraction(this.numerator, this.denominator);

            for (int i = 0; i < power - 1; i++)
            {
                this.numerator *= oldFraction.numerator;
                this.denominator *= oldFraction.denominator;
            }

            return this;
        }

        public override string ToString()
        {
            bool isNegative = numerator < 0;
            string sign = isNegative ? "-" : "";

            /*
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
            */

            if (Math.Abs(numerator) % Math.Abs(denominator) == 0)
            {
                return $"{sign}{Math.Abs(numerator) / Math.Abs(denominator)}";
            }

            return $"{numerator}/{denominator}";

        }
    }
}
