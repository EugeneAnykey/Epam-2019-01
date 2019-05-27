/* Занятие 8
Задание 1
На базе обычного массива (коллекции .NET не использовать) реализовать свой собственный класс DynamicArray, представляющий собой массив с запасом. Элементами созданной коллекции могут быть только объекты, имеющие конструктор без параметров. Класс должен содержать:

Конструктор:

Конструктор без параметров (создается массив емкостью 8 элементов). 
Конструктор с 1 целочисленным параметром (создается массив заданной емкости). 
Конструктор, который в качестве параметра принимает массив. 
Методы:

Метод Add, добавляющий в конец массива один элемент. При нехватке места для добавления элемента емкость массива должна расширяться в 2 раза. 
Метод AddRange, добавляющий в конец массива содержимое переданного массива. Обратите внимание, метод должен корректно учитывать число элементов в коллекции с тем, чтобы при необходимости расширения массива делать это только один раз вне зависимости от числа элементов в добавляемой коллекции. 
Метод Remove, удаляющий из коллекции указанный элемент. Метод должен возвращать true, если удаление прошло успешно и false в противном случае. При удалении элементов реальная емкость массива не должна уменьшаться. 
Метод Insert, позволяющий добавить элемент в произвольную позицию массива (обратите внимание, может потребоваться расширить массив). При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException. 
Свойства и индексаторы:

Свойство Length – получение длины заполненной части массива. 
Свойство Capacity – получение реальной ёмкости массива. 
Индексатор, позволяющий работать с элементом с указанным номером. При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException. 
 */

#define TEST

using System;
using System.Collections;

namespace Alyabiev.Task08.Task1
{
	public class DynamicArray<T> where T : class
	{
		#region const
		const int minInitCount = 8;
		#endregion

		#region if def TEST
		#if TEST
		int CountUntillNullOrEnd(T[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == null)
					return i;
			}
			return arr.Length;
		}

		public DynamicArray(T[] testArray)
		{
			array = testArray;
			Capacity = testArray.Length;
			Length = CountUntillNullOrEnd(array);
		}
		#endif
		#endregion

		#region fields, properties
		T[] array;

		public int Length { get; private set; }
		public int Capacity { get; private set; }

		public T this[int index]
		{
			get
			{
				if (0 <= index && index < Length)
					return array[index];

				throw new ArgumentOutOfRangeException();
			}
			private set
			{
				if (0 <= index && index < Length)
					array[index] = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
		#endregion

		#region init
		public DynamicArray() : this(minInitCount) { }

		public DynamicArray(int capacity)
		{
			if (capacity <= 0)
				throw new ArgumentException("Couldn't be less than 1");
			array = new T[capacity];
			Capacity = array.Length;
			Length = 0;
		}

		public DynamicArray(DynamicArray<T> arr)
		{
			Capacity = arr.Length * 2;
			array = new T[Capacity];

			for (int i = 0; i < arr.Length; i++)
			{
				array[i] = arr.array[i];
			}
			Length = arr.Length;
		}
		#endregion

		#region private
		void Expand(int times = 2)
		{
			if (times < 2)
				throw new ArgumentException("Should be 2 or greater!");

			int newCap = Capacity * times;
			var newArr = new T[newCap];
			for (int i = 0; i < Length; i++)
			{
				newArr[i] = array[i];
			}

			array = newArr;
			Capacity = newCap;
		}

		void RemoveNulls()
		{
			int j = 0;
			for (int i = j; i < array.Length; i++)
			{
				if (array[i] == null)
					continue;

				array[j++] = array[i];
			}
			Length = j;
		}
		#endregion

		#region methods
		public void Add(T item)
		{
			if (Length == Capacity)
				Expand();
			array[Length++] = item;
		}

		public void AddRange(DynamicArray<T> addon)
		{
			if (addon.Length > Capacity - Length)
			{
				int times = 2 + addon.Length / Capacity;
				Expand(times);
			}

			for (int i = 0; i < addon.Length; i++)
			{
				array[Length + i] = addon[i];
			}

			Length += addon.Length;
		}

		public void Remove(int position)
		{
			this[position] = null;
			RemoveNulls();
		}

		public void Insert(T item, int position)
		{
			if (position == Length)
			{
				Add(item);
				return;
			}

			if (!(0 <= position && position <= Length))
			{
				throw new ArgumentOutOfRangeException();
			}

			if (Length == Capacity)
				Expand();

			for (int i = Length; i > position; i--)
			{
				array[i] = array[i - 1];
			}

			array[position] = item;
			Length++;
		}
		#endregion
	}
}