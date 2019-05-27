/*
 * Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст).
 * Написать программу, демонстрирующую использование этого класса.
 */

using System;

namespace Alyabiev.Task05.Task1
{
	class Program1
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 05 - 1] User class.\n");

			/*
			var errorUsers = new User[] {
				new User("Имя", "", "", new DateTime(1923, 02, 28)),
				new User("", "Фамилия", "", new DateTime(1923, 02, 28)),
				new User("Имя", "Фамилия", "", DateTime.UtcNow.AddYears(-151).AddDays(0)),
			};
			*/

			var users = new User[] {
				new User("Имя", "Фамилия", "", DateTime.UtcNow.AddYears(-151).AddDays(1)),
				new User("John", "Smith", "", new DateTime(1956, 12, 25)),
				new User("Эрик", "Удальцов", "Аганосянович", new DateTime(1923, 02, 28)),

				new User("Aa", "Ba", "", DateTime.UtcNow.AddYears(-20).AddDays(-1)),
				new User("Ab", "Bb", "", DateTime.UtcNow.AddYears(-20)),
				new User("Ac", "Bc", "", DateTime.UtcNow.AddYears(-20).AddDays(1))
			};

			foreach (var u in users)
			{
				Console.WriteLine(u.ToString(UserOutputFormat.FIO));
			}

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}