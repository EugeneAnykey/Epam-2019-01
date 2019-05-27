/*
 * Написать класс Round, задающий круг с указанными координатами центра, радиусом,
 *  а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
 * Обеспечить нахождение объекта в заведомо корректном состоянии. 
 * Написать программу, демонстрирующую использование данного круга.
 */

using System;

namespace Alyabiev.Task05.Task2
{
	class Program2
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 05 - 2] Round class.\n");

			var rounds = new[] {
				new Round(),
				new Round(2, 3, 3)
			};

			foreach (var r in rounds)
			{
				Console.WriteLine(r.ToString());
			}

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}
