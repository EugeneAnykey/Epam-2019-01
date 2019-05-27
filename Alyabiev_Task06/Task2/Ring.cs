/* Создать класс Ring (кольцо) на основе Round (см. задание 2 из предыдущей темы), 
 *  описываемое координатами центра, внешним и внутренним радиусами, а также свойствами, 
 *  позволяющими узнать площадь кольца и суммарную длину внешней и внутренней границ кольца. 
 * Обеспечить нахождение класса в заведомо корректном состоянии.
 */

using System;

namespace Alyabiev.Task06.Task2
{
	public class Ring
	{
		Round inner;
		public Round Inner
		{
			get => inner;
			set => inner = value ?? throw new ArgumentNullException();
		}

		Round outer;
		public Round Outer
		{
			get => outer;
			set => outer = value ?? throw new ArgumentNullException();
		}

		public Ring(int x, int y, int outerRadius, int innerRadius)
		{
			Outer = new Round(x, y, outerRadius);
			Inner = new Round(x, y, innerRadius);
		}

		public Ring(Round outer, Round inner)
		{
			if (outer.X != inner.X || outer.Y != inner.Y)
				throw new ArgumentException($"Координаты центров внутренней и внешней окружностей не совпадают [{outer.X}, {outer.Y}] != [{inner.X}, {inner.Y}]");

			Outer = outer;
			Inner = inner;
		}

		public override string ToString()
		{
			return string.Format($"Ring in position {outer.X}:{outer.Y} and radius {outer.Radius} - {inner.Radius}.\n Length {GetLength()}.\n Area {GetArea()}.\n");
		}

		public double GetLength()
		{
			return outer.GetLength() + inner.GetLength();
		}

		public double GetArea()
		{
			return outer.GetArea() - inner.GetArea();
		}
	}
}