/* Напишите заготовку для векторного графического редактора. Полная версия редактора
 *  должна позволять создавать и выводить на экран такие фигуры как: Линия, Окружность,
 *  Прямоугольник, Круг, Кольцо. Заготовка, для упрощения, должна представлять собой
 *  консольное приложение с функционалом:
 * 1. Создать фигуру выбранного типа по произвольным координатам.
 * 2. Фигуры должны создаваться в общей коллекции (массиве)
 * 3. Вывести фигуры на экран (для каждой фигуры вывести на консоль её тип и значения
 *  параметров реализовать в методе Draw) с использованием перегрузки метода Draw
 */

using System;

namespace Alyabiev.Task07.Task1
{
	public abstract class Figure
	{
		public double X { get; set; }

		public double Y { get; set; }

		public void SetPosition(double x, double y)
		{
			X = x;
			Y = Y;
		}

		public abstract void Draw();
	}



	class Line : Figure
	{
		protected double width;

		public Line(double width)
		{
			this.width = width;
		}

		public override void Draw()
		{
			Console.WriteLine("Линия: длинна {0}.", width);
		}
	}



	class Rectangle : Line
	{
		protected double height;

		public Rectangle(double width, double height) : base(width)
		{
			this.height = height;
		}

		public double GetArea()
		{
			return width * height;
		}

		public override void Draw()
		{
			Console.WriteLine("Прямоугольник: стороны {0} и {1}.", width, height);
		}
	}



	class Circle : Figure
	{
		protected double radius;

		public Circle(double r)
		{
			radius = r;
		}

		public override void Draw()
		{
			Console.WriteLine("Окружность: радиус {0}.", radius);
		}
	}



	class Round : Circle
	{
		public Round(double r) : base(r) { }

		public virtual double GetArea()
		{
			return Math.PI * radius * radius;
		}

		public override void Draw()
		{
			Console.WriteLine("Круг: радиус {0}.", radius);
		}
	}



	class Ring : Round
	{
		protected double innerR;

		public Ring(double r, double ir) : base(r)
		{
			innerR = ir;
		}

		public override double GetArea()
		{
			return base.GetArea() - Math.PI * innerR * innerR;
		}

		public override void Draw()
		{
			Console.WriteLine("Кольцо: внешний радиус {0}, внутренний {1}.", radius, innerR);
		}
	}
}