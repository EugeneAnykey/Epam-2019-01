using System;

using euHelp = EugeneAnykey.Helpers;
using EugeneAnykey.Language.Rus;

namespace Awarder.Entities
{
	public class User : IUser
	{
		// static
		static int lastId = 1;

		public static readonly string[] YearsVariants = new string[] { "год", "года", "лет" };



		#region field: IF, FIO, Id, Name, Surname, Birthdate, Age, AgeString.
		public string IF => $"{name} {surname}";

		public string FIO => $"{surname}, {name}";

		public int Id { get; private set; }

		string name;
		public string Name
		{
			get { return name; }
			set
			{
				if (euHelp.Names.IsNameGood(value))
					name = value;
			}
		}

		string surname;
		public string Surname
		{
			get { return surname; }
			set
			{
				if (euHelp.Names.IsNameGood(value))
					surname = value;
			}
		}

		DateTime birthdate;
		public DateTime Birthdate
		{
			get { return birthdate; }
			set
			{
				if (euHelp.Dates.YearsPassed(value) > 150)
					throw new ArgumentException("Дата рождения не может быть установлена ранее 150 лет назад.");
				if (euHelp.Dates.YearsPassed(value) < 0)
					throw new ArgumentException("Дата рождения не может быть установлена будущим числом.");

				birthdate = value;
			}
		}

		public int Age => euHelp.Dates.YearsPassed(birthdate);

		public string AgeString => $"{euHelp.Dates.YearsPassed(birthdate)} {RusNumeralsFollowingWord.StringEndingForNumeric(Age, YearsVariants)}";
		#endregion



		// init
		public User(string name, string surname, DateTime birthdate)
		{
			Id = lastId++;
			Name = name;
			Surname = surname;
			Birthdate = birthdate;
		}

		public User(int id, string name, string surname, DateTime birthdate)
		{
			Id = id;
			if (lastId < id)
				lastId = id + 1;

			Name = name;
			Surname = surname;
			Birthdate = birthdate;
		}
	}
}
