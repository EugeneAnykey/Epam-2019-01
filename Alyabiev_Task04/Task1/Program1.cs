/*
 * Написать программу, которая определяет среднюю длину слова во введенной текстовой строке.
 * Учесть, что символы пунктуации на длину слов влиять не должны.
 * Используйте стандартные методы класса String.
 */

using System;

namespace Alyabiev.Task04.Task1
{
	class Program1
	{
		static void Main(string[] args)
		{
			Console.WriteLine("[Task 04 - 1] Average word length.\n");

			const string example = "Example string. It contains some punctuation like commas, points, etc.";

			var s = example;
			Console.WriteLine($"String: {s}.\n");

			var words = GetWords(s);
			OutputStrings(words);

			var average = CalcAverageLength(words);
			Console.WriteLine($"Average length: {average}.\n");

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}



		public static void OutputStrings(string[] lines)
		{
			if (lines == null)
				lines = new string[0];

			Console.WriteLine($"Lines ({lines.Length}): ");
			for (int i = 0; i < lines.Length; i++)
			{
				Console.WriteLine($"{i + 1}: {lines[i]}");
			}
			Console.WriteLine();
		}

		public static string[] GetWords(string line)
		{
			if (line == null)
				throw new ArgumentNullException();

			var splitters = new char[] { ' ', ',', '.', ':' };
			return line.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
		}

		public static float CalcAverageLength(string[] lines)
		{
			if (lines == null)
				throw new ArgumentNullException();

			var res = 0;
			foreach (var s in lines)
			{
				res += s.Length;
			}

			return (float)res / lines.Length;
		}
	}
}