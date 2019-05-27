using System;
using System.IO;

namespace Alyabiev.Task10
{
	public static class WordsGetter
	{
		const string dir = @"..\..\..\data\";
		static string[] files = new[] { "words-Cordillera.txt", "words-Robot.txt", "words-Sierra.txt" };

		public static string[] GetRandomWords()
		{
			var index = new Random().Next(0, files.Length);

			return File.ReadAllLines(dir + files[index]); 
		}

		public static string[] GetWords(int index)
		{
			return File.ReadAllLines(dir + files[index]);
		}
	}
}