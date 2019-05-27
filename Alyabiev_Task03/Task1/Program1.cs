/*
 * Написать программу, которая генерирует случайным образом элементы массива (число элементов в массиве
 *  и их тип определяются разработчиком), определяет для него максимальное и минимальное значения, сортирует
 *  массив и выводит полученный результат на экран.
 * Примечание: LINQ запросы и готовые функции языка(Sort, Max и т.д.) использовать в данном задании запрещается.
 */

using System;

using Alyabiev.Task03.ArrayHelperLib;

namespace Alyabiev.Task03.Task1
{
	class Program1
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 03 - 1] Random array. Find min, max. Sort. Output.\n");

			const int count =
				//20000;
				//2000;
				//200;
				20;
			//const int min = 0;
			const int max = 500;

			var array = OneDimArray.Generate(count);
			array.Randomize(max: max);

			Console.WriteLine("Array length: {0}.\n", array.Length);
			Console.WriteLine("Generated array: \n{0}\n", array.ToSingleString());
			Console.WriteLine("Max value: {0}.", OneDimArray.Max(array));
			Console.WriteLine("Min value: {0}.", OneDimArray.Min(array));
			Console.WriteLine();

			Console.WriteLine("Sort:\n\t start:");
			OneDimArray.Sort(array);
			Console.WriteLine("\t done.\n");

			Console.WriteLine("After sort: \n{0}\n", array.ToSingleString());

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}