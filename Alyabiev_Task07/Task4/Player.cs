namespace Alyabiev.Task07.Task4
{
	class Player
	{
		Personage personage;
		public Personage Personage { get; set; }

		readonly string name;
		public string Name => name;

		public Player(string name)
		{
			this.name = name;
		}
	}
}