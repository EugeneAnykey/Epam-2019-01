namespace Alyabiev.Task07.Task4
{
	public class Bound
	{
		readonly Point bottom;
		public Point Bottom => bottom;

		readonly Point top;
		public Point Top => top;

		public Bound(Point bottom, Point top)
		{
			this.bottom = bottom;
			this.top = top;
		}

		public bool IsIn(Point pos)
		{
			return bottom.IsLessOrEqual(pos) && top.IsGreaterOrEqual(pos);
		}
	}
}