using System;
using System.Collections.Generic;

namespace Alyabiev.Task02.Task5
{
	class MultiplesSoftCoded
	{
		const int start = 1;

		int[] multiples;


		public MultiplesSoftCoded(int[] multiples)
		{
			this.multiples = multiples ?? new int[0];
		}

		public int[] GetValuesThatIsMultiplies(int value)
		{
			var result = new List<int>();

			for (int i = start; i <= value; i++)
			{
				for (int j = 0; j < multiples.Length; j++)
				{
					if (i % multiples[j] == 0)
					{
						result.Add(i);
						break;
					}
				}
			}
			return result.ToArray();
		}

		public int CalcSum(int[] values)
		{
			var res = 0;
			for (int i = 0; i < values.Length; i++)
			{
				res += values[i];
			}
			return res;
		}
	}
}