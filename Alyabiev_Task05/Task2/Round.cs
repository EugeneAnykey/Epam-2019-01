/*
 * Написать класс Round, задающий круг с указанными координатами центра, радиусом,
 *  а также свойствами, позволяющими узнать длину описанной окружности и площадь круга.
 * Обеспечить нахождение объекта в заведомо корректном состоянии. 
 * Написать программу, демонстрирующую использование данного круга.
 */

using System;
using System.Diagnostics;

namespace Alyabiev.Task05.Task2
{
    [DebuggerDisplay("Round in position {X}:{Y} and radius {radius}.\n Length {GetLength()}.\n Area {GetArea()}.\n")]
    public class Round
    {
        double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value >= 0)
                    radius = value;
                else
                    throw new ArgumentException("Радиус не может быть отрицательным.");
            }
        }

        // position:
        public double X { get; set; }
        public double Y { get; set; }

        public Round()
        {
            X = Y = 0;
            radius = 1;
        }

        public Round(int x, int y, double r)
        {
            X = x;
            Y = y;
            Radius = r;
        }

        public double GetLength()
        {
            return 2 * Math.PI * radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }

}
