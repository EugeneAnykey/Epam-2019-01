using System;
using Epam.Task11.NetBasicsDemo;

namespace Alyabiev.Task11.Task3
{
	class Program3
	{
		static void Main(string[] args)
		{
            Console.WriteLine("[Task 11 - 3] GetHashCode.\n");

            var points = new[] {
                new TwoDPointWithHash(1, 1),
                new TwoDPointWithHash(10, 10),
                new TwoDPointWithHash(3, 7),
                new TwoDPointWithHash(14, 14),
                new TwoDPointWithHash(140, 140),
				new TwoDPointWithHash(0x1f19, 0x3fbc),
				new TwoDPointWithHash(0x1f19, 0x3fbd),
			};

            foreach (var item in points)
            {
                Console.WriteLine($"{item}: {item.GetHashCode()}");
            }

            Console.Write("[!] finished.");
            Console.ReadKey(true);
        }
	}
}