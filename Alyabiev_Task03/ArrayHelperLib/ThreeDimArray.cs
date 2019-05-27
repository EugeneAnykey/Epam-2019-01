using System;

namespace Alyabiev.Task03.ArrayHelperLib
{
	public static class ThreeDimArray
	{
		//delegate void Do(int x, int y, int z);

		/// <summary>
		/// traversing an array.
		/// </summary>
		/// <param name="array">input array</param>
		/// <param name="f">do something with array at pos.</param>
		static void Iterate3d(int[,,] array, Do3d f)
		{
			if (array == null)
				throw new ArgumentNullException();

			if (array.Length == 0)
				return;

			int lenX = array.GetLength(0);
			int lenY = array.GetLength(1);
			int lenZ = array.GetLength(2);

			for (int i = 0; i < lenX; i++)
			{
				for (int j = 0; j < lenY; j++)
				{
					for (int k = 0; k < lenZ; k++)
					{
						f(i, j, k);
					}
				}
			}
		}

		/// <summary>
		/// Generates new 3D array
		/// </summary>
		/// <param name="countX">count of elements in x dimention</param>
		/// <param name="countY">count of elements in y dimention</param>
		/// <param name="countZ">count of elements in z dimention</param>
		/// <returns></returns>
		public static int[,,] Generate(int countX, int countY, int countZ)
		{
			if (countX < 1 || countY < 1 || countZ < 1)
				throw new ArgumentException("Значение должно быть более 0.");

			return new int[countX, countY, countZ];
		}


		/// <summary>
		/// Filling array with random values from min to max.
		/// </summary>
		/// <param name="array">array of integers</param>
		/// <param name="min">min value</param>
		/// <param name="max">max value</param>
		public static void FillWithRandom(this int[,,] array, int min = 0, int max = 1000)
		{
			var r = new Random((int)DateTime.Now.Ticks);
			Iterate3d(array, (x, y, z) => { array[x, y, z] = r.Next(min, max); });
		}

		/// <summary>
		/// Sets array's element to zero if it is bigger than 0.
		/// </summary>
		/// <param name="array">3D int array</param>
		public static void SetPositivesToZero(this int[,,] array)
		{
			Iterate3d(array, (x, y, z) => { if (array[x, y, z] > 0) array[x, y, z] = 0; });
		}

		/// <summary>
		/// Outputs three dimentional array in one string.
		/// </summary>
		/// <param name="array">array to output.</param>
		/// <returns>string with integers separated by tabs</returns>
		public static string ToSingleString(this int[,,] array)
		{
			const string mask = "{0}\t";
			var separator = new char[] { '\t' };

			var sb = new System.Text.StringBuilder();

			Iterate3d(array, (x, y, z) => { sb.AppendFormat(mask, array[x, y, z]); });

			return string.Format("[{0}]", sb.ToString().TrimEnd(separator));
		}
	}
}