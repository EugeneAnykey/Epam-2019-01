using System;
using EugeneAnykey.DebugLib.Loggers;
using EugeneAnykey.FileWatcher;

namespace Alyabiev.Task12.Task2
{
	public class Runner
	{
		#region field
		AppStates state = AppStates.Unknown;
		public AppStates State
		{
			get
            {
                return state;
            }
			set
			{
				state = value;
				StateAction(state);
			}
		}

		readonly Tracer tracer;
		readonly Watcher watcher;
		readonly TimeMachine timeMachine;

		ILogger logger;
		#endregion

		#region init
		public Runner(string path)
		{
			Helper.CheckAndCreateDir(path);

			logger = new FileAndConsoleLogger("log.txt");

			tracer = new Tracer(path);

			watcher = new Watcher(path, tracer) { Logger = logger };

			timeMachine = new TimeMachine(tracer) { Logger = logger };

			State = AppStates.Unknown;
		}
		#endregion

		#region public: Loop.
		public void Loop()
		{
			while (State != AppStates.Exit)
			{
				Console.WriteLine();
				Console.WriteLine("Menu:\n\t{0}\n", string.Join("\n\t", MyMessages.MenuHelp));
				Console.Write("Action? : ");
				var key = Console.ReadKey();
				Console.WriteLine("\n");
				State = StatesHelper.Parse(key.KeyChar);
			}
		}
		#endregion

		#region StateAction
		void StateAction(AppStates state)
		{
			switch (state)
			{
				case AppStates.Unknown:
					Console.WriteLine(MyMessages.Unknown);
					break;
				case AppStates.Watch:
					Watch();
					break;
				case AppStates.Timemachine:
					Timemachine();
					break;
				case AppStates.Help:
					Help();
					break;
				case AppStates.Exit:
					break;
				case AppStates.Error:
					Console.WriteLine(MyMessages.Error);
					state = AppStates.Exit;
					break;
				case AppStates.Exception:
					Console.WriteLine(MyMessages.Exception);
					state = AppStates.Exit;
					break;
				default:
					break;
			}
		}
		#endregion

		#region Help, Watch, Timemachine.
		void Help()
		{
			Console.WriteLine();
			Console.WriteLine("Help:\n\t");
			Console.WriteLine(string.Join("\n\t", MyMessages.Help));
			Console.WriteLine();

			Console.WriteLine(MyMessages.PressAnyKey);
			Console.ReadKey();
		}

		void Watch()
		{
			ToggleWatcher();
		}

		void ToggleWatcher()
		{
			if (AppStates.Watch == state)
			{
				if (!watcher.IsRunning)
					watcher.Run();

				if (watcher.IsRunning)
					Console.WriteLine(MyMessages.WatcherIsRunning);
			}
			else
			{
				if (watcher.IsRunning)
					watcher.Stop();

				if (!watcher.IsRunning)
					Console.WriteLine(MyMessages.WatcherIsStoped);
			}
		}

		void Timemachine()
		{
			ToggleWatcher();
			
			Helper.ConsoleWriteLines(tracer.GetTracesLines());

			timeMachine.ConsoleLoop();

			state = AppStates.Unknown;
		}
		#endregion
	}
}
