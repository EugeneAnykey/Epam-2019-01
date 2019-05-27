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
	class Program1
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 07 - 1] Polimorph.\n");

			Figure[] figures = new Figure[10];

			Random random = new Random();
			for (int i = 0; i < figures.Length; i++)
			{
				switch (random.Next(5))
				{
					case 0:
						figures[i] = new Rectangle(10, 10);
						break;
					case 1:
						figures[i] = new Round(10);
						break;
					case 2:
						figures[i] = new Ring(10, 5);
						break;
					case 3:
						figures[i] = new Line(7);
						break;
					case 4:
						figures[i] = new Circle(9);
						break;
				}
			}

			foreach (Figure figure in figures)
			{
				figure.Draw();
				Console.WriteLine();
			}

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}