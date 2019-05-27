/* За основу для задания взять классы и интерфейсы из демонстрации, файл «07_Interfaces.cs».
 * Требуется реализовать интерфейс «ISeries» таким образом, чтобы получить геометрическую
 *  прогрессию. Продемонстрировать его работу с помощью метода PrintSeries.
 */

using System;

namespace Alyabiev.Task07.Task2
{
	class Program2
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 07 - 2] Interfaces - ISeries.\n");

			ISeries progression = new GeometricalProgression(10, 0.5f);
			Console.WriteLine("Geometrical progression:");
			PrintSeries(progression);

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		#region from 07_Interfaces.cs
		public static void PrintSeries(ISeries series)
		{
			series.Reset();

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(series.GetCurrent());
				series.MoveNext();
			}
		}

		public interface ISeries
		{
			double GetCurrent();
			bool MoveNext();
			void Reset();
		}
		#endregion

		public class GeometricalProgression : ISeries
		{
			double start;
			double commonRatio;
			int currentIndex;

			public GeometricalProgression(double start, double commonRatio)
			{
				this.start = start;
				this.commonRatio = commonRatio;
				this.currentIndex = 1;
			}

			public double GetCurrent()
			{
				return start * Math.Pow(commonRatio, currentIndex - 1);
			}

			public bool MoveNext()
			{
				currentIndex++;
				return true;
			}

			public void Reset()
			{
				currentIndex = 1;
			}
		}
	}
}