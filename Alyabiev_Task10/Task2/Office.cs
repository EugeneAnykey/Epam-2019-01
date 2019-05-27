using System;
using System.Collections.Generic;

namespace Alyabiev.Task10.Task2
{
	public class Office
	{
		public event SayHello Greetings;
		public event SayGoodbye Farewells;

		public void Enter(Employee emp)
		{
			Console.WriteLine($"{emp.Name} enters the office at {CurrentTime.GetTimeInString()}.");
			Greetings?.Invoke(emp);

			Greetings += emp.SayHi;
			Farewells += emp.SayBye;
		}

		public void Exit(Employee emp)
		{
			Greetings -= emp.SayHi;
			Farewells -= emp.SayBye;

			Farewells?.Invoke(emp);
			Console.WriteLine($"{emp.Name} leaves the office.");
		}
	}
}