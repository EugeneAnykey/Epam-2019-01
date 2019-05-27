/*
 * Написать программу, которая удваивает в первой введенной строке все символы, 
 *  принадлежащие второй введенной строке.
 */

using System;
using System.Collections.Generic;

namespace Alyabiev.Task04.Task2
{
	class Program2
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 04 - 2] Doubling letters in a sentence.\n");

			var input = "Some very simple sentence. Indeed.";

			var word = "stances";

			Console.WriteLine($"Original: {input}.\nWord: {word}.\n");

			Console.WriteLine($"Doubled: {DoubleLetters(input, word)}.\n");

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		public static string DoubleLetters(string line, string word)
		{
			var res = line;

			var letters = GetPossibleDoublers(word);

			foreach (var c in letters)
			{
				int i = 0;
				while (res.Length > i)
				{
					if (res[i].Equals(c))
						res = res.Insert(i++, c.ToString());
					i++;
				}
			}

			return res;
		}

		static char[] GetPossibleDoublers(string letters)
		{
			var cc = new char[letters.Length];

			var list = new List<char>();

			for (int i = 0; i < letters.Length; i++)
			{
				if (!list.Contains(letters[i]))
					list.Add(letters[i]);
			}

			return list.ToArray();
		}
	}
}