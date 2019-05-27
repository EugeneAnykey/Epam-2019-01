/*
 * Если выписать все натуральные числа меньше 10, кратные 3, или 5, то получим 3, 5, 6 и 9.
 * Сумма этих чисел будет равна 23. Напишите программу, которая выводит на экран сумму всех
 *  чисел меньше 1000, кратных 3, или 5.
 */

using System;
using System.Text;

namespace Alyabiev.Task02.Task5
{
	class Program5
	{
		const int three = 3;
		const int five = 5;
		const int fifteen = three * five;


		static void Main(string[] args)
		{
			Console.WriteLine("[Task 02 - 5] .\n");

			var multiples = new int[] { 3, 5 };
			//SoftCoded(100, multiples);
			//SoftCoded(500, multiples);
			SoftCoded(1000, multiples);

			// test:
			//SoftCoded(-5, multiples);
			//SoftCoded(100, null);
			//SoftCoded(1000, new int[] { 3, 5, 15 });    // testing that 15 didn't add additional items.

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		static string ArrayToString(int[] array)
		{
			var arr = array ?? new int[0];

			if (arr.Length == 0)
				return "[none]";

			var sb = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				sb.Append(array[i].ToString());
			}

			return $"[{sb.ToString()}]";
		}

		static void SoftCoded(int value, int[] multiples)
		{
			Console.Write("Soft coded: ");
			var msc = new MultiplesSoftCoded(multiples);
			var arr = msc.GetValuesThatIsMultiplies(value);
			var sum = msc.CalcSum(arr);

			Console.WriteLine($"The sum of multiples of {ArrayToString(multiples)} for {value} would be {sum}.\r\n");
		}
	}
}