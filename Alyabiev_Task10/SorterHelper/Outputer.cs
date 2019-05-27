using System;

namespace Alyabiev.Task10
{
	public static class Outputter
	{
		public static void WriteToConsole(string message, string[] lines)
		{
			Console.WriteLine(message);
			Console.WriteLine(string.Join(" ", lines));
			Console.WriteLine();
			Console.WriteLine();
		}
	}
}