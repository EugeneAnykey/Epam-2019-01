/* Разработать консольное приложение, которое выводит на экран (в виде таблицы) отличия в параметрах культур:
 *	"ru"  vs "en"
 *	"en"  vs "invariant"	
 *  "ru"  vs "invariant"
 *  
 * Необходимо вывести на экране отличия в:
 *  1) формат отображения даты и времени
 *  2) формат отображения числовых данных(разделитель дробной и целой части, разделитель групп разрядов и т.п.)
 *
 * Целесообразно реализовать отдельный метод, который принимает на входе название культур
 *  и выводит отличия на экран. Повторно использовать этот метод (Code Reuse) для вывода различных пар культур.
 */

using System;
using System.Globalization;

namespace Alyabiev.Task04.Task3
{
	class Program3
	{
		static void Main(string[] args)
		{
			Console.WriteLine("[Task 04 - 3] Culture info.\n");

			var ru = new CultureInfo("ru-ru");
			var en = new CultureInfo("en-us");
			var inv = CultureInfo.InvariantCulture;
			var nz = new CultureInfo("en-nz");

			OutputNames(new[] { ru, en, inv, nz });

			OutputCultureInfoDiff(ru, en);
			OutputCultureInfoDiff(en, inv);
			OutputCultureInfoDiff(ru, inv);
			OutputCultureInfoDiff(ru, nz);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}



		static string CheckName(string name)
		{
			return string.IsNullOrEmpty(name) ? "?" : name;
		}

		static string CompareAndOutput<T>(T left, T right)
		{
			var equals = left.Equals(right) ? "=" : "!";
			return string.Format($"[{equals}] [{left}] [{right}]");
		}

		static void OutputNames(CultureInfo[] infos)
		{
			Console.WriteLine("Names:");
			foreach (var item in infos)
			{
				Console.WriteLine(CheckName(item.Name));
			}
			Console.WriteLine();
		}

		public static void OutputCultureInfoDiff(CultureInfo left, CultureInfo right)
		{
			if (left == null || right == null)
				throw new ArgumentNullException();

			var date = DateTime.UtcNow;
			var val = 7145613.3;

			Console.WriteLine($"\n\tCulture info difference between [{CheckName(left.Name)}] and [{CheckName(right.Name)}].\n");

			// dates:
			Console.WriteLine($"date example:    {date.ToString("d", left),-20} {date.ToString("d", right),-20}");
			OutputDateTimeFormatDiff(left.DateTimeFormat, right.DateTimeFormat);
			Console.WriteLine();

			// values:
			Console.WriteLine($"example as float:    {val.ToString("f", left),-10}  {val.ToString("F", right),-10}");
			Console.WriteLine($"example as currency: {val.ToString("C2", left),-10} {val.ToString("C2", right),-10}");
			OutputNumberFormatDiff(left.NumberFormat, right.NumberFormat);
			Console.WriteLine("\n\n");
		}

		static void OutputDateTimeFormatDiff(DateTimeFormatInfo left, DateTimeFormatInfo right)
		{
			// формат отображения даты и времени
			Console.WriteLine($"Date separator:         {CompareAndOutput(left.DateSeparator, right.DateSeparator)}");
			Console.WriteLine($"Time separator:         {CompareAndOutput(left.TimeSeparator, right.TimeSeparator)}");
			Console.WriteLine($"Short Date Pattern:     {CompareAndOutput(left.ShortDatePattern, right.ShortDatePattern)}");
			Console.WriteLine($"Short Time Pattern:     {CompareAndOutput(left.ShortTimePattern, right.ShortTimePattern)}");
			Console.WriteLine($"Full Date Time Pattern: {CompareAndOutput(left.FullDateTimePattern, right.FullDateTimePattern)}");
		}

		static void OutputNumberFormatDiff(NumberFormatInfo left, NumberFormatInfo right)
		{
			// формат отображения числовых данных(разделитель дробной и целой части, разделитель групп разрядов и т.п.)
			Console.WriteLine($"Decimal separator:         {CompareAndOutput(left.NumberDecimalSeparator, right.NumberDecimalSeparator)}");
			Console.WriteLine($"Decimal digits:            {CompareAndOutput(left.NumberDecimalDigits, right.NumberDecimalDigits)}");
			Console.WriteLine($"Group separator:           {CompareAndOutput(left.NumberGroupSeparator, right.NumberGroupSeparator)}");
			Console.WriteLine($"Negative sign:             {CompareAndOutput(left.NegativeSign, right.NegativeSign)}");
			Console.WriteLine($"Negative infinity symbol:  {CompareAndOutput(left.NegativeInfinitySymbol, right.NegativeInfinitySymbol)}");
			Console.WriteLine($"Positive infinity symbol:  {CompareAndOutput(left.PositiveInfinitySymbol, right.PositiveInfinitySymbol)}");
		}
	}
}