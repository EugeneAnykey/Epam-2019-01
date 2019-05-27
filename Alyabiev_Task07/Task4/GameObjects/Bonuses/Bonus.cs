namespace Alyabiev.Task07.Task4
{
	class Bonus : GameObject
	{
		readonly string name;
		public string Name => name;

		int bonusValue;
		public int BonusValue { get => bonusValue; private set => bonusValue = value; }

		public Bonus(Point pos, int bonusValue, string name = "some bonus") : base(pos, "Bonus")
		{
			this.name = name;
			this.bonusValue = bonusValue;
		}
	}
}