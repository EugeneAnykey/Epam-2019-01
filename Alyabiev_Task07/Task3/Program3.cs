/* За основу для задания взять классы и интерфейсы из демонстрации, файл «07_Interfaces.cs».
 * Требуется:
 *  1. Создать интерфейс «IIndexable», позволяющий обращаться к элементу последовательности по индексу (см. индексаторы)
 *  2. Классы «ArithmeticalProgression» и «List» должны реализовывать интерфейс «IIndexable» одновременно с «ISeries».
 *  3. Создать метод, демонстрирующий работу с объектами «IIndexable»
 */

using System;

namespace Alyabiev.Task07.Task3
{
	class Program3
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 07 - 3] Interfaces - IIndexable class.\n");

			IIndexable geom = new GeometricalProgression(10, 0.5f);
			Console.WriteLine("As indexable:");
			Outputter.PrintIndexables(geom);
			
			Console.WriteLine();
			Console.WriteLine("As series:");
			Outputter.PrintSeries(geom as ISeries);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}