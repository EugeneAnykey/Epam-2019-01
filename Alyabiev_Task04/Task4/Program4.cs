/*
 * Проведите сравнительный анализ скорости работы классов String и StringBuilder для операции сложения.
 */

using System;
using System.Diagnostics;
using System.Text;

namespace Alyabiev.Task04.Task4
{
	class Program4
	{
		static void Main(string[] args)
		{
			Console.WriteLine("[Task 04 - 4] Time elapsed.\n");

			const int count = 20000;
			const int multiplier = 100;

			Console.WriteLine($"Lines to test: {count}.");

			Console.WriteLine($"<String> takes {ElapsedMilliseconds(Simple, count)} ms to complete <{count}> times.");

			Console.WriteLine($"<StringBuilder> takes {ElapsedMilliseconds(Builder, count * multiplier)} ms to complete <{count} * {multiplier}> times.");

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		#region delegate
		delegate void TestWork(int count);

		static long ElapsedMilliseconds(TestWork work, int count)
		{
			var w = new Stopwatch();
			w.Start();

			work(count);

			w.Stop();
			return w.ElapsedMilliseconds;
		}
		#endregion

		#region methods
		static void Simple(int count)
		{
			string str = "";

			for (int i = 0; i < count; i++)
			{
				str += "*";
			}
		}

		static void Builder(int count)
		{
			var sb = new StringBuilder();

			for (int i = 0; i < count; i++)
			{
				sb.Append("*");
			}
			var res = sb.ToString();
		}
		#endregion
	}
}