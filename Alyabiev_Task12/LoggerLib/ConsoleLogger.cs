using System;

namespace EugeneAnykey.DebugLib.Loggers
{
	public class ConsoleLogger : ILogger
	{
		string Time => DateTime.UtcNow.ToLongTimeString();

		public void Write(string message)
		{
			Console.WriteLine($"{Time}: {message}\n");
		}
	}
}
