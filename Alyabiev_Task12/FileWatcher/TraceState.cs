namespace EugeneAnykey.FileWatcher
{
	public enum TraceState { Unknown, Create, Change, Rename, Delete, CreateDir, ChangeDir, RenameDir, DeleteDir, DoesNotMatter }



	public static class TraceStateHelper
	{
		public static readonly string[] StatesStrings = new[] { "Unknown", "Create", "Change", "Rename", "Delete", "CreateDir", "ChangeDir", "RenameDir", "DeleteDir", "DoesNotMatter" };

		public static TraceState FromString(string line)
		{
			for (int i = 0; i < StatesStrings.Length; i++)
			{
				if (StatesStrings[i] == line)
					return (TraceState)i;
			}
			return 0;
		}

		public static string FromTraceState(TraceState state) => StatesStrings[(int)state];

	}
}
