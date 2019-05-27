namespace EugeneAnykey.FileWatcher
{
	public enum AppStates
	{
		Unknown,
		Watch,
		Timemachine,
		Help,
		Exit,
		Error,
		Exception
	}

	public static class StatesHelper
	{
		public static AppStates Parse(char ch)
		{
			switch (ch)
			{
				case 'w':
					return AppStates.Watch;
				case 't':
					return AppStates.Timemachine;
				case 'h':
					return AppStates.Help;
				case 'e':
					return AppStates.Exit;
				default:
					return AppStates.Unknown;
			}
		}
	}
}
