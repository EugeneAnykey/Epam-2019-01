/* Написать класс, описывающий треугольник со сторонами a, b, c, и методами, позволяющими осуществить
 *  расчёт его площади и периметра. Обеспечить нахождение объекта в заведомо корректном состоянии.
 * Написать программу, демонстрирующую использование данного треугольника. 
 */

using System;

namespace Alyabiev.Task05.Task3
{
	class Program3
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 05 - 3] Triangle class.\n");

			var triangles = new[] {
				new Triangle(),
				new Triangle(3, 4, 5),
				//new Triangle(0, 0, 0),	// error
			};

			foreach (var t in triangles)
			{
				Console.WriteLine(t.ToString());
			}

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}