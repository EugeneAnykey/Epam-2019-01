/*
 * Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст).
 * Написать программу, демонстрирующую использование этого класса.
 */

using System;
using System.Text.RegularExpressions;

namespace Alyabiev.Task05.Task1
{
	public enum UserOutputFormat { FIO, IF }

	class User
	{
		const string namePattern = @"[a-zA-Zа-яА-Я]+";
		// will not works with: John Smith the 2nd, Wilhelm the IX.

		static bool IsNameGood(string value, bool couldBeEmpty = false)
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

		public static int YearsPassed(DateTime was)
		{
			return YearsPassed(DateTime.UtcNow, was);
		}

		public static int YearsPassed(DateTime now, DateTime was)
		{
			int years = now.Year - was.Year;

			if (now.Month < was.Month || (now.Month == was.Month && now.Day < was.Day))
				years--;

			return years;
		}

		#region field
		string name;
		public string Name
		{
			get { return name; }
			set
			{
				if (IsNameGood(value))
					name = value;
			}
		}

		string surname;
		public string Surname
		{
			get { return surname; }
			set
			{
				if (IsNameGood(value))
					surname = value;
			}
		}

		string patrname;
		public string Patrname
		{
			get { return patrname; }
			set
			{
				if (IsNameGood(value, true))
					patrname = value;
			}
		}

		DateTime birthdate;
		public DateTime Birthdate
		{
			get { return birthdate; }
			set
			{
				if (YearsPassed(value) > 150)
					throw new ArgumentException("Дата рождения не может быть установлена ранее 150 лет назад.");
				if (YearsPassed(value) < 0)
					throw new ArgumentException("Дата рождения не может быть установлена будущим числом.");

				birthdate = value;
			}
		}

		public int Age => YearsPassed(birthdate);
		#endregion

		public User(string name, string surname, string patrname, DateTime birthday)
		{
			Name = name;
			Surname = surname;
			Patrname = patrname;
			Birthdate = birthday;
		}

		public override string ToString()
		{
			return ToString(UserOutputFormat.FIO);
		}

		public string ToString(UserOutputFormat format)
		{
			const string maskFIO = "{0}, {1} {2}. Возраст: {3} лет.";
			const string maskIF = "{1} {0}. Возраст: {3} лет.";

			return string.Format(
				format == UserOutputFormat.FIO ? maskFIO : maskIF,
				surname, name, patrname, Age);
		}
	}
}
