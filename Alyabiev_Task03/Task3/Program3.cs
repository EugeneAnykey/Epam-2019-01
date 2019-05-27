/*
 * Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. 
 */

using System;

using Alyabiev.Task03.ArrayHelperLib;

namespace Alyabiev.Task03.Task3
{
	class Program3
	{
		static void Main(string[] args)
		{
			Console.WriteLine("[Task 03 - 3] Calculating sum of non negatives integers.\n");

			const int min = -25;
			const int max = 5;

			var arr = OneDimArray.Generate(30);
			arr.Randomize(min, max);

			Console.WriteLine("Array length: {0}.\n", arr.Length);
			Console.WriteLine("Array: \n{0}\n", arr.ToSingleString());
			Console.WriteLine();

			Console.WriteLine("Sum of non negatives: {0}.", OneDimArray.SumNonNegatives(arr));
			Console.WriteLine();

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}