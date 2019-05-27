/* Занятие 12
 * Задание 1
 * 
 * Из файла <disposable_task_file.txt> прочитать все содержимое.
 * Затем в этом же файле заменить каждое число квадратом этого числа.
 * 
 * Примечание: в файле просто содержатся числа от 1 до 100, каждое число на новой строке.
 */

using System;
using System.IO;

namespace Alyabiev.Task12.Task1
{
	class Program1
	{
		const string originalFilename = "../../../data/disposable_task_file.txt";
		const string newFilename = "disposable_task_file.txt";

		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 12 - 1] File modifing.\n");

			Prepare();
			ModifyData(newFilename);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		static void Prepare()
		{
			if (File.Exists(newFilename))
				File.Delete(newFilename);
			File.Copy(originalFilename, newFilename);
		}

		static void ModifyDataWithTemp(string filename)
		{
			string temp = Path.GetTempFileName();

			using (var sr = File.OpenText(filename))
			{
				using (var sw = File.CreateText(temp))
				{
					int num = 0;
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						if (int.TryParse(line, out num))
							sw.WriteLine(num * num);
						else
							sw.WriteLine($"error: {line}.");
					}
				}
			}
			File.Delete(filename);
			File.Move(temp, filename);
		}

		static void ModifyData(string filename)
		{
			var lines = File.ReadAllLines(filename);

			int num = 0;

			for (int i = 0; i < lines.Length; i++)
			{
				lines[i] = int.TryParse(lines[i], out num) ?
					$"{num * num}" :
					$"error: {lines[i]}.";
			}

			File.WriteAllLines(filename, lines);
		}
	}
}
