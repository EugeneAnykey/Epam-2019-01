/*
 * Написать программу, которая запрашивает с клавиатуры число N и выводит на экран "елку" звезд несколько раз.
 */

using System;
using Alyabiev.Task02.InputHelper;

namespace Alyabiev.Task02.Task4
{
	class Program4
	{
		static int exitCode = 0;
		static int min = 1;
		static int max = 7;

		static readonly string GreetingsMessage =
				$"Enter number of groups (upto {max}) to draw <star fir-tree> or type {exitCode} to exit.";


		static void Main(string[] args)
		{
			Console.WriteLine("[Task 02 - 4] Drawing a <fir-tree>.\n");

			Console.WriteLine(GreetingsMessage);

			int linesCount = min;

			do
			{
				linesCount = ConsoleInputHelper.GetLinesCount(min, max, exitCode);
				if (linesCount != exitCode)
					DrawFirTree(linesCount);

			} while (linesCount != exitCode);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		private static void DrawFirTree(int linesCount)
		{
			const char star = '*';
			const char space = ' ';

			var starLine = string.Empty;
			for (int j = 0; j < linesCount; j++)
			{
				for (int i = 0; i <= j; i++)
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
}