/* Занятие 10
 * Задание 2
 * Написать программу, описывающую небольшой офис, в котором работают сотрудники – объекты 
 *  класса *Person*, обладающие полем имя (*Name*). Каждый из сотрудников содержит пару методов:
 *  
 *  1. приветствие сотрудника, пришедшего на работу (принимает в качестве аргументов объект сотрудника
 *   и время его прихода). В зависимости от времени суток, приветствие может быть различным:
 *   до 12 часов – «Доброе утро», с 12 до 17 – «Добрый день», начиная с 17 часов – «Добрый вечер».
 *  2. прощание с ним (принимает только объект сотрудника).
 *  
 *  Каждый раз при входе очередного сотрудника в офис, все пришедшие ранее его приветствуют.
 *  При уходе сотрудника домой с ним также прощаются все присутствующие.
 *  Вызов процедуры приветствия/прощания производить через групповые делегаты.
 *  Факт прихода и ухода сотрудника отслеживается через генерируемые им события.
 *  Событие прихода описывается делегатом, передающим в числе параметров наследника *EventArgs*, явно содержащего поле с временем прихода.
 *  Продемонстрировать работу офиса при последовательном приходе и уходе сотрудников.
 */

using System;



namespace Alyabiev.Task10.Task2
{
	public class OfficeSimulation
	{
		Office office = new Office();
		readonly Employee[] employees;

		public OfficeSimulation()
		{
			#region Generating employees
			employees = new Employee[] {
				new Employee() { Name = "John" },
				new Employee() { Name = "Mary" },
				new Employee() { Name = "Victor" },
				new Employee() { Name = "Kevin" },
				new Employee() { Name = "Zoye" },
				new Employee() { Name = "Markus" },
				new Employee() { Name = "Ashley" }
			};
			#endregion
		}

		public void Run()
		{
			Console.WriteLine("Office simulation: [start].");

			CurrentTime.Offset = 1;

			Enter(1, 4.4);
			Enter(0, 0.22);
			Enter(3, 0.78);

			Exit(0, 3.9);

			Enter(5, 0.12);
			Enter(6, 0.3);

			Exit(6, 1.3);
			
			SkipTime(3);

			Enter(2, 0.23);

			Exit(5, 2.7);

			Enter(4, 0.16);

			Exit(2, 3.99);

			SkipTime(2.75);

			Exit(3, 0.1);

			Exit(1, 0.3);
			Exit(4, 1.3);

			Console.WriteLine("Office simulation: [end].");
			Console.WriteLine();
		}

		void Enter(int index, double hoursPassed = 1, bool showTime = true)
		{
			SkipTime(hoursPassed, showTime);
			office.Enter(employees[index]);
		}

		void Exit(int index, double hoursPassed = 1, bool showTime = true)
		{
			SkipTime(hoursPassed, showTime);
			office.Exit(employees[index]);
		}

		void SkipTime(double hoursPassed = 1, bool showTime = true)
		{
			CurrentTime.AddHours(hoursPassed);
			Console.WriteLine();
			if (showTime)
				Console.WriteLine("\t" + CurrentTime.GetTimeInString());
		}
	}
}