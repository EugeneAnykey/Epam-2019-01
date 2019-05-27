namespace EugeneAnykey.DebugLib.Loggers
{
	public class FileAndConsoleLogger : ILogger
	{
		FileLogger fileLogger;
		ConsoleLogger consoleLogger;

		public FileAndConsoleLogger(string filename)
		{
			consoleLogger = new ConsoleLogger();
			fileLogger = new FileLogger(filename);
		}

		public void Write(string message)
		{
			consoleLogger.Write(message);
			fileLogger.Write(message);
		}

	}
}
