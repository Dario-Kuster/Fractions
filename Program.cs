using System;

namespace Fractions
{
    class Program
    {
        static void Main()
        {
            string _operator = "";
            Fraction a = new Fraction(0, 0);
            Fraction b = new Fraction(0, 0);
            Fraction result = new Fraction(0, 0);

            while (true)
            {
                try
                {
                    Console.Write("Enter numerator: ");
                    a.numerator = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter denominator: ");
                    a.denominator = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter operator: ");
                    _operator = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Enter second numerator: ");
                    b.numerator = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter second denominator: ");
                    b.denominator = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Console.Clear();

                    continue;
                }

                switch (_operator)
                {
                    case "+":
                        result = a + b;
                        break;
                    case "-":
                        result = a - b;
                        break;
                    case "*":
                        result = a * b;
                        break;
                    case "/":
                        result = a / b;
                        break;
                    default:
                        Console.WriteLine(_operator + " Is an invalid operator");
                        Console.ReadKey();
                        return;
                }

                result.Print();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
