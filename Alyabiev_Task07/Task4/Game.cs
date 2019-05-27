using System;

namespace Alyabiev.Task07.Task4
{
	public class Game
	{
		Field field;
		public Field Field { get => field; set => field = value; }

		Player player;
		Personage personage;


		public Game()
		{
			field = new Field(30, 30);
			
			player = new Player("John");
			player.Personage = GetPersonage("Machine!", Sex.male);

			Field.AddObjects(new[] { player.Personage });
			Field.AddObjects(GetObstacles());
			Field.AddObjects(GetBonuses());
			Field.AddObjects(GetMonsters());
		}

		#region Get
		Personage GetPersonage(string name, Sex sex)
		{
			return new Personage(new Point(), name, sex);
		}

		Monster[] GetMonsters()
		{
			return new[] {
				new Monster(new Point(7, 3), "Wolf 1"),
				new Monster(new Point(), "Wolf 2"),
				new Monster(new Point(), "Bear 1"),
				new Monster(new Point(), "Bear 2"),
				new Monster(new Point(), "Fox 1"),
			};
		}

		Bonus[] GetBonuses()
		{
			return new[] {
				new Bonus(new Point(), 1, "Cherry 1"),
				new Bonus(new Point(), 2, "Apple"),
				new Bonus(new Point(), 1, "Cherry 2"),
				new Bonus(new Point(), 2, "Orange"),
			};
		}

		Obstacle[] GetObstacles()
		{
			return new[] {
				new Obstacle(new Point(7, 3), "Rock"),
				new Obstacle(new Point(), "Heavy rock 1"),
				new Obstacle(new Point(), "Long tree 1"),
				new Obstacle(new Point(), "George Bush"),
				new Obstacle(new Point(), "Good Bush"),
				new Obstacle(new Point(), "Heavy rock 2"),
				new Obstacle(new Point(), "Long tree 2"),
				new Obstacle(new Point(), "Long tree 3"),
				new Obstacle(new Point(), "Wide tree"),
			};
		}
		#endregion
	}
}
