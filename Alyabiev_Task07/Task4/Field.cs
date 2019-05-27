using System.Collections.Generic;

namespace Alyabiev.Task07.Task4
{
	public class Field
	{
		readonly Bound fieldBound;

		readonly int width;
		readonly int height;

		List<GameObject> items = new List<GameObject>();

		public Field(int width, int height)
		{
			fieldBound = new Bound(new Point(0, 0), new Point(width - 1, height - 1));

			this.width = width;
			this.height = height;
		}

		

		public void AddObjects(GameObject[] newObjects)
		{
			foreach (var item in newObjects)
			{
				if (items.Contains(item))
					continue;
				
				items.Add(item);
				if (!CheckPositionBounds(item)) {
					
				}
			}
		}

		bool CheckPositionBounds(GameObject obj)
		{
			return fieldBound.IsIn(obj.Position);
		}
	}
}