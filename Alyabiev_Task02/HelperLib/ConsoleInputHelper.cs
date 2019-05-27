using System;

namespace Alyabiev.Task02.InputHelper
{
	public static class ConsoleInputHelper
	{
		public static int GetLinesCount(int min, int max, int exitCode)
		{
			const string GetLinesCountMessage = "Enter number of lines: ";
			string wrong =
				$"Wrong input. Lines count must be a number from {min} to {max}.";

			int res = min;

			bool goodInput = false;

			do
			{
				Console.Write(GetLinesCountMessage);
				var read = Console.ReadLine();
				goodInput =
					int.TryParse(read, out res) &&
					res == exitCode ||
					min <= res &&
					res <= max;

				if (!goodInput)
					Console.WriteLine(wrong);

			} while (!goodInput);

			return res;
		}
	}
}
