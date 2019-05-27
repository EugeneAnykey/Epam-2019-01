/* Занятие 8, 9
 * Задание 8-1, 9-2
 * 
 * На базе обычного массива (коллекции .NET не использовать) реализовать свой 
 *  собственный класс DynamicArray, представляющий собой массив с запасом.
 * Элементами созданной коллекции могут быть только объекты, имеющие конструктор без параметров.
 */

#define task9

using System;
using Alyabiev.Task08.Task1;

namespace Alyabiev.Task09.Task2
{
	class Program1
	{
		public static void Main(string[] args)
		{
			#if task9
			Console.WriteLine("[Task 09 - 2] DynamicArrayEx : IEnumareble.\n");
			#else
			Console.WriteLine("[Task 08 - 1] DynamicArray.\n");
			#endif

			var da =
				#if task9
				new DynamicArrayEx<string>
				#else
				new DynamicArray<string>
				#endif
				(new[] { "abc", "def", "ghi", "jkl" });

			Output("<init>", da);

			da.Insert("xyz", 2);
			Output("<insert [2]>", da);

			da.Insert("xyz2", 5);
			Output("<insert [5]>", da);

			da.Add("abc-new");
			Output("<Add>", da);

			da.Remove(2);
			Output("<Remove [2]>", da);
			da.Remove(4);
			Output("<Remove [4]>", da);
			da.Remove(4);
			Output("<Remove [4]>", da);
			da.Remove(0);
			Output("<Remove [0]>", da);

			da.AddRange(
				new DynamicArray<string>(
					"1 2 3 4 5 6 7 8 9 A B C D E F".Split(' ')
				)
			);
			Output("<AddRange>", da);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		static void Output(string message, DynamicArray<string> da)
		{
			Console.Write($"{message,-14} ");

			#if task9
			// because DynamicArrayEx is IEnumerable we can use string.Join():
			if (da is DynamicArrayEx<string>)
				Console.Write(string.Join(" ", da as DynamicArrayEx<string>));
			#else
			for (int i = 0; i < da.Length; i++)
			{
				Console.Write($"{da[i]} ");
			}
			#endif
			
			Console.WriteLine();
			Console.WriteLine();
		}
	}
}