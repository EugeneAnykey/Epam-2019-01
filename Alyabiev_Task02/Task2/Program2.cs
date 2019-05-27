/* Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
 * *
 * **
 * ***
 */

using System;
using Alyabiev.Task02.InputHelper;

namespace Alyabiev.Task02.Task2
{
	class Program2
	{
		static int exitCode = 0;
		static int min = 1;
		static int max = 5;


		static readonly string GreetingsMessage =
				$"Enter number of lines (upto {max}) to draw <star ladder> or type {exitCode} to exit.";


		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 02 - 2] Drawing stars.\n");

			Console.WriteLine(GreetingsMessage);

			int linesCount = min;

			do
			{
				linesCount = ConsoleInputHelper.GetLinesCount(min, max, exitCode);
				if (linesCount != exitCode)
					DrawStars(linesCount);

			} while (linesCount != exitCode);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		static void DrawStars(int linesCount)
		{
			const string star = "*";

			var starLine = string.Empty;
			for (int i = 0; i < linesCount; i++)
			{
				starLine = string.Concat(starLine, star);
				Console.WriteLine(starLine);
			}
		}
	}
}