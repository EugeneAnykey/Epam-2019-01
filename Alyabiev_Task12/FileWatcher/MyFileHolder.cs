using System;
using System.IO;

namespace EugeneAnykey.FileWatcher
{
	public class MyFileHolder
	{
		#region field
		string originalPath;
		public string OriginalPath => originalPath;

		string currentPath;

		DateTime changesFrom;
		public DateTime ChangesFrom => changesFrom;
		#endregion

		#region init
		public MyFileHolder(string originalPath)
		{
			changesFrom = DateTime.UtcNow;
			this.originalPath = originalPath;
			currentPath = MakeCurrentPath(PathToName(originalPath), changesFrom);
		}
		#endregion

		#region public
		public static MyFileHolder TryParse(string possible)
		{
			MyFileHolder res =
				//new MyFileHolder();
				null;

			return res;
		}

		public void MakeCopy()
		{
			var bytes = File.ReadAllBytes(originalPath);
			File.WriteAllBytes(currentPath, bytes);
		}

		public bool ReturnFile()
		{
			try
			{
				File.Delete(originalPath);
				File.Move(currentPath, originalPath);
			}
			catch (IOException)
			{
				return false;
			}

			return true;
		}
		#endregion

		#region private
		string PathToName(string path)
		{
			var res = path;
			return res.Replace('/', '_').Replace('\\', '_');
		}

		string MakeCurrentPath(string name, DateTime date)
		{
			const string boxDir = "~box";
			const string joiner = "~";

			return Path.Combine(boxDir, $"{name}", joiner, $"{date:yyyy-MM-dd--hh-mm-ss}");
		}
		#endregion
	}
}
