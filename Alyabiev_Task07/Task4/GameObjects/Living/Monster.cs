namespace Alyabiev.Task07.Task4
{
	class Monster : MovableObject, ILiving
	{
		readonly string name;
		public string Name => name;

		int health = 10;
		public int Health { get => health; private set => health = value; }

		int attackStrength = 3;

		public Monster(Point pos, string name = "no name") : base(pos, "Monster")
		{
			this.name = name;
		}

		public void Bite(ILiving living)
		{
			living.Health -= attackStrength;
		}
	}
}