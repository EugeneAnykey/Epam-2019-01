using System;

namespace Alyabiev.Task07.Task4
{
	public struct Point
	{
		int x;
		public int X { get => x; set => x = value; }
		
		int y;
		public int Y { get => y; set => y = value; }

		public Point(int x = 0, int y = 0)
		{
			this.x = x;
			this.y = y;
		}

		public Point(Point p)
		{
			this.x = p.x;
			this.y = p.y;
		}

		public bool IsGreaterOrEqual(Point other)
		{
			return x >= other.x && y >= other.y; 
		}

		public bool IsLessOrEqual(Point other)
		{
			return x <= other.x && y <= other.y;
		}
	}
}