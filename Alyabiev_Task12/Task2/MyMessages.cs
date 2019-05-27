namespace Alyabiev.Task12.Task2
{
	internal static class MyMessages
	{
		#region consts
		public static readonly string[] MenuHelp = new[] {
			//"(U)nknown",
			"(W)atch",
			"(T)imemachine",
			"(H)elp",
			"(E)xit",
			//"Error",
			//"Exception"
		};

		public static readonly string[] Help = new[] {
			"",
			"(W)atch — starts watcher for the folder.",
			"(T)imemachine — rollback system.",
			"(H)elp — this page.",
			"(E)xit — closes the program.",
			//"Error",
			//"Exception"
		};

		internal static readonly string Unknown = "[!] unknown command.";
		internal static readonly string Error = "[!] error.";
		internal static readonly string Exception = "[!] exception.";

		internal static readonly string PressAnyKey = "Press any key to continue . . . ";

		internal static readonly string WatcherIsRunning = "Watcher is running . . . ";
		internal static readonly string WatcherIsStoped = "Watcher is stoped . . . ";
		#endregion
	}
}