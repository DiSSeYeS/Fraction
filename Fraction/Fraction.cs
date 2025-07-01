using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FractionClass
{
    public class Fraction
    {
        private Int128 numerator;
        private Int128 denominator;

        public Fraction(Int128 numerator, Int128 denominator)
        {
            if (denominator == 0 && numerator != 0)
            {
                throw new DivideByZeroException("The denominator can not be zero.");
            }

            bool isNegative = (numerator < 0 || denominator < 0) && !(numerator < 0 && denominator < 0);

            if (isNegative)
            {
                numerator = Int128.Abs(numerator);
                denominator = Int128.Abs(denominator);
            }

            Int128 divider = GCD(numerator, denominator);

            numerator /= divider;
            denominator /= divider;

            this.numerator = numerator * (isNegative ? -1 : 1);
            this.denominator = denominator;
        }
        private static Int128 GCD(Int128 a, Int128 b)
        {
            while (b != 0)
            {
                Int128 temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public Fraction(int numerator, int denominator) : this((Int128)numerator, (Int128)denominator)
        {
        }
        public Fraction(int numerator, Fraction denominator) : this((Int128)numerator, denominator)
        {
        }
        public Fraction(Fraction numerator, int denominator) : this(numerator, (Int128)denominator)
        {
        }
        public Fraction(int numerator, double denominator) : this((Int128)numerator, new Fraction(denominator))
        {
        }
        public Fraction(double numerator, int denominator) : this(new Fraction(numerator), (Int128)denominator)
        {
        }
        public Fraction(int numerator, float denominator) : this((Int128)numerator, new Fraction(denominator))
        {
        }
        public Fraction(float numerator, int denominator) : this(new Fraction(numerator), (Int128)denominator)
        {
        }
        public Fraction(int numerator, decimal denominator) : this((Int128)numerator, new Fraction(denominator))
        {
        }
        public Fraction(decimal numerator, int denominator) : this(new Fraction(numerator), (Int128)denominator)
        {
        }
        public Fraction(int numerator, Int128 denominator) : this((Int128)numerator, denominator)
        {
        }
        public Fraction(Int128 numerator, int denominator) : this(numerator, (Int128)denominator)
        {
        }
        public Fraction(int numerator, Int64 denominator) : this((Int128)numerator, (Int128)denominator)
        {
        }
        public Fraction(Int64 numerator, int denominator) : this((Int128)numerator, (Int128)denominator)
        {
        }
        public Fraction(Int64 numerator, Int64 denominator) : this((Int128)numerator, (Int128)denominator)
        {
        }
        public Fraction(Int64 numerator, Fraction denominator) : this((Int128)numerator, denominator)
        {
        }
        public Fraction(Fraction numerator, Int64 denominator) : this(numerator, (Int128)denominator)
        {
        }
        public Fraction(Int64 numerator, double denominator) : this((Int128)numerator, new Fraction(denominator))
        {
        }
        public Fraction(double numerator, Int64 denominator) : this(new Fraction(numerator), (Int128)denominator)
        {
        }
        public Fraction(Int64 numerator, float denominator) : this((Int128)numerator, new Fraction(denominator))
        {
        }
        public Fraction(float numerator, Int64 denominator) : this(new Fraction(numerator), (Int128)denominator)
        {
        }
        public Fraction(Int64 numerator, decimal denominator) : this((Int128)numerator, new Fraction(denominator))
        {
        }
        public Fraction(decimal numerator, Int64 denominator) : this(new Fraction(numerator), (Int128)denominator)
        {
        }
        public Fraction(Int64 numerator, Int128 denominator) : this((Int128)numerator, denominator)
        {
        }
        public Fraction(Int128 numerator, Int64 denominator) : this(numerator, (Int128)denominator)
        {
        }
        public Fraction(Fraction fraction) : this(fraction.numerator, fraction.denominator)
        {
        }
        public Fraction(Fraction numerator, Fraction denominator) : this(numerator / denominator)
        {
        }
        public Fraction(Fraction numerator, Int128 denominator) : this(numerator, new Fraction(denominator))
        {
        }
        public Fraction(Int128 numerator, Fraction denominator) : this(new Fraction(numerator), denominator)
        {
        }
        public Fraction(double num, Fraction fraction) : this(new Fraction(num), fraction)
        {
        }
        public Fraction(Fraction fraction, double num) : this(fraction / new Fraction(num))
        {
        }
        public Fraction(double a, double b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(double a, Int128 b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(Int128 a, double b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(decimal num, Fraction fraction) : this(new Fraction(num), fraction)
        {
        }
        public Fraction(Fraction fraction, decimal num) : this(fraction, new Fraction(num))
        {
        }
        public Fraction(decimal a, decimal b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(decimal a, Int128 b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(Int128 a, decimal b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(float num, Fraction fraction) : this(new Fraction(num), fraction)
        {
        }
        public Fraction(Fraction fraction, float num) : this(fraction, new Fraction(num))
        {
        }
        public Fraction(float a, float b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(float a, Int128 b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(Int128 a, float b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(int num) : this((Int128)num)
        {
        }
        public Fraction(Int128 num) : this(ConvertDoubleToFraction((double)num).Item1, ConvertDoubleToFraction((double)num).Item2)
        {
        }
        public Fraction(Int64 num) : this((Int128)num)
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
        private static Tuple<Int128, Int128> ConvertDoubleToFraction(double num)
        {
            if (num % 1 == 0)
            {
                return Tuple.Create((Int128)num, (Int128)1);
            }

            Int128 integerBeforePoint = Int128.Parse(num.ToString().Replace(".", ",").Split(",").First().Replace("-", ""));
            Int128 integerAfterPoint = Int128.Parse(num.ToString().Replace(".", ",").Split(",").Last());
            int countOfDigitsAfterPoint = num.ToString().Split(",").Last().Length;
            Int128 denominator = (Int128)Math.Pow(10, countOfDigitsAfterPoint);

            return Tuple.Create(integerBeforePoint * denominator + integerAfterPoint, denominator);
        }
        public static implicit operator Fraction(Int128 numerator) => new Fraction(numerator);
        public static implicit operator Fraction(Int64 numerator) => new Fraction((Int128)numerator);
        public static implicit operator Fraction(int numerator) => new Fraction((Int128)numerator);
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
        public static Fraction operator +(Fraction a, Int128 b) => new Fraction(a.numerator + a.denominator * b, a.denominator);
        public static Fraction operator +(Fraction a, double b) => a + new Fraction(b);
        public static Fraction operator +(Fraction a, decimal b) => a + new Fraction(b);
        public static Fraction operator +(Fraction a, float b) => a + new Fraction(b);
        public static Fraction operator +(Int128 a, Fraction b) => b + a;
        public static Fraction operator +(double a, Fraction b) => b + a;
        public static Fraction operator +(decimal a, Fraction b) => b + a;
        public static Fraction operator +(float a, Fraction b) => b + a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator -(Fraction a, Int128 b) => a + (-b);
        public static Fraction operator -(Fraction a, double b) => a + (-b);
        public static Fraction operator -(Fraction a, decimal b) => a + (-b);
        public static Fraction operator -(Fraction a, float b) => a + (-b);
        public static Fraction operator -(Int128 a, Fraction b) => (-b) + a;
        public static Fraction operator -(double a, Fraction b) => (-b) + a;
        public static Fraction operator -(decimal a, Fraction b) => (-b) + a;
        public static Fraction operator -(float a, Fraction b) => (-b) + a;
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        public static Fraction operator *(Fraction a, Int128 b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(Fraction a, double b) => new Fraction(a.numerator * new Fraction(b), a.denominator);
        public static Fraction operator *(Fraction a, decimal b) => new Fraction(a.numerator * new Fraction(b), a.denominator);
        public static Fraction operator *(Fraction a, float b) => new Fraction(a.numerator * new Fraction(b), a.denominator);
        public static Fraction operator *(Int128 a, Fraction b) => b * a;
        public static Fraction operator *(double a, Fraction b) => b * a;
        public static Fraction operator *(decimal a, Fraction b) => b * a;
        public static Fraction operator *(float a, Fraction b) => b * a;
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        public static Fraction operator /(Fraction a, Int128 b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(Fraction a, double b) => new Fraction(a.numerator, a.denominator * new Fraction(b));
        public static Fraction operator /(Fraction a, decimal b) => new Fraction(a.numerator, a.denominator * new Fraction(b));
        public static Fraction operator /(Fraction a, float b) => new Fraction(a.numerator, a.denominator * new Fraction(b));
        public static Fraction operator /(Int128 a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static Fraction operator /(double a, Fraction b) => new Fraction(new Fraction(a) * b.denominator, b.numerator);
        public static Fraction operator /(decimal a, Fraction b) => new Fraction(new Fraction(a) * b.denominator, b.numerator);
        public static Fraction operator /(float a, Fraction b) => new Fraction(new Fraction(a) * b.denominator, b.numerator);
        public static bool operator ==(Fraction a, Fraction b) => a.RealValue == b.RealValue;
        public static bool operator ==(Fraction a, Int128 b) => a.RealValue == new Fraction(b).RealValue;
        public static bool operator ==(Fraction a, double b) => a.RealValue == b;
        public static bool operator ==(Fraction a, float b) => a.RealValue == b;
        public static bool operator ==(Fraction a, decimal b) => a.RealValue == (double)b;
        public static bool operator ==(Int128 a, Fraction b) => b == a;
        public static bool operator ==(double a, Fraction b) => b == a;
        public static bool operator ==(float a, Fraction b) => b == a;
        public static bool operator ==(decimal a, Fraction b) => b == a;
        public static bool operator !=(Fraction a, Fraction b) => a.RealValue != b.RealValue;
        public static bool operator !=(Fraction a, Int128 b) => a.RealValue != new Fraction(b);
        public static bool operator !=(Fraction a, double b) => a.RealValue != b;
        public static bool operator !=(Fraction a, float b) => a.RealValue != b;
        public static bool operator !=(Fraction a, decimal b) => a.RealValue != (double)b;
        public static bool operator !=(Int128 a, Fraction b) => b != a;
        public static bool operator !=(double a, Fraction b) => b != a;
        public static bool operator !=(float a, Fraction b) => b != a;
        public static bool operator !=(decimal a, Fraction b) => b != a;
        public static bool operator >(Fraction a, Fraction b) => a.RealValue > b.RealValue;
        public static bool operator >(Fraction a, Int128 b) => a.RealValue > new Fraction(b);
        public static bool operator >(Fraction a, double b) => a.RealValue > b;
        public static bool operator >(Fraction a, float b) => a.RealValue > b;
        public static bool operator >(Fraction a, decimal b) => a.RealValue > (double)b;
        public static bool operator >(Int128 a, Fraction b) => b < a;
        public static bool operator >(double a, Fraction b) => b < a;
        public static bool operator >(float a, Fraction b) => b < a;
        public static bool operator >(decimal a, Fraction b) => b < a;
        public static bool operator <(Fraction a, Fraction b) => a.RealValue < b.RealValue;
        public static bool operator <(Fraction a, Int128 b) => a.RealValue < new Fraction(b);
        public static bool operator <(Fraction a, double b) => a.RealValue < b;
        public static bool operator <(Fraction a, float b) => a.RealValue < b;
        public static bool operator <(Fraction a, decimal b) => a.RealValue < (double)b;
        public static bool operator <(Int128 a, Fraction b) => b > a;
        public static bool operator <(double a, Fraction b) => b > a;
        public static bool operator <(float a, Fraction b) => b > a;
        public static bool operator <(decimal a, Fraction b) => b > a;
        public Fraction Pow(int power)
        {
            if (numerator == 0 && power < 0)
                throw new DivideByZeroException("Impossible to raise zero to a negative power.");

            if (power == 0)
                return new Fraction((Int128)1, (Int128)1);

            if (power > 0)
            {
                return new Fraction(
                    (Int128)BigInteger.Pow(numerator, power),
                    (Int128)BigInteger.Pow(denominator, power)
                );
            }
            else
            {
                return new Fraction(
                    (Int128)BigInteger.Pow(denominator, -power),
                    (Int128)BigInteger.Pow(numerator, -power)
                );
            }
        }

        private double RealValue => (double)this.numerator / (double)this.denominator;
        public double GetRealValue() => (double)this.numerator / (double)this.denominator;
        public bool IsNegative() => Int128.IsNegative(numerator);
        public bool IsEvenInteger() => this.RealValue % 2 == 0;
        public bool IsOddInteger() => !this.IsEvenInteger();
        public static Fraction Parse(int number) => new Fraction(number);
        public static Fraction Parse(Int128 number) => new Fraction(number);
        public static Fraction Parse(Int64 number) => new Fraction(number);
        public static Fraction Parse(double number) => new Fraction(number);
        public static Fraction Parse(decimal number) => new Fraction(number);
        public static Fraction Parse(float number) => new Fraction(number);
        public static Fraction Parse(string fraction)
        {
            try
            {
                if (fraction.Contains("/"))
                {
                    string[] splittedString = fraction.Split("/");
                    Tuple<Int128, Int128> fractionTuple = Tuple.Create(Int128.Parse(splittedString[0]), Int128.Parse(splittedString[1]));

                    return new Fraction(fractionTuple.Item1, fractionTuple.Item2);
                }
                else
                {
                    return new Fraction(double.Parse(fraction.Replace(".", ",")));
                }
            }
            catch
            {
                throw new Exception("Impossible to parse string.");
            }
        }
        public override string ToString()
        {
            bool isNegative = numerator < 0;
            string sign = isNegative ? "-" : "";

            if (Int128.Abs(numerator) % denominator == 0)
            {
                return $"{sign}{Int128.Abs(numerator) / Int128.Abs(denominator)}";
            }

            Int128 displayedNumerator = Int128.Abs(numerator);
            Int128 displayedDenominator = denominator;
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
            return this.RealValue.GetHashCode();
        }
    }
}
