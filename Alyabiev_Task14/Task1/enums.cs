namespace Alyabiev.Task14.Task1
{
	public enum SortOrder
	{
		//NoSort,
		Asc,
		Desc
	};



	public static class SortOrderHelper
	{
		public static SortOrder Next(SortOrder current)
		{
			return SortOrder.Asc == current ? SortOrder.Desc : SortOrder.Asc;
			/*
				SortOrder.NoSort == current ? SortOrder.Asc :
				SortOrder.Asc == current ? SortOrder.Desc :
				SortOrder.NoSort;
			*/
		}

		public static SortOrder Next(ref SortOrder current) => current = SortOrder.Asc == current ? SortOrder.Desc : SortOrder.Asc;
	}
}
