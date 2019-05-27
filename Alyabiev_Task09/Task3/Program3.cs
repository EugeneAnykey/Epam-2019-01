/* Занятие 9
 * Задание 3
 * 
 * Задан английский текст. Выделить отдельные слова и для каждого посчитать частоту встречаемости.
 * Слова, отличающиеся регистром, считать одинаковыми.
 * В качестве разделителей считать все разделительные символы (через Regex).
 */

using System;

namespace Alyabiev.Task09.Task3
{
	class Program3
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 09 - 3] Words count.\n");

			var wc = new WordsCounter(TextHelper.GetRandomText());
			wc.Count();
			wc.SortDict();

			Console.WriteLine(wc.Summary());
			Console.WriteLine();

			Console.WriteLine("First 5 most often used words: {0}.", string.Join(" ", wc.FirstFiveMostPopularWords()));
			Console.WriteLine();

			Console.WriteLine(string.Join("\n", wc.GetResultLines()));
			Console.WriteLine();

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}