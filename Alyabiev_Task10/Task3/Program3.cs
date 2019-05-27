/* Занятие 10
 * Задание 3
 * 
 * Написать модуль сортировки, включающий в себя:
 * 
 * Метод сортировки из задания 1;
 * Метод, позволяющий запустить в сортировку в отдельном потоке выполнения;
 * Событие, сигнализирующее о завершении сортировки.
 * 
 * Продемонстрировать работу модуля в многопоточном режиме.
 * http://www.albahari.com/threading/
 */

using System;
using System.Threading;

namespace Alyabiev.Task10.Task3
{
	class Program1
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 10 - 3] Sort, thread.\n");

			var lines = new string[][] {
				WordsGetter.GetWords(0),
				WordsGetter.GetWords(1),
				WordsGetter.GetWords(2)
			};

			var threads = new[] {
				GetThread(0, lines),
				GetThread(1, lines),
				GetThread(2, lines)
			};

			foreach (var item in threads)
			{
				item.Start();
			}

			Thread.Sleep(3000);
			Console.WriteLine("[!] finished.");
			Console.ReadKey(true);
		}

		static Thread GetThread(int id, string[][] lines)
		{
			return new Thread(() =>
			{
				Outputter.WriteToConsole($"<Before sort [{id}]:>\n", lines[id]);

				SorterTread.Sort(
					lines[id],
					Comparator.MyCompare,
					() => Console.WriteLine($"<Callback: Thread {id} finished>\n")
				);

				Outputter.WriteToConsole($"<After sort [{id}]:>\n", lines[id]);
			}
			);
		}
	}
}