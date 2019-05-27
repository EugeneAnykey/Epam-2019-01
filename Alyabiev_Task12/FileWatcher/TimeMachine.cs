using EugeneAnykey.DebugLib.Loggers;
using System;

namespace EugeneAnykey.FileWatcher
{
	public class TimeMachine
	{
		readonly Tracer tracer;

		public ILogger Logger { get; set; }

		public TimeMachine(Tracer tracer)
		{
			this.tracer = tracer;
		}

		public void ConsoleLoop()
		{
			Logger?.Write($"<Time Machine> start.");
			Console.WriteLine("Type <index> to rollback or <0> to exit.");

			int index = -1;

			while (index < 0)
			{
				Console.Write("Enter trace index you want to return to: ");
				var s = Console.ReadLine();

				var parseResult = int.TryParse(s, out index);

				if (!parseResult)
				{
					index = -1;
					Logger?.Write("Bad index\n");
					continue;
				}

				if (index == 0)
				{
					Logger?.Write("<Time machine> done.\n");
					return;
				}

                index--;
                if (!tracer.IsIn(index))
				{
					index = -1;
					Logger?.Write("Index out of range.\n");
					continue;
				}
			}

			while (!RollbackDone(index)) { };
		}

		bool RollbackDone(int index)
		{
			if (tracer.IsIn(index))
			{
				tracer.TryRollback();
				return false;
			}

			return true;
		}
	}
}
