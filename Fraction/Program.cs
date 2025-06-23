using System.Linq;

namespace Fraction
{
    public class Program()
    {
        public static void Main()
        {
            Fraction fraction1 = new Fraction(4, 5);
            Fraction fraction2 = new Fraction(2, 11);

            Console.WriteLine($"{fraction1} x {fraction2} = {fraction1 * fraction2}");

            Console.WriteLine(Fraction.Pow(fraction1, 5));

            int a = 4;

            Fraction fraction3 = new Fraction(
                (int)(15 * Math.Pow(Math.Pow(a, 1.0 / 28.0),1.0 / 5.0) - 7 * Math.Pow(Math.Pow(a, 1.0 / 20.0), 1.0 / 7.0)),
                (int)(2 * Math.Pow(Math.Pow(a, 1.0 / 4.0), 1.0 / 35.0)));

            Console.WriteLine(fraction3);

            Fraction fraction4 = new Fraction(fraction1, fraction2);

            Console.WriteLine(fraction4);

            Console.WriteLine(4 + fraction4);
        }
    }
}