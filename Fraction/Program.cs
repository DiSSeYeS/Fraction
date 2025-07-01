using System.Linq;
using System.Numerics;

namespace FractionClass
{
    public class Program()
    {
        public static void Main()
        {
            Fraction fraction1 = new Fraction(4, 5);
            Fraction fraction2 = new Fraction(2, 11);
            Fraction fraction3 = new Fraction(-5, 4);
            Fraction fraction4 = new Fraction(fraction1, 1.31);

            Console.WriteLine($"{fraction1} x {fraction3} = {fraction1 * fraction3}");
            Console.WriteLine($"{fraction2} + {fraction4} = {fraction2 + fraction4}");
            Console.WriteLine($"{fraction4} / {fraction3} = {fraction4 / fraction3}");
            Console.WriteLine($"{fraction3} x {fraction2} = {fraction3 * fraction2}");
            Console.WriteLine($"(({fraction3})^3)^3 = {fraction3.Pow(3).Pow(3)}");
            Console.WriteLine($"{fraction4} - {fraction1} = {fraction4 - fraction1}");
            Console.WriteLine($"{fraction3} - {fraction3} = {fraction3 - fraction3}");
            Console.WriteLine($"(({fraction2}) / ({fraction1})) * {fraction4} = {new Fraction(fraction2, fraction1) * fraction4}");
            Console.WriteLine($"{fraction1} / {fraction4} = {fraction1 / fraction4}");

            Console.WriteLine(new Fraction(4, new Fraction(2,1) ));
            Console.WriteLine(new Fraction(2,1));
            Console.WriteLine(new Fraction(0.5,0.5));

            Console.WriteLine(fraction4.Pow(9).GetRealValue());
            Console.WriteLine(fraction4.Pow(9));

            Console.WriteLine(fraction1 > fraction2);
            Console.WriteLine(fraction1.GetRealValue() + " " + fraction2.GetRealValue());

            Console.WriteLine(new Fraction(1.0,0.331).GetRealValue() == new Fraction(1.0000001,0.331).GetRealValue());

            Console.WriteLine(0.25.GetHashCode() + " " + new Fraction(1,4).GetHashCode());
            Console.WriteLine(new Fraction(1,4).GetRealValue().Equals(0.24));

            Console.WriteLine(new Fraction(0.5, (Int128)1));

            Console.WriteLine(new Fraction(Fraction.Parse("1/2"), Fraction.Parse("0.33")));
            Console.WriteLine(new Fraction(1) * new Fraction(0.33, Fraction.Parse("1")));
        }
    }
}