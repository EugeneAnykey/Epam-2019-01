namespace Alyabiev.Task07.Task4
{
	class Personage : MovableObject, ILiving
	{
		readonly string name;
		public string Name => name;

		readonly Sex sex;
		public Sex Sex => sex;

		int health = 10;
		public int Health { get => health; private set => health = value; }

		int attackStrength = 3;

		public Personage(Point pos, string name = "player", Sex sex) : base(pos, "Personage")
		{
			this.name = name;
			this.sex = sex;
		}

		public void Attack(ILiving living)
		{
			living.Health -= attackStrength;
		}
	}
}