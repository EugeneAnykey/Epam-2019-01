using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EugeneAnykey.FileWatcher
{
	public class Tracer
	{
		// const:
		const string OnlyTracerDir = ".traces";
		const string OnlyTracerFilename = "_traces.txt";

		public bool IsTracerPath(string path) => path.Contains(OnlyTracerDir);

		// fields:
		readonly string LookupPath;
		readonly string tracerDirPath;
		readonly string tracerFilePath;
		readonly StreamWriter writer;
		readonly List<Trace> traces = new List<Trace>();

		Trace LastTrace => traces.LastOrDefault();



		// shorts:
		public List<string> GetTracesLines() => (from t in traces orderby t.Id select t.ToConsoleString()).ToList();



		// init
		public Tracer(string lookUp)
		{
			LookupPath = lookUp;
            tracerDirPath = Path.Combine(lookUp, OnlyTracerDir);
            Helper.CheckAndCreateDir(tracerDirPath);

            tracerFilePath = Path.Combine(tracerDirPath, OnlyTracerFilename);

			if (!File.Exists(tracerFilePath))
				using (writer = File.CreateText(tracerFilePath)) { writer.WriteLine("* Eugene Anykey's tracer log."); }

			var tempLines = File.ReadAllLines(tracerFilePath);
			LoadTraces(tempLines);
			writer = File.AppendText(tracerFilePath);
		}

		void LoadTraces(string[] lines)
		{
			foreach (var s in lines)
			{
                Trace trace;
				if (Trace.TryParse(s, out trace))
					traces.Add(trace);
			}
		}





		#region actions
		public void Changed(string fullPath)
		{
			if (SameAsLast(fullPath))
				return;

			var tracedName = MakeTrace(TraceState.Change, fullPath);
			MakeCopy(tracedName, fullPath);
		}

		public void Created(string fullPath)
		{
			if (SameAsLast(fullPath, TraceState.Create))
				return;

			var tracedName = MakeTrace(TraceState.Create, fullPath);
			MakeCopy(tracedName, fullPath);
		}

		public void Deleted(string fullPath)
		{
            // look up for this file, while it was there
            var similarTrace = SearchTraceBeforeDelete(fullPath);

            if (similarTrace == null)
                // the file was not exist previously,
                return;

            var tracedName = MakeTrace(TraceState.Delete, fullPath);

            // magic:
            // now: fullPath = similarTrace.Path
            fullPath = Path.Combine(tracerDirPath, similarTrace.Name);
            MakeCopy(tracedName, fullPath);
        }

        Trace SearchTraceBeforeDelete(string path)
        {
            for (int i = traces.Count - 1; i >= 0; i--)
            {
                Trace current = traces[i];

                var shortPath = Helper.ExcludePath(path, LookupPath);
                if (current.Param1.Equals(shortPath))
                    return current;
            }

            return null;
        }

		public void Renamed(string oldFullPath, string fullPath)
		{
			if (SameAsLast(fullPath, TraceState.Rename))
				return;

            var tracedName = MakeTrace(TraceState.Rename, oldFullPath, fullPath);
            MakeCopy(tracedName, fullPath);
        }
		#endregion



		void MakeCopy(string tracedName, string path)
		{
			if (File.Exists(path))
				File.Copy(path, Path.Combine(tracerDirPath, tracedName));
		}

		

		bool SameAsLast(string path, TraceState state)
		{
			return LastTrace != null ?
				state == LastTrace.State && Helper.FilesEquals(TracedFilePath(LastTrace.Name), path) :
				false;
		}

		bool SameAsLast(string path)
		{
			return LastTrace != null ?
				Helper.FilesEquals(TracedFilePath(LastTrace.Name), path) :
				false;
		}

		string TracedFilePath(string name) => Path.Combine(tracerDirPath, name);





		// Make trace:
		string MakeTrace(TraceState state, params string[] lines)
		{
			var trace = lines.Length > 1 ?
				new Trace(state, Helper.ExcludePath(lines[0], LookupPath), Helper.ExcludePath(lines[1], LookupPath)) :
				new Trace(state, Helper.ExcludePath(lines[0], LookupPath));

			traces.Add(trace);

			writer.WriteLine(trace.ToFileString());
			writer.Flush();

			return trace.Name;
		}



		// for timeMachine:
		public bool IsIn(int index)
		{
			return traces.Count > index && index >= 0;
		}

		public void TryRollback()
		{
			var last = LastTrace;

            if (last == null)
                throw new ArgumentException();

            // trying to rollback last:
            switch (last.State)
            {
                /*
                case TraceState.Unknown:
                    // do nothing
                    break;
                    */
                case TraceState.Create:
                    RollbackCreate(last);
                    break;
                case TraceState.Change:
                    RollbackChange(last);
                    break;
                case TraceState.Rename:
                    RollbackRename(last);
                    break;
                case TraceState.Delete:
                    RollbackDelete(last);
                    break;
                /*case TraceState.CreateDir:
                    break;
                case TraceState.ChangeDir:
                    break;
                case TraceState.RenameDir:
                    break;
                case TraceState.DeleteDir:
                    break;
                case TraceState.DoesNotMatter:
                    break;*/
                default:
                    break;
            }

            // and finally:
            DeleteLastTrace();
		}

        void RollbackFile(string tracedName, string realName, bool overrideFile = false)
        {
            //realName = realName.TrimStart( new[] { '\\' });
            var path1 = Path.Combine(tracerDirPath, tracedName);
            if (File.Exists(path1))
            {
                //var p = LookupPath + "\\";
                var path2 = CombinePath(LookupPath, realName);

                //path2 = p + realName;
                File.Copy(path1, path2, overrideFile);
            }
        }

        string CombinePath(string path1 , string path2)
        {
            path2 = path2.TrimStart(new[] { '\\' });
            return Path.Combine(path1, path2);
        }

        #region rollback
        void RollbackDelete(Trace t)
        {
            RollbackFile(t.Name, t.Param1);
        }

        void RollbackRename(Trace t)
        {
            var path = CombinePath(LookupPath, t.Param2);
            //Path.Combine(LookupPath, t.Param2);
            //LookupPath + t.Param2;
            File.Delete(path);
            RollbackFile(t.Name, t.Param1);
        }

        void RollbackCreate(Trace t)
        {
            var path = CombinePath(LookupPath, t.Param1);
            //var path = Path.Combine(LookupPath, t.Param1);
            File.Delete(path);
        }

        void RollbackChange(Trace t)
        {
            RollbackFile(t.Name, t.Param1, true);
        }
        #endregion

        #region delete trace
        void DeleteLastTrace()
        {
            DeleteLastTraceInList();
            DeleteLastTraceInFile();
        }

        void DeleteLastTraceInList()
        {
            var t = LastTrace;
            traces.Remove(t);
            var path = Path.Combine(tracerDirPath, t.Name);
            File.Delete(path);
        }

        void DeleteLastTraceInFile()
        {
            // from file
            if (writer != null)
                return;

            var lines = File.ReadAllLines(tracerFilePath);
            lines[lines.Length - 1] = null;
            File.WriteAllLines(tracerFilePath, lines);

        }
        #endregion
    }
}
