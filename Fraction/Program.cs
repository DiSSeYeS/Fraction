using System.Linq;

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

            Console.WriteLine(new Fraction(3));
        }
    }
}