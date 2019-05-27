using System;
using System.IO;

namespace EugeneAnykey.DebugLib.Loggers
{
	public class FileLogger : ILogger
	{
		readonly string filename;

		string Time => DateTime.UtcNow.ToLongTimeString();

		public FileLogger(string filename)
		{
            if (string.IsNullOrEmpty(filename))
                throw new Exception("Filename should be setted");

            this.filename = filename;
		}

		public void Write(string message)
		{
			File.AppendAllText(filename, $"{Time}: {message}\r\n");
		}
	}
}
