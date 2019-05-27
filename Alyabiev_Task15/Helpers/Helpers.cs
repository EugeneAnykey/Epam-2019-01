using System;
using System.Text.RegularExpressions;

namespace EugeneAnykey.Helpers
{
	public static class Names
	{
		const string namePattern = @"[a-zA-Zа-яА-Я]+";
		// John Smith the 2nd.
		// Wilhelm the IX.

		public static bool IsNameGood(string value, bool couldBeEmpty = false)
		{
			if (value == null)
				throw new ArgumentNullException();

			if (value.Length == 0)
			{
				if (couldBeEmpty)
					return true;
				else
					throw new ArgumentException("Не может быть пустой строкой");
			}

			if (!Regex.IsMatch(value, namePattern))
				throw new ArgumentException("Имя должно содержать только буквы.");

			return true;
		}
	}



	public static class Dates
	{
		public static int YearsPassed(DateTime to)
		{
			return YearsPassed(DateTime.UtcNow, to);
		}

		public static int YearsPassed(DateTime from, DateTime to)
		{
			int years = Math.Abs(from.Year - to.Year);

			if (from.Month < to.Month || (from.Month == to.Month && from.Day < to.Day))
				years--;

			return years;
		}
	}
}
