using System;
using NUnit.Framework;

namespace Alyabiev.Task07.Task4.Tests
{
	[TestFixture]
	public class PointTests
	{
		#region init
		[Test]
		public void Init_Good()
		{
			var point = new Point();
			
			Assert.IsNotNull(
				point
			);
		}

		[Test]
		public void Init_Misc_Good()
		{
			const int expectedX = 3;
			const int expectedY = 2;

			var point = new Point(expectedX, expectedY);

			Assert.AreEqual(
				expectedX,
				point.X
			);

			Assert.AreEqual(
				expectedY,
				point.Y
			);
		}
		#endregion

		#region IsGreaterOrEqual, IsLessOrEqual.
		[TestCase(5, 6)]
		[TestCase(3, 6)]
		[TestCase(5, 2)]
		[TestCase(3, 2)]
		public void IsGreaterOrEqual_ThanThreeAndTwo_True(int x, int y)
		{
			var point = new Point(3, 2);

			var pointTest = new Point(x, y);

			Assert.IsTrue(
				pointTest.IsGreaterOrEqual(point)
			);
		}

		[TestCase(2, 2)]
		[TestCase(3, 1)]
		[TestCase(1, 1)]
		[TestCase(-2, -1)]
		public void IsGreaterOrEqual_ThanThreeAndTwo_False(int x, int y)
		{
			var point = new Point(3, 2);

			var pointTest = new Point(x, y);

			Assert.IsFalse(
				pointTest.IsGreaterOrEqual(point)
			);
		}

		[TestCase(3, 2)]
		[TestCase(3, 1)]
		[TestCase(1, 2)]
		[TestCase(-2, -1)]
		public void IsLessOrEqual_ThanThreeAndTwo_True(int x, int y)
		{
			var point = new Point(3, 2);

			var pointTest = new Point(x, y);

			Assert.IsTrue(
				pointTest.IsLessOrEqual(point)
			);
		}

		[TestCase(5, 6)]
		[TestCase(3, 6)]
		[TestCase(4, 2)]
		[TestCase(3, 3)]
		public void IsLessOrEqual_ThanThreeAndTwo_False(int x, int y)
		{
			var point = new Point(3, 2);

			var pointTest = new Point(x, y);

			Assert.IsFalse(
				pointTest.IsLessOrEqual(point)
			);
		}
		#endregion


	}
}