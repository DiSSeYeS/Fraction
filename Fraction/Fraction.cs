using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FractionClass
{
    public class Fraction
    {
        private Int64 numerator;
        private Int64 denominator;

        public Fraction(Int64 numerator, Int64 denominator)
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

            for (Int64 i = denominator; i >= 2; i--)
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
        public Fraction(Fraction numerator, Fraction denominator) : this(numerator / denominator)
        {
        }
        public Fraction(Fraction numerator, Int64 denominator) : this(numerator, new Fraction(denominator))
        {
        }
        public Fraction(Int64 numerator, Fraction denominator) : this(new Fraction(numerator), denominator)
        {
        }
        public Fraction(double num, Fraction fraction) : this(new Fraction(num) / fraction)
        {
        }
        public Fraction(Fraction fraction, double num) : this(fraction / new Fraction(num))
        {
        }
        public Fraction(double a, double b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(double a, Int64 b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(Int64 a, double b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(decimal num, Fraction fraction) : this(new Fraction(num) / fraction)
        {
        }
        public Fraction(Fraction fraction, decimal num) : this(fraction / new Fraction(num))
        {
        }
        public Fraction(decimal a, decimal b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(decimal a, Int64 b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(Int64 a, decimal b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(float num, Fraction fraction) : this(new Fraction(num) / fraction)
        {
        }
        public Fraction(Fraction fraction, float num) : this(fraction / new Fraction(num))
        {
        }
        public Fraction(float a, float b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(float a, Int64 b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(Int64 a, float b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(Int64 num) : this(ConvertDoubleToFraction((double)num).Item1, ConvertDoubleToFraction((double)num).Item2)
        {
        }
        public Fraction(double num) : this(ConvertDoubleToFraction(num).Item1, ConvertDoubleToFraction(num).Item2)
        {  
        }
        public Fraction(decimal num) : this(ConvertDoubleToFraction((double)num).Item1, ConvertDoubleToFraction((double)num).Item2)
        {
        }
        public Fraction(float num) : this(ConvertDoubleToFraction((double)num).Item1, ConvertDoubleToFraction((double)num).Item2)
        {
        }
        private static Tuple<Int64, Int64> ConvertDoubleToFraction(double num)
        {
            if (num % 1 == 0)
            {
                return Tuple.Create((Int64)num, (Int64)1);
            }

            Int64 integerBeforePoint = Int64.Parse(num.ToString().Split(",").First().Replace("-", ""));
            Int64 integerAfterPoint = Int64.Parse(num.ToString().Split(",").Last());
            int countOfDigitsAfterPoint = num.ToString().Split(",").Last().Length;
            Int64 denominator = (Int64)Math.Pow(10, countOfDigitsAfterPoint);

            return Tuple.Create(integerBeforePoint * denominator + integerAfterPoint, denominator);
        }
        public static implicit operator Fraction(Int64 numerator) => new Fraction(numerator);
        public static implicit operator Fraction(double numerator) => new Fraction(numerator);
        public static implicit operator Fraction(float numerator) => new Fraction(numerator);
        public static implicit operator Fraction(decimal numerator) => new Fraction(numerator);
        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a.denominator == b.denominator)
            {
                return new Fraction(a.numerator + b.numerator, a.denominator);
            }

            return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
        }
        public static Fraction operator +(Fraction a, Int64 b) => new Fraction(a.numerator + a.denominator * b, a.denominator);
        public static Fraction operator +(Fraction a, double b) => a + new Fraction(b);
        public static Fraction operator +(Fraction a, decimal b) => a + new Fraction(b);
        public static Fraction operator +(Fraction a, float b) => a + new Fraction(b);
        public static Fraction operator +(Int64 a, Fraction b) => b + a;
        public static Fraction operator +(double a, Fraction b) => b + a;
        public static Fraction operator +(decimal a, Fraction b) => b + a;
        public static Fraction operator +(float a, Fraction b) => b + a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator -(Fraction a, Int64 b) => a + (-b);
        public static Fraction operator -(Fraction a, double b) => a + (-b);
        public static Fraction operator -(Fraction a, decimal b) => a + (-b);
        public static Fraction operator -(Fraction a, float b) => a + (-b);
        public static Fraction operator -(Int64 a, Fraction b) => (-b) + a;
        public static Fraction operator -(double a, Fraction b) => (-b) + a;
        public static Fraction operator -(decimal a, Fraction b) => (-b) + a;
        public static Fraction operator -(float a, Fraction b) => (-b) + a;
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        public static Fraction operator *(Fraction a, Int64 b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(Fraction a, double b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(Fraction a, decimal b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(Fraction a, float b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(Int64 a, Fraction b) => b * a;
        public static Fraction operator *(double a, Fraction b) => b * a;
        public static Fraction operator *(decimal a, Fraction b) => b * a;
        public static Fraction operator *(float a, Fraction b) => b * a;
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        public static Fraction operator /(Fraction a, Int64 b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(Fraction a, double b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(Fraction a, decimal b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(Fraction a, float b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(Int64 a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static Fraction operator /(double a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static Fraction operator /(decimal a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static Fraction operator /(float a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static bool operator ==(Fraction a, Fraction b) => a.RealValue == b.RealValue;
        public static bool operator ==(Fraction a, Int64 b) => a.RealValue == b;
        public static bool operator ==(Fraction a, double b) => a.RealValue == b;
        public static bool operator ==(Fraction a, float b) => a.RealValue == b;
        public static bool operator ==(Fraction a, decimal b) => a.RealValue == (double)b;
        public static bool operator ==(Int64 a, Fraction b) => b == a;
        public static bool operator ==(double a, Fraction b) => b == a;
        public static bool operator ==(float a, Fraction b) => b == a;
        public static bool operator ==(decimal a, Fraction b) => b == a;
        public static bool operator !=(Fraction a, Fraction b) => a.RealValue != b.RealValue;
        public static bool operator !=(Fraction a, Int64 b) => a.RealValue != b;
        public static bool operator !=(Fraction a, double b) => a.RealValue != b;
        public static bool operator !=(Fraction a, float b) => a.RealValue != b;
        public static bool operator !=(Fraction a, decimal b) => a.RealValue != (double)b;
        public static bool operator !=(Int64 a, Fraction b) => b != a;
        public static bool operator !=(double a, Fraction b) => b != a;
        public static bool operator !=(float a, Fraction b) => b != a;
        public static bool operator !=(decimal a, Fraction b) => b != a;
        public static bool operator >(Fraction a, Fraction b) => a.RealValue > b.RealValue;
        public static bool operator >(Fraction a, Int64 b) => a.RealValue > b;
        public static bool operator >(Fraction a, double b) => a.RealValue > b;
        public static bool operator >(Fraction a, float b) => a.RealValue > b;
        public static bool operator >(Fraction a, decimal b) => a.RealValue > (double)b;
        public static bool operator >(Int64 a, Fraction b) => b < a;
        public static bool operator >(double a, Fraction b) => b < a;
        public static bool operator >(float a, Fraction b) => b < a;
        public static bool operator >(decimal a, Fraction b) => b < a;
        public static bool operator <(Fraction a, Fraction b) => a.RealValue < b.RealValue;
        public static bool operator <(Fraction a, Int64 b) => a.RealValue < b;
        public static bool operator <(Fraction a, double b) => a.RealValue < b;
        public static bool operator <(Fraction a, float b) => a.RealValue < b;
        public static bool operator <(Fraction a, decimal b) => a.RealValue < (double)b;
        public static bool operator <(Int64 a, Fraction b) => b > a;
        public static bool operator <(double a, Fraction b) => b > a;
        public static bool operator <(float a, Fraction b) => b > a;
        public static bool operator <(decimal a, Fraction b) => b > a;
        public Fraction Pow(Int64 power)
        {
            Fraction newFraction = new Fraction(this.numerator, this.denominator);

            for (Int64 i = 0; i < power - 1; i++)
            {
                newFraction.numerator *= this.numerator;
                newFraction.denominator *= this.denominator;
            }

            return newFraction;
        }

        public double GetRealValue() => (double)this.numerator / (double)this.denominator;
        private double RealValue => (double)this.numerator / (double)this.denominator;
        public override string ToString()
        {
            bool isNegative = numerator < 0;
            string sign = isNegative ? "-" : "";

            if (Math.Abs(numerator) % denominator == 0)
            {
                return $"{sign}{Math.Abs(numerator) / Math.Abs(denominator)}";
            }

            Int64 displayedNumerator = Math.Abs(numerator);
            Int64 displayedDenominator = denominator;
            int integers = 0;

            while (displayedNumerator > displayedDenominator)
            {
                displayedNumerator -= displayedDenominator;
                integers++;
            }
            
            return integers > 0 ? $"{sign}{integers}({displayedNumerator}/{displayedDenominator})" : $"{sign}{displayedNumerator}/{displayedDenominator}";
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
