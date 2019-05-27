/* Занятие 10
 * Задание 1
 * 
 * Написать программу, выполняющую сортировку массива строк по возрастанию длины. 
 * Если строки состоят из равного числа символов, их следует отсортировать по алфавиту. 
 * Реализовать метод сравнения строк отдельным методом, передаваемым в сортировку через делегат.
 */

using System;

namespace Alyabiev.Task10.Task1
{
	class Program1
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 10 - 1] Sort, delegate.\n");

			var lines = WordsGetter.GetRandomWords();
			Outputter.WriteToConsole("Before sort:", lines);

			Sorter.Sort(lines, Comparator.MyCompare);
			Outputter.WriteToConsole("After sort:", lines);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}