using System;

namespace Alyabiev.Task07.Task4
{
	public class Obstacle : GameObject
	{
		readonly string name;
		public string Name => name;

		public Obstacle(Point pos, string name = "some obstacle") : base(pos, "Obstacle")
		{
			this.name = name;
		}
	}
}