using System;
using System.Collections.Generic;

namespace EugeneAnykey.FileWatcher
{
	public class Trace
	{
		static int lastTraceId = 1;

		// const:
		const string ConsoleSeparator = "\t";
		const string FileSeparator = "|";

		// fields:
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Time { get; private set; }
		public TraceState State { get; private set; }
		public string Param1 { get; private set; }
		public string Param2 { get; private set; }

		// shorts:
		static string GetTime() => DateTime.UtcNow.ToString();
		
		public string ToFileString() => GetString(FileSeparator);
		public string ToConsoleString() => GetString(ConsoleSeparator);



		// init
		public Trace(TraceState state, string param1, string param2 = null) : this(lastTraceId++, GetTime(), state, param1, param2) { }

		internal Trace(int id, string time, TraceState state, params string[] param)
		{
			Id = id;

			if (id > lastTraceId)
				lastTraceId = id + 1;

			Name = Id.ToString();
			Time = time;
			State = state;
            if (param[0] == null)
                throw new ArgumentNullException();

            Param1 = param[0];
			Param2 = param.Length > 1 ? param[1] : null;
		}

		// IO:
		public static bool TryParse(string s, out Trace trace)
		{
			trace = null;
			const char CommentSign = '*';
			if (string.IsNullOrEmpty(s) || s[0] == CommentSign)
				return false;

			var result = false;

			try
			{
				var ss = s.Split('|');
                int i;
				int.TryParse(ss[0], out i);
				var state = TraceStateHelper.FromString(ss[2]);

				trace = ss.Length > 4 ?
					new Trace(i, ss[1], state, ss[3], ss[4]) :
					new Trace(i, ss[1], state, ss[3]);

				result = true;
			}
			catch
			{
				trace = null;
			}

			return result;
		}

		string GetString(string separator)
		{
			var array = new List<string>
			{
				Name,
				GetTime(),
				TraceStateHelper.FromTraceState(State),
				Param1
			};

			if (!string.IsNullOrEmpty(Param2))
				array.Add(Param2);
			
			return string.Join(separator, array);
		}
	}
}
