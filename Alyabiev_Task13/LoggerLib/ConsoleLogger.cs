using System;

namespace EugeneAnykey.DebugLib.Loggers
{
	public class ConsoleLogger : ILogger
	{
		public void Write(string message)
		{
			Console.WriteLine("{0}: {1}\n", DateTime.Now.ToLongTimeString(), message);
		}
	}
}
