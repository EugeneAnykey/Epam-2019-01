using System;
using System.Collections.Generic;
using System.IO;
using EugeneAnykey.DebugLib.Loggers;

namespace EugeneAnykey.FileWatcher
{
	public class Watcher
	{
		// fields:
		readonly Tracer tracer;

		readonly FileSystemWatcher fsWatcher = new FileSystemWatcher();

		public bool IsRunning => fsWatcher.EnableRaisingEvents;

		public ILogger Logger { get; set; }


		// filter fields:
		readonly List<string> includeFilter = new List<string> { ".txt", ".log" };
		public List<string> IncludeFilter => includeFilter;
		public bool WatchFolders { get; set; }

		

		// init:
		public Watcher(string lookupPath, Tracer tracer)
		{
			this.tracer = tracer;

			fsWatcher.Path = lookupPath;
			fsWatcher.IncludeSubdirectories = true;

			WatchFolders = true;

			InitEvents();
		}

		void InitEvents()
		{
			fsWatcher.Changed += DataChanged;
			fsWatcher.Created += DataCreated;
			fsWatcher.Deleted += DataDeleted;
			fsWatcher.Renamed += DataRenamed;
		}



		// filter:
		bool AreWeWatchingThis(string path)
		{
			if (tracer.IsTracerPath(path))
				return false;

			if (Helper.IsFolder(path) && WatchFolders)
				return true;

			return Helper.IsOneFromList(Path.GetExtension(path), IncludeFilter);
		}

		DataType WhatIsThis(string path) => Helper.IsFolder(path) ? DataType.Directory : DataType.File;



		#region eventsHandlers
		private void DataRenamed(object sender, RenamedEventArgs e)
		{
			var dt = WhatIsThis(e.OldFullPath);

			if (!AreWeWatchingThis(e.OldFullPath))
				return;

			Logger?.Write($"\tRenamed <{e.OldName}> -> <{e.Name}>\n");
			tracer.Renamed(e.OldFullPath, e.FullPath);
		}

		private void DataDeleted(object sender, FileSystemEventArgs e)
		{
			// exception - no file to check
			if (!AreWeWatchingThis(e.FullPath))
				return;

			Logger?.Write($"\tDeleted <{e.Name}>\n");
			tracer.Deleted(e.FullPath);
		}

		private void DataCreated(object sender, FileSystemEventArgs e)
		{
			if (!AreWeWatchingThis(e.FullPath))
				return;

			Logger?.Write($"\tCreated <{e.Name}>\n");
			tracer.Created(e.FullPath);
		}

		private void DataChanged(object sender, FileSystemEventArgs e)
		{
			if (!AreWeWatchingThis(e.FullPath))
				return;

			Logger?.Write($"\tChanged <{e.Name}>\n");
			tracer.Changed(e.FullPath);
		}
		#endregion



		public void Run()
		{
			Logger?.Write($"<Watcher> Started at {DateTime.UtcNow}.");

			fsWatcher.EnableRaisingEvents = true;
		}

		public void Stop()
		{
			Logger?.Write($"<Watcher> Stopped at {DateTime.UtcNow}.");

			fsWatcher.EnableRaisingEvents = false;
		}
	}
}
