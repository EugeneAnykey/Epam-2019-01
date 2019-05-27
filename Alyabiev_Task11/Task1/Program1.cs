using System;

using Alyabiev.Task11.MyMathLib;

namespace Alyabiev.Task11.Task1
{
    class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Task 10 - 1] Sort, delegate.\n");

            Console.WriteLine("\t<Factorial>");
            for (int i = 1; i < 12; i++)
            {
                Console.WriteLine($"Factorial {i} = {MyMath.Factorial(i)}");
            }
            Console.WriteLine();

            Console.WriteLine("\t<Power of (2)>");
            for (int i = 1; i < 12; i++)
            {
                Console.WriteLine($"Pow {i} = {MyMath.Power(i, 2)}");
            }
            Console.WriteLine();

            Console.WriteLine("\t<Power of (-2)>");
            for (int i = 1; i < 12; i++)
            {
                Console.WriteLine($"Pow {i} = {MyMath.Power(i, -2)}");
            }
            Console.WriteLine();

            Console.WriteLine("\t<Power of (2.5)>");
            for (int i = 1; i < 12; i++)
            {
                Console.WriteLine($"Pow {i} = {MyMath.Power(i, 2.5)}");
            }
            Console.WriteLine();

            Console.Write("[!] finished.");
            Console.ReadKey(true);
        }
    }
}
