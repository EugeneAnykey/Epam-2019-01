#define TEST

using System;
using NUnit.Framework;

namespace Alyabiev.Task08.Task1.Tests
{
	#if TEST
	[TestFixture]
	public class Tests
	{
		#region helpers
		string[] GetRippedTestArray => new[] { "a", "b", "c", null, "d", "e", null, null, "f", null, null, null };
		string[] GetNormalTestArray => new[] { "a", "b", "c", "d", null, null, null };
		string[] GetFullTestArray => new[] { "a", "b", "c", "d" };

		int CountNulls<T>(T[] arr)
		{
			if (arr == null)
				throw new ArgumentNullException();

			int count = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == null)
					count++;
			}
			return count;
		}
		#endregion

		#region init
		[Test]
		public void Init_DefaultCapacity_Good()
		{
			const int minExpectedCapacity = 8;
			var da = new DynamicArray<string>();
			
			Assert.GreaterOrEqual(
				da.Capacity,
				minExpectedCapacity
			);
		}

		[Test]
		public void Init_InitLength_Good()
		{
			const int expectedLength = 0;
			var da = new DynamicArray<string>();

			Assert.AreEqual(
				da.Length,
				expectedLength
			);
		}

		[Test]
		public void Init_MiscCapacity_Good()
		{
			const int minExpectedCapacity = 20;
			var da = new DynamicArray<string>(minExpectedCapacity);

			Assert.GreaterOrEqual(
				da.Capacity,
				minExpectedCapacity
			);
		}

		[Test]
		public void Init_LessThan1_Throws()
		{
			Assert.Catch<ArgumentException>( () => new DynamicArray<string>(0) );
		}
		#endregion

		#region Add
		[Test]
		public void Add_NormalArray_Good()
		{
			var na = GetNormalTestArray;
			var da = new DynamicArray<string>(na);
			int index = da.Length;
			const string expected = "abc";
			da.Add(expected);

			Assert.AreEqual(
				expected,
				da[index]
			);
		}

		[Test]
		public void Add_FullArray_Good()
		{
			var na = GetFullTestArray;
			var da = new DynamicArray<string>(na);
			int index = da.Length;
			const string expected = "abc";
			da.Add(expected);

			Assert.AreEqual(
				expected,
				da[index]
			);
		}
		#endregion

		#region AddRange
		[Test]
		public void AddRange_NormalArray_Good()
		{
			var na = GetNormalTestArray;
			var addon = new[] { "abc", "xyz" };
			var da = new DynamicArray<string>(na);
			
			da.AddRange(new DynamicArray<string>(addon));

			Assert.AreEqual(
				addon[1],
				da[da.Length - 1]
			);
		}

		[Test]
		public void AddRange_FullArrayPlusSmallerArray_Good()
		{
			var na = GetFullTestArray;
			var addon = new[] { "abc", "xyz" };
			var da = new DynamicArray<string>(na);

			da.AddRange(new DynamicArray<string>(addon));

			Assert.AreEqual(
				addon[addon.Length - 1],
				da[da.Length - 1]
			);
		}

		[Test]
		public void AddRange_FullArrayPlusBiggerArray_Good()
		{
			var na = GetFullTestArray;
			var addon = new[] { "abc", "def", "ghi", "jkl", "mno", "pqr", "stu", "vw", "xyz" };
			var da = new DynamicArray<string>(na);

			da.AddRange(new DynamicArray<string>(addon));

			Assert.AreEqual(
				addon[addon.Length - 1],
				da[da.Length - 1]
			);
		}
		#endregion

		#region Insert
		[Test]
		public void Insert_NormalArray_Good()
		{
			var da = new DynamicArray<string>(GetNormalTestArray);
			int index = 2;
			const string expected = "123";
			string expectedBeforeInsert = da[index];

			da.Insert(expected, index);

			Assert.AreEqual(
				expected,
				da[index]
			);

			Assert.AreEqual(
				expectedBeforeInsert,
				da[index + 1]
			);
		}

		[Test]
		public void Insert_FullArray_Good()
		{
			var da = new DynamicArray<string>(GetFullTestArray);
			int index = 2;
			const string expected = "123";
			string expectedBeforeInsert = da[index];

			da.Insert(expected, index);

			Assert.AreEqual(
				expected,
				da[index]
			);

			Assert.AreEqual(
				expectedBeforeInsert,
				da[index + 1]
			);
		}

		[TestCase(-9)]
		[TestCase(-1)]
		[TestCase(5)]
		[TestCase(9)]
		public void Insert_OutOfRange_Throws(int index)
		{
			var da = new DynamicArray<string>(GetNormalTestArray);
			string res = string.Empty;

			Assert.Catch<ArgumentOutOfRangeException>(() => da.Insert("123", index));
		}
		#endregion

		#region Remove
		[Test]
		public void Remove_NormalArray_Good()
		{
			var na = GetNormalTestArray;
			var da = new DynamicArray<string>(na);
			int index = 2;
			string expected = na[index + 1];
			
			da.Remove(index);

			Assert.AreEqual(
				expected,
				da[index]
			);
		}

		[TestCase(-9)]
		[TestCase(-1)]
		[TestCase(5)]
		[TestCase(9)]
		public void Remove_OutOfRange_Throws(int index)
		{
			var da = new DynamicArray<string>(GetNormalTestArray);
			string res = string.Empty;

			Assert.Catch<ArgumentOutOfRangeException>(() => da.Remove(index));
		}
		#endregion

		#region indexer
		[TestCase(-9)]
		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(9)]
		public void Init_IndexerOnEmpty_Throws(int index)
		{
			var da = new DynamicArray<string>();
			string res = string.Empty;

			Assert.Catch<ArgumentOutOfRangeException>( () => res = da[index]);
		}

		[TestCase(-9)]
		[TestCase(-1)]
		[TestCase(4)]
		[TestCase(9)]
		public void Init_IndexerOnFilled_Throws(int index)
		{
			var da = new DynamicArray<string>(GetNormalTestArray);
			string res = string.Empty;

			Assert.Catch<ArgumentOutOfRangeException>(() => res = da[index]);
		}

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Init_IndexerOnFilled_ReturnsGood(int index)
		{
			var na = GetNormalTestArray;
			var da = new DynamicArray<string>(na);
			string expected = na[index];

			Assert.AreEqual(
				expected,
				da[index]
			);
		}
		#endregion
	}
#endif
}