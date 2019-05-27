using System;

namespace Alyabiev.Task09.Task1
{
	public enum Sex { Male, Female }

	public class Human
	{
		#region static: id.
		static int id = 1;
		public static void ResetIds()
		{
			id = 1;
		}
		#endregion

		int index;// = id++;
		string name;
		public string Name => name;

		public Sex Sex { get; private set; }

		public Human()
		{
			index = id++;
			name = HumanGeneratorHelper.GetRandomName(
				Sex = HumanGeneratorHelper.GetRandomSex()
			);
		}

		public string SayHello()
		{
			var child = Sex == Sex.Female ? "girl" : "boy";

			return string.Format($"{index,2}. I'm {name}, a {child}.");
		}

		public override string ToString()
		{
			return string.Format($"{index,2}. {name}.");
		}
	}
}