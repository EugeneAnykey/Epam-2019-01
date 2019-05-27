using System;

namespace Alyabiev.Task03.ArrayHelperLib
{
	public static class OneDimArray
	{
		delegate bool Condition(int a);

		static int Sum(int[] array, Condition cond)
		{
			var res = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (cond(i))
					res += array[i];
			}

			return res;
		}

		public static int SumNonNegatives(int[] array) => Sum(array, i => array[i] >= 0);



		public static int[] Generate(int count) => new int[count];

		public static void Randomize(this int[] array, int min = 0, int max = 1000)
		{
			var r = new Random((int)DateTime.Now.Ticks);

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = r.Next(min, max);
			}
		}

		public static int Max(int[] array)
		{
			if (array == null)
				throw new ArgumentNullException();

			if (array.Length == 0)
				throw new ArgumentException("В метод не передано ни одного значения");

			int index = 0;

			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] > array[index])
					index = i;
			}

			return array[index];
		}

		public static int Min(int[] array)
		{
			if (array == null)
				throw new ArgumentNullException();

			if (array.Length == 0)
				throw new ArgumentException("В метод не передано ни одного значения");

			int index = 0;

			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] < array[index])
					index = i;
			}

			return array[index];
		}

		public static void Sort(int[] array)
		{
			if (array == null)
				throw new ArgumentNullException();

			for (int i = 0; i < array.Length; i++)
			{
				for (int j = i; j < array.Length; j++)
				{
					if (array[i] > array[j])
					{
						var temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}
		}

		public static string ToSingleString(this int[] array)
		{
			const string mask = "{0}\t";
			var separator = new char[] { '\t' };

			if (array == null || array.Length == 0)
				return "[none]";

			var sb = new System.Text.StringBuilder();

			for (int i = 0; i < array.Length; i++)
				sb.AppendFormat(mask, array[i]);

			return string.Format("[{0}]", sb.ToString().TrimEnd(separator));
		}

	}
}
