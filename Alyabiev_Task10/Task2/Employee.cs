using System;

namespace Alyabiev.Task10.Task2
{
	public class Employee : Person
	{
		//public event SayHello SayHello;
		//public event SayGoodbye SayGoodbye;

		//void OnSayHello()
		//{
		//	SayHello?.Invoke(this);
		//}

		//void OnSayGoodbye()
		//{
		//	SayGoodbye?.Invoke(this);
		//}

		public void SayHi(Employee colleague)
		{
			Console.WriteLine($"{GreetingsHelper.Hello(CurrentTime.DayTime)}, {colleague.Name}, said {Name}.");
		}

		public void SayBye(Employee colleague)
		{
			Console.WriteLine($"{GreetingsHelper.Goodbye(CurrentTime.DayTime)}, {colleague.Name}, said {Name}.");
		}
	}
}