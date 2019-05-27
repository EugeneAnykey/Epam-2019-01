namespace Alyabiev.Task07.Task4
{
	public class MovableObject : GameObject, IMovable
	{
		public MovableObject(Point pos, string type) : base(pos, type)
		{
		}

		public bool TryMoveUp(Bound bounds)
		{
			var newPos = new Point(Position.X, Position.Y + 1);
			if (bounds.IsIn(newPos)) {
				position.Y += 1;
				return true;
			}
			return false;
		}

		public bool TryMoveDown(Bound bounds)
		{
			var newPos = new Point(Position.X, Position.Y - 1);
			if (bounds.IsIn(newPos))
			{
				position.Y -= 1;
				return true;
			}
			return false;
		}

		public bool TryMoveLeft(Bound bounds)
		{
			var newPos = new Point(Position.X - 1, Position.Y);
			if (bounds.IsIn(newPos))
			{
				position.X -= 1;
				return true;
			}
			return false;
		}

		public bool TryMoveRight(Bound bounds)
		{
			var newPos = new Point(Position.X + 1, Position.Y);
			if (bounds.IsIn(newPos))
			{
				position.X += 1;
				return true;
			}
			return false;
		}
	}
}
