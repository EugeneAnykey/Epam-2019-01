/*
 * Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
 * Если пользователь вводит некорректные значения (отрицательные, или 0),
 *  должно выдаваться сообщение об ошибке. Возможность ввода пользователем строки вида «абвгд»,
 *  или нецелых чисел игнорировать.
 */

using System;

namespace Alyabiev.Task02.Task1
{
	class Program1
	{
		const int zero = 0;
		const int min = 1;
		const int max = 10;

		static readonly string greetingsMessage =
			"Rectangle square.\r\n" +
			"Enter a rectange size in 2 coordinates: x and y.\r\n" +
			$"Size must be in range [{min}]..[{max}].\r\n";
		
		const string resultMessage = "Square of a rectange: {0}.";

		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 02 - 1] Input length.\n");

			Console.WriteLine(greetingsMessage);

			var x = ReadCoord("x");
			var y = ReadCoord("y");

			Console.WriteLine(resultMessage, CalcSquare(x, y));

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		static int ReadCoord(string coordName)
		{
			const string getCoordMessage = "Please, enter the coordinate {0}: ";
			string wrongInputMessage =
				$"The coordinate must be set with integer value within range [{min}]..[{max}].";
			
			int result = zero;
			bool goodInput = false;

			do
			{
				Console.Write(getCoordMessage, coordName);
				var read = Console.ReadLine();
				goodInput =
					int.TryParse(read, out result) &&
					min <= result &&
					result <= max;
				
				if (!goodInput)
					Console.WriteLine(wrongInputMessage);
				
			} while (!goodInput);

			return result;
		}

		static int CalcSquare(int x, int y)
		{
			return x * y;
		}
	}
}