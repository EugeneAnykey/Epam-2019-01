/* Написать класс, описывающий треугольник со сторонами a, b, c, и методами, позволяющими осуществить
 *  расчёт его площади и периметра. Обеспечить нахождение объекта в заведомо корректном состоянии.
 * Написать программу, демонстрирующую использование данного треугольника. 
 */

using System;
using System.Diagnostics;

namespace Alyabiev.Task05.Task3
{
	[DebuggerDisplay("Trinagle in position {X}:{Y} and with sides: {A}, {B}, {C}.\n Perimeter: {GetPerimeter()}.\n Area: {GetArea()}.")]
	public class Triangle
	{
		#region helper
		void CheckForGreaterThan0(double value)
		{
			if (value < 0)
				throw new ArgumentException("не может быть меньше или равно 0.");
		}
		#endregion

		#region field
		// side:
		double a;
		public double A
		{
			get => a;
			private set
			{
				CheckForGreaterThan0(value);
				a = value;
			}
		}

		double b;
		public double B
		{
			get => b;
			private set
			{
				CheckForGreaterThan0(value);
				b = value;
			}
		}

		double c;
		public double C
		{
			get => c;
			private set
			{
				CheckForGreaterThan0(value);
				c = value;
			}
		}

		// position:
		public double X { get; set; }
		public double Y { get; set; }
		#endregion

		bool CheckSides()
		{
			return CheckSides(A, B, C);
		}

		static bool CheckSides(double a, double b, double c)
		{
			//if (a > 0 && b > 0 && c > 0)
			if (a >= 0 && b >= 0 && c >= 0)
			{
				if (a + b <= c || a + c <= b || b + c <= a)
					throw new ArgumentException("Сумма любых двух сторон не должна быть меньше третьей.");
				else
					return true;
			}
			else
				throw new ArgumentException("Arguments must be non negative.");
		}

		public Triangle() : this(2, 3, 4) { }

		public Triangle(double a, double b, double c, int x = 0, int y = 0)
		{
			X = x;
			Y = y;
			A = a;
			B = b;
			C = c;
			CheckSides();
		}

		public double GetPerimeter()
		{
			return A + B + C;
		}

		public double GetArea()
		{
			var p = GetPerimeter() / 2.0f;
			var val = p * (p - A) * (p - B) * (p - C);
			return Math.Sqrt(val);
		}
	}
}
