using System;

namespace Alyabiev.Task07.Task4
{
	public class GameObject
	{
		protected Point position;
		public Point Position { get => position; private set => position = value; }

		readonly string type;
		public string Type => type;

		public GameObject(Point pos, string type = "Type")
		{
			position = pos;
			this.type = type;
		}
	}
}