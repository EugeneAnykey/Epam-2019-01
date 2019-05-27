using System;

namespace Alyabiev.Task10.Task2
{
	public static class GreetingsHelper
	{
		#region Simple
		static readonly string[] goodbyes = new[] { "Goodbye", "See ya", "Bye", "Chao", "Au revoir" };
		static readonly string[] hellos = new[] { "Hello", "Hi" };

		public static string Goodbye()
		{
			return goodbyes[new Random().Next(0, goodbyes.Length)];
		}

		public static string Hello()
		{
			return hellos[new Random().Next(0, hellos.Length)];
		}
		#endregion

		#region By day time.
		const string ByeAddon = "[Bye] ";
		const string HiAddon = "[Hi] ";

		static readonly string[] goodbyesByDayTime = 
			new[] { "Good night", "Good morning", "Good afternoon", "Good evening"  };
			//new[] { "Доброй ночи", "Доброго утра", "Доброго дня", "Доброго вечера" };

		static readonly string[] hellosByDayTime =
			new[] { "Good night", "Good morning", "Good afternoon", "Good evening"  };
			//new[] { "Доброй ночи", "Доброго утра", "Доброго дня", "Доброго вечера" };

		public static string Goodbye(DayTime dayTime) => ByeAddon + goodbyesByDayTime[(int)dayTime];

		public static string Hello(DayTime dayTime) => HiAddon + hellosByDayTime[(int)dayTime];
		#endregion
	}
}