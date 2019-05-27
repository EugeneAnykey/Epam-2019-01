using System;

using EugeneAnykey.Language.Rus;

namespace Alyabiev.Task14.Task1
{
	public class User
	{
		#region static
		static int lastId = 1;

		public static readonly string[] YearsVariants = new string[] { "год", "года", "лет" };
		#endregion

		#region field
		public string IF => $"{name} {surname}";

		public string FIO => $"{surname}, {name}";

		public int Id { get; private set; }

		string name;
		public string Name
		{
			get { return name; }
			set
			{
				if (Helpers.IsNameGood(value))
					name = value;
			}
		}

		string surname;
		public string Surname
		{
			get { return surname; }
			set
			{
				if (Helpers.IsNameGood(value))
					surname = value;
			}
		}

		DateTime birthdate;
		public DateTime Birthdate
		{
			get { return birthdate; }
			set
			{
				if (Helpers.YearsPassed(value) > 150)
					throw new ArgumentException("Дата рождения не может быть установлена ранее 150 лет назад.");
				if (Helpers.YearsPassed(value) < 0)
					throw new ArgumentException("Дата рождения не может быть установлена будущим числом.");

				birthdate = value;
			}
		}

		public int Age => Helpers.YearsPassed(birthdate);

		public string AgeString => $"{Helpers.YearsPassed(birthdate)} {RusNumeralsFollowingWord.StringEndingForNumeric(Age, YearsVariants)}";
		#endregion

		public User(string name, string surname, DateTime birthdate)
		{
			Id = lastId++;
			Name = name;
			Surname = surname;
			Birthdate = birthdate;
		}
	}
}
