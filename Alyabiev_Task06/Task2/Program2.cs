/* 
 * Создать класс Ring (кольцо) на основе Round (см. задание 2 из предыдущей темы), 
 *  описываемое координатами центра, внешним и внутренним радиусами, а также свойствами, 
 *  позволяющими узнать площадь кольца и суммарную длину внешней и внутренней границ кольца. 
 * Обеспечить нахождение класса в заведомо корректном состоянии.
 */

using System;

namespace Alyabiev.Task06.Task2
{
	class Program2
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 06 - 2] Ring class.\n");

			var rings = new[] {
				new Ring(new Round(2, 2, 3), new Round(2, 2, 2)),
				new Ring(2, 3, 4, 3)
			};

			foreach (var r in rings)
			{
				Console.WriteLine(r.ToString());
			}

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}