using System;

namespace Alyabiev.Task10
{
	public static class SorterTread
	{
		static object syncLock = new object();

		public static void Sort(string[] lines, CompareFunc<string> comparator, Action callback)
		{
			lock (syncLock)
			{
				Sorter.Sort(lines, comparator);
			}

			callback();
		}
	}
}