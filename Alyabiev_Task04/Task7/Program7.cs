/*
 * Напишите программу, которая определяет, сколько раз в тексте встречается время. Постарайтесь учесть,
 *  что в сутках только 24 часа, а в часе – 60 минут. Обязательно использовать регулярные выражения.
 * 
 * Пример:
 *  Введите текст: В 7:55 я встал, позавтракал и к 10:77 пошел на работу.
 *  Время в тексте присутствует 1 раз.
 */

using System;
using System.Text.RegularExpressions;

namespace Alyabiev.Task04.Task7
{
	class Program7
	{
		const string maskLine = "В {0} я встал, позавтракал и к {1} пошел на работу.";
		const string hoursPattern = @"\b([01]?[\d]|2[0-3]):([0-5][\d])\b";

		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 04 - 7] Time count.\n");

			var inputs = new string[][] {
				new[]{  "2:34", "07:55" },
				new[]{ "13:31", "24:12" },
				new[]{ "23:60", "00:00" },
				new[]{ "17:12", "71:14" },
				new[]{ "12:72", "31:43" }
			};

			foreach (var line in inputs)
			{
				var testString = string.Format(maskLine, line[0], line[1]);

				Output(testString, Count_byRegexInstance);
				Output(testString, Count_byRegexStatic);
			}

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}



		delegate int Calculating(string line);

		static void Output(string line, Calculating calc)
		{
			Console.WriteLine($"Original string: {line}.");

			var count = calc(line);

			Console.WriteLine($"\nTime appears {count} times.\n");
		}

		static int Count_byRegexInstance(string line)
		{
			var regexHours = new Regex(hoursPattern);

			int count = 0;
			Match match = regexHours.Match(line);
			while (match.Success)
			{
				Console.WriteLine("{0}", match.Value);
				match = match.NextMatch();
				count++;
			}

			return count;
		}

		static int Count_byRegexStatic(string line)
		{
			int count = 0;
			foreach (Match match in Regex.Matches(line, hoursPattern))
			{
				Console.WriteLine("{0}", match.Value);
				count++;
			}

			return count;
		}
	}
}