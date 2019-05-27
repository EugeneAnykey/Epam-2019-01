using System;
using System.Text;

namespace Alyabiev.Task03.ArrayHelperLib
{
	public static class TwoDimArray
	{
		/// <summary>
		/// traversing an array.
		/// </summary>
		/// <param name="array">input array</param>
		/// <param name="f">do something with array at pos.</param>
		static void Iterate2d(int[,] array, Do2d f)
		{
			if (array == null)
				throw new ArgumentNullException();

			if (array.Length == 0)
				return;

			int lenX = array.GetLength(0);
			int lenY = array.GetLength(1);

			for (int i = 0; i < lenX; i++)
			{
				for (int j = 0; j < lenY; j++)
				{
					f(i, j);
				}
			}
		}

		/// <summary>
		/// Generates new 2D array
		/// </summary>
		/// <param name="countX">count of elements in x dimention</param>
		/// <param name="countY">count of elements in y dimention</param>
		/// <returns></returns>
		public static int[,] Generate(int countX, int countY)
		{
			if (countX < 1 || countY < 1)
				throw new ArgumentException("Значение должно быть более 0.");

			return new int[countX, countY];
		}



		/// <summary>
		/// Filling array with random values from min to max.
		/// </summary>
		/// <param name="array">array of integers</param>
		/// <param name="min">min value</param>
		/// <param name="max">max value</param>
		public static void FillWithRandom(this int[,] array, int min = 0, int max = 1000)
		{
			var r = new Random((int)DateTime.Now.Ticks);
			Iterate2d(array, (x, y) => { array[x, y] = r.Next(min, max); });
		}

		public static int SumOnEvenPos(this int[,] array)
		{
			var sum = 0;
			Iterate2d(array, (x, y) => { if ((x + y) % 2 == 0) sum += (array[x, y]); });
			return sum;
		}

		public static string ToSingleString(this int[,] array)
		{
			const string mask = "{0}\t";
			const string maskN = "\n{0}\t";
			var separator = new char[] { '\n', '\t' };

			var sb = new StringBuilder();

			Iterate2d(array, (x, y) => { sb.AppendFormat(y == 0 ? maskN : mask, array[x, y]); });

			return string.Format("[{0}]", sb.ToString().TrimEnd(separator).TrimStart(separator));
		}

	}
}