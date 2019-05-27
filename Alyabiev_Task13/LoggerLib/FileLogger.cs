using System;
using System.IO;

namespace EugeneAnykey.DebugLib.Loggers
{
	public class FileLogger : ILogger
	{
		string filename;

		string time => DateTime.Now.ToLongTimeString();



		public FileLogger(string filename)
		{
			this.filename = string.IsNullOrEmpty(filename) ? throw new Exception("Filename should be setted") : filename;
		}

		public void Write(string message)
		{
			File.AppendAllText(filename, $"{time}: {message}\n");
		}

	}
}
