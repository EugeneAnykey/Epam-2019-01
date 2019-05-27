using System;
using System.IO;

namespace Alyabiev.Task09.Task3
{
	public static class TextHelper
	{
		static string[] fileNames = new[] { "text-Cordillera.txt", "text-Sierra.txt", "text-Robot.txt" };

		const string dirPath = @"..\..\..\data\";

		public static string GetRandomText()
		{
			return GetText(new Random().Next(0, fileNames.Length));
		}

		public static string GetText(int index)
		{
			Console.WriteLine($"File: {fileNames[index]}.\n");

			index = index < 0 ? 0 : index >= fileNames.Length ? fileNames.Length - 1 : index;

			return File.ReadAllText(dirPath + fileNames[index]);
		}
	}
}