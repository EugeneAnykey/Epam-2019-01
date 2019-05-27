using System;
using System.Collections.Generic;
using System.IO;

namespace EugeneAnykey.FileWatcher
{
	public static class Helper
	{
		public static void CheckAndCreateDir(string path)
		{
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
		}



		public static bool IsOneFromList(string line, IEnumerable<string> list)
		{
			foreach (var s in list)
				if (line == s)
					return true;

			return false;
		}



		public static bool FilesEquals(string path1, string path2)
		{
			return (File.Exists(path1) && File.Exists(path2)) ?
				File.ReadAllText(path1).Equals(File.ReadAllText(path2)) :
				false;
		}



		public static bool IsFolder(string path) => Path.GetExtension(path).Length == 0;



		public static string ExcludePath(string fullPath, string pathBase)
		{
			return fullPath.Replace(pathBase, string.Empty);
		}

		public static string IncludePath(string relativePath, string pathBase)
		{
			return string.Concat(pathBase, relativePath);
		}



		public static void ConsoleWriteLines(IEnumerable<string> lines)
		{
			foreach (var s in lines)
			{
				Console.WriteLine(s);
			}
		}
	}
}