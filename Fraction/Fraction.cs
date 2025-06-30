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
        public Fraction(Fraction numerator, Fraction denominator) : this(numerator / denominator)
        {
        }
        public Fraction(Fraction numerator, int denominator) : this(numerator, new Fraction(denominator))
        {
        }
        public Fraction(int numerator, Fraction denominator) : this(new Fraction(numerator), denominator)
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
        public Fraction(double a, int b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(int a, double b) : this(new Fraction(a), new Fraction(b))
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
        public Fraction(decimal a, int b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(int a, decimal b) : this(new Fraction(a), new Fraction(b))
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
        public Fraction(float a, int b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(int a, float b) : this(new Fraction(a), new Fraction(b))
        {
        }
        public Fraction(int num) : this(ConvertDoubleToFraction((double)num).Item1, ConvertDoubleToFraction((double)num).Item2)
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
        private static Tuple<int, int> ConvertDoubleToFraction(double num)
        {
            if (num % 1 == 0)
            {
                return Tuple.Create((int)num, 1);
            }

            int numberBeforePoint = int.Parse(num.ToString().Split(",").First().Replace("-", ""));
            int numberAfterPoint = int.Parse(num.ToString().Split(",").Last());
            int countOfDigitsAfterPoint = num.ToString().Split(",").Last().Length;
            int denominator = (int)Math.Pow(10, countOfDigitsAfterPoint);

            return Tuple.Create(numberBeforePoint * denominator + numberAfterPoint, denominator);
        }
        public static implicit operator Fraction(int numerator) => new Fraction(numerator);
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
        public static Fraction operator *(Fraction a, double b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(Fraction a, decimal b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(Fraction a, float b) => new Fraction(a.numerator * b, a.denominator);
        public static Fraction operator *(int a, Fraction b) => b * a;
        public static Fraction operator *(double a, Fraction b) => b * a;
        public static Fraction operator *(decimal a, Fraction b) => b * a;
        public static Fraction operator *(float a, Fraction b) => b * a;
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        public static Fraction operator /(Fraction a, int b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(Fraction a, double b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(Fraction a, decimal b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(Fraction a, float b) => new Fraction(a.numerator, a.denominator * b);
        public static Fraction operator /(int a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static Fraction operator /(double a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static Fraction operator /(decimal a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static Fraction operator /(float a, Fraction b) => new Fraction(a * b.denominator, b.numerator);
        public static bool operator ==(Fraction a, Fraction b) => a.RealValue == b.RealValue;
        public static bool operator ==(Fraction a, int b) => a.RealValue == b;
        public static bool operator ==(Fraction a, double b) => a.RealValue == b;
        public static bool operator ==(Fraction a, float b) => a.RealValue == b;
        public static bool operator ==(Fraction a, decimal b) => a.RealValue == (double)b;
        public static bool operator ==(int a, Fraction b) => b == a;
        public static bool operator ==(double a, Fraction b) => b == a;
        public static bool operator ==(float a, Fraction b) => b == a;
        public static bool operator ==(decimal a, Fraction b) => b == a;
        public static bool operator !=(Fraction a, Fraction b) => a.RealValue != b.RealValue;
        public static bool operator !=(Fraction a, int b) => a.RealValue != b;
        public static bool operator !=(Fraction a, double b) => a.RealValue != b;
        public static bool operator !=(Fraction a, float b) => a.RealValue != b;
        public static bool operator !=(Fraction a, decimal b) => a.RealValue != (double)b;
        public static bool operator !=(int a, Fraction b) => b != a;
        public static bool operator !=(double a, Fraction b) => b != a;
        public static bool operator !=(float a, Fraction b) => b != a;
        public static bool operator !=(decimal a, Fraction b) => b != a;
        public static bool operator >(Fraction a, Fraction b) => a.RealValue > b.RealValue;
        public static bool operator >(Fraction a, int b) => a.RealValue > b;
        public static bool operator >(Fraction a, double b) => a.RealValue > b;
        public static bool operator >(Fraction a, float b) => a.RealValue > b;
        public static bool operator >(Fraction a, decimal b) => a.RealValue > (double)b;
        public static bool operator >(int a, Fraction b) => b < a;
        public static bool operator >(double a, Fraction b) => b < a;
        public static bool operator >(float a, Fraction b) => b < a;
        public static bool operator >(decimal a, Fraction b) => b < a;
        public static bool operator <(Fraction a, Fraction b) => a.RealValue < b.RealValue;
        public static bool operator <(Fraction a, int b) => a.RealValue < b;
        public static bool operator <(Fraction a, double b) => a.RealValue < b;
        public static bool operator <(Fraction a, float b) => a.RealValue < b;
        public static bool operator <(Fraction a, decimal b) => a.RealValue < (double)b;
        public static bool operator <(int a, Fraction b) => b > a;
        public static bool operator <(double a, Fraction b) => b > a;
        public static bool operator <(float a, Fraction b) => b > a;
        public static bool operator <(decimal a, Fraction b) => b > a;
        public Fraction Pow(int power)
        {
            Fraction newFraction = new Fraction(this.numerator, this.denominator);

            for (int i = 0; i < power - 1; i++)
            {
                newFraction.numerator *= this.numerator;
                newFraction.denominator *= this.denominator;
            }

            return newFraction;
        }

        private double GetRealValue() => this.numerator / this.denominator;
        private double RealValue => this.numerator / this.denominator;
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
