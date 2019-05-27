using System;

namespace Alyabiev.Task07.Task3
{
	public static class Outputter
	{
		public static void PrintSeries(ISeries series)
		{
			series.Reset();

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(series.GetCurrent());
				series.MoveNext();
			}
		}

		public static void PrintIndexables(IIndexable indexable)
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(indexable[i + 1]);
			}
		}
	}

	#region interfaces
	public interface ISeries
	{
		double GetCurrent();
		bool MoveNext();
		void Reset();
	}

	public interface IIndexable
	{
		double this[int index] { get; }
	}

	interface IIndexableSeries : ISeries, IIndexable
	{
	}
	#endregion

	public partial class ArithmeticalProgression : ISeries, IIndexable
	{
		double start, step;
		int currentIndex;

		public ArithmeticalProgression(double start, double step)
		{
			this.start = start;
			this.step = step;
			this.currentIndex = 1;
		}

		public double GetCurrent()
		{
			return start + step * currentIndex;
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

		public double this[int index]
		{
			get
			{
				return start + step * index;
			}
		}
	}

	public class List : ISeries
	{
		private double[] series;
		private int currentIndex;

		public List(double[] series)
		{
			this.series = series;
			currentIndex = 0;
		}

		public double GetCurrent()
		{
			return series[currentIndex];
		}

		public bool MoveNext()
		{
			currentIndex = currentIndex < series.Length - 1 ? currentIndex + 1 : 0;
			return true;
		}

		public void Reset()
		{
			currentIndex = 0;
		}

		public double this[int index]
		{
			get { return series[index]; }
		}
	}

	#region GeometricalProgression
	public class GeometricalProgression : ISeries, IIndexable
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

		public double this[int index]
		{
			get
			{
				return start * Math.Pow(commonRatio, index - 1);
			}
		}
	}
	#endregion
}
