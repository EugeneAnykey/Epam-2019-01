/*
 * Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули. 
 */

using System;

using Alyabiev.Task03.ArrayHelperLib;

namespace Alyabiev.Task03.Task2
{
	class Program2
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 03 - 2] [x,y,z] array. If (x > 0) => = 0.\n");

			const int min = -10;
			const int max = 10;
			const int x = 3;
			const int y = 4;
			const int z = 5;

			var array3d = ThreeDimArray.Generate(x, y, z);

			Console.WriteLine("Array length: {0}.\n", array3d.Length);
			Console.WriteLine("Random:");
			array3d.FillWithRandom(min, max);
			Console.WriteLine(array3d.ToSingleString());
			Console.WriteLine();

			Console.WriteLine("Zeroing:");
			array3d.SetPositivesToZero();
			Console.WriteLine(array3d.ToSingleString());
			Console.WriteLine();

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}