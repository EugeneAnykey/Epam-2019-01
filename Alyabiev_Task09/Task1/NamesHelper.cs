using System;

namespace Alyabiev.Task09.Task1
{
	public static class HumanGeneratorHelper
	{
		static Random r = new Random();

		// http://www.english-source.ru/english-linguistics/english-lexis/148-english-names
		static readonly string[] MaleNames = new[] {
			"Austin", "Bryan", "Curtis", "Dominic",
			"Ethan", "Francis", "George", "Henry",
			"Isaiah", "John", "Kevin", "Louis",
			"Matthew", "Nicholas", "Otto", "Patric",
			"Quentin", "Ralph", "Steven", "Tomas",
			"Ulysses", "Victor", "William", "Xavier",
			"Yaron", "Zorg" };

		static readonly string[] FemaleNames = new[] {
			"Ada", "Beatrice", "Cecile", "Deborah",
			"Emma", "Felicia", "Gabrielle", "Hannah",
			"Ingeborge", "Joyce", "Kimberly", "Lynn",
			"Mandy", "Nicole", "Olivia", "Pauline",
			"Quelle", "Rebecca", "Sierra", "Taylor",
			"Uliana", "Vanessa", "Winifred", "Xandra",
			"Yvonne", "Zoe" };

		public static string GetRandomMaleName()
		{
			return MaleNames[r.Next(MaleNames.Length)];
		}

		public static string GetRandomFemaleName()
		{
			return FemaleNames[r.Next(FemaleNames.Length)];
		}

		public static string GetRandomName(Sex sex)
		{
			return sex == Sex.Female ? GetRandomFemaleName() : GetRandomMaleName();
		}

		public static Sex GetRandomSex()
		{
			return r.Next(2) == 1 ? Sex.Female : Sex.Male;
		}
	}
}