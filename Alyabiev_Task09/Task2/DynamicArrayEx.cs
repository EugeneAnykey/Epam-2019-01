/* Занятие 9
 * Задание 2
 * 
 * Выполняется на базе *DynamicArray* из темы *Generics*.
 * Перечисленные ниже пункты должны быть реализованы в дополнение к существующим.
 * 
 * 1. Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс *IEnumerable*,
 *  создает массив нужного размера и копирует в него все элементы из коллекции.
 * 2. Методы, реализующие интерфейс *IEnumerable*.
 */

using System;
using System.Collections;
using System.Collections.Generic;

using Alyabiev.Task08.Task1;

namespace Alyabiev.Task09.Task2
{
	public class DynamicArrayEx<T> : DynamicArray<T>, IEnumerable<T> where T : class
	{
		public DynamicArrayEx(IEnumerable<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException();

			int len = 0;
			foreach (var item in collection)
				len++;

			Array = new T[len];

			int i = 0;
			foreach (var item in collection)
				array[i++] = item;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < Length; i++)
			{
				yield return array[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}