namespace Alyabiev.Task07.Task4
{
	public interface IMovable
	{
		bool TryMoveUp(Bound bounds);
		bool TryMoveDown(Bound bounds);
		bool TryMoveLeft(Bound bounds);
		bool TryMoveRight(Bound bounds);
	}
}