/* Занятие 9
 * Задание 1
 * 
 * В кругу стоят N человек, пронумерованных от 1 до N. При ведении счета по кругу вычеркивается 
 *  каждый второй человек, пока не останется один.
 * 
 * Составить программу, моделирующую данный процесс двумя способами: используя класс List и LinkedList. 
 * При использовании LinkedList запрещается обращаться к элементам напрямую по индексу.
 * 
 * Для List и LinkedList реализовать общий метод, удаляющий ненужные элементы (типа RemoveEachSecondItem(list)).
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Alyabiev.Task09.Task1
{
	class Program1
	{
		const int humansCount = 18;

		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 09 - 1] List, LinkedList.\n");

			Scene("List:", GetHumansList());

			Scene("Linked List:", GetHumansLinkedList());

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		static void Scene(string name, ICollection<Human> humans)
		{
			Console.WriteLine(name);
			GenerateHumans(humans, humansCount);
			OutputHumans("[Generated]", humans);
			Console.WriteLine();

			if (humans is List<Human>)
				HighlanderRemover.RemoveEachSecondItem(humans as List<Human>, OutputHumansDebug);

			if (humans is LinkedList<Human>)
				HighlanderRemover.RemoveEachSecondItem(humans as LinkedList<Human>, OutputHumansDebug);

			OutputHumansDebug("[After Highlander Remover]", humans);
			Console.WriteLine();

			// ICollection (not done):
			HighlanderRemover.RemoveEachSecondItem_bad(humans as ICollection<Human>, OutputHumansDebug);

			Human.ResetIds();
		}

		#region GenerateHumans, GetHumans.
		static void GenerateHumans(ICollection<Human> humans, int count = 10)
		{
			for (int i = 0; i < count; i++)
			{
				humans.Add(new Human());
			}
		}

		static LinkedList<Human> GetHumansLinkedList()
		{
			return new LinkedList<Human>();
		}

		static List<Human> GetHumansList()
		{
			return new List<Human>();
		}
		#endregion

		#region OutputHumans.
		static void OutputHumans(string message, ICollection<Human> list)
		{
			Console.WriteLine(message);
			foreach (var item in list)
			{
				Console.WriteLine(item.SayHello());
			}
			Console.WriteLine();
		}

		static void OutputHumansDebug(string message, ICollection<Human> list)
		{
			Console.WriteLine(message);

			var sb = new StringBuilder();

			foreach (var item in list)
			{
				sb.Append(item.ToString());
			}
			Console.WriteLine(sb.ToString());

			Console.WriteLine();
		}
		#endregion
	}
}