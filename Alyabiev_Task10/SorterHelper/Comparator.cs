using System;

namespace Alyabiev.Task10
{
	public static class Comparator
	{
		public static int MyCompare(string left, string right)
		{
			// length, then symbols

			if (left.Length == right.Length)
				return left.CompareTo(right);

			return left.Length < right.Length ? 1 : -1;
		}
	}
}