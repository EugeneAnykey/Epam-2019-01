/*
 * Элемент двумерного массива считается стоящим на чётной позиции, если сумма номеров его 
 *  позиций по обеим размерностям является чётным числом (например, [1,1] – чётная позиция,
 *  а [1,2] - нет).  Определить сумму элементов массива, стоящих на чётных позициях. 
 */

using System;

using Alyabiev.Task03.ArrayHelperLib;

namespace Alyabiev.Task03.Task4
{
	class Program4
	{
		static void Main(string[] args)
		{
			// при переборе элементов массива проход начинаем от 0. Если начинать от 1, результат на выходе будет тот же:
			// если с 0: 0 + 0 = 0 (чет), 0 + 1 = 1 (нечет).
			// если с 1: 1 + 1 = 2 (чет), 1 + 2 = 3 (нечет).

			Console.WriteLine("[Task 03 - 4] 2 dim array. Calculate sum of elements on even positions.");
			Console.WriteLine();

			const int x = 4;
			const int y = 3;

			const int min = 0;
			const int max = 50;

			var arr2d = TwoDimArray.Generate(x, y);
			arr2d.FillWithRandom(min, max);

			Console.WriteLine("Array length: {0}.\n", arr2d.Length);
			Console.WriteLine("Array: \n{0}\n", arr2d.ToSingleString());

			Console.WriteLine("Sum of elements on even positions in 2 dimentional array is {0}.\n", arr2d.SumOnEvenPos());

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}