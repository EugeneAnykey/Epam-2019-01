/*
 * Написать программу, которая запрашивает с клавиатуры число N и выводит на экран "елку" звезд.
 */

using System;
using Alyabiev.Task02.InputHelper;

namespace Alyabiev.Task02.Task3
{
	class Program3
	{
		static int exitCode = 0;
		static int min = 1;
		static int max = 7;

		static readonly string GreetingsMessage =
				$"Enter number of lines (upto {max}) to draw <star fir-tree> or type {exitCode} to exit.";


		static void Main(string[] args)
		{
			Console.WriteLine("[Task 02 - 3] Drawing a simple <fir-tree>.\n");

			Console.WriteLine(GreetingsMessage);

			int linesCount = min;

			do
			{
				linesCount = ConsoleInputHelper.GetLinesCount(min, max, exitCode);
				if (linesCount != exitCode)
					DrawSimpleFirTree(linesCount);

			} while (linesCount != exitCode);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		private static void DrawSimpleFirTree(int linesCount)
		{
			const char star = '*';
			const char space = ' ';

			var starLine = string.Empty;
			for (int i = 0; i < linesCount; i++)
			{
				var spacesCount = linesCount - i - 1;
				var starsCount = spacesCount + i * 2 + 1;
				starLine = string.Empty.PadLeft(spacesCount, space);
				starLine = starLine.PadRight(starsCount, star);
				Console.WriteLine(starLine);
			}
		}
	}
}