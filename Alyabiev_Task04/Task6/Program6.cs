/* Напишите программу, которая проверяет текстовую строку на соответствие имеющегося в 
 *  ней текста формату вещественного числа и выводит, в каком формате оно записано.
 * Обязательно использовать регулярные выражения.
 * 
 * 1. Число может быть записано в обычной нотации.
 * 2. Число может быть записано в научной нотации (например, 127 = 1.27*10^2  = 1.27e2, -0.0055 = -5.5*10^-3 = -5.5e-3).
 * 
 * Примеры:
 * 5		- Это число в обычной нотации
 * -2.5		- Это число в обычной нотации
 * 5.75e-5	- Это число в научной нотации
 * *		- Это не число
 */

using System;
using System.Text.RegularExpressions;

namespace Alyabiev.Task04.Task6
{
	class Program6
	{
		const string totalPattern = @"[-+]?[\0-9]([.][\d])?[e][-]?[\d]+";
		const string simplePattern = @"[-+]?[\d]+[.]?[\d]+";

		readonly static Regex regexTotal = new Regex(totalPattern);
		readonly static Regex regexSimple = new Regex(simplePattern);

		enum NumberResult { Empty, NotNumber, SimpleNumber, ScientificNumber };

		readonly static string[] answer = new[]{
			"",
			"{0,-10} — Это не число",
			"{0,-10} — Это число в обычной нотации",
			"{0,-10} — Это число в научной нотации",
		};



		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 04 - 6] Float number format check.\n");

			//var inputs = new[] {
			//	"0174", "35.", "12.3", "+12.3456", "-18.98", null,
			//	"4.3e-3", "1e7", "-1.7e8", "12.3e4", null,
			//	"e-2", "e6", "e", "*", null,
			//	"ab", "d6", "14fg", "3r7"
			//};

			var inputs2 =
				"0174  35.  12.3  +12.3456  -18.98 |  4.3e-3  1e7  -1.7e8  12.3e4  |  e-2  e6  e  *  |  ab d6  14fg  3r7"
				.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);


			CheckNumbers(inputs2);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		static void CheckNumbers(string[] lines)
		{
			foreach (var s in lines)
			{
				OutputNumberResult(s, CheckNumber1(s));
			}
		}

		static void OutputNumberResult(string line, NumberResult res)
		{
			var answ = answer[(int)res];
			Console.WriteLine(answ, line);
		}

		static NumberResult CheckNumber1(string line)
		{
			if (string.IsNullOrEmpty(line) || line.Equals("|"))
				return NumberResult.Empty;

			if (regexTotal.IsMatch(line))
				return NumberResult.ScientificNumber;

			if (regexSimple.IsMatch(line))
				return NumberResult.SimpleNumber;

			return NumberResult.NotNumber;
		}
	}
}