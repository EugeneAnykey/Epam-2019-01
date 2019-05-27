/* Занятие 9
 * Задание 1
 * 
 * В кругу стоят N человек, пронумерованных от 1 до N. При ведении счета по кругу вычеркивается 
 *  каждый второй человек, пока не останется один.
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Alyabiev.Task09.Task1
{
	public static class HighlanderRemover
	{
		#region helpers: IsEmpty, WriteNotImplemented.
		static bool IsEmpty(string name, object list)
		{
			if (list == null)
			{
				Console.WriteLine($"{name}: empty.");
			}

			return list == null;
		}

		static bool IsNotImplemented(string message = "")
		{
			Console.WriteLine(
				(string.IsNullOrEmpty(message) ? "" : message + ": ") +
				"not implemented yet"
			);
			return true;
		}
		#endregion

		#region list
		public static void RemoveEachSecondItem(List<Human> list, Action<string, List<Human>> callback)
		{
			if (IsEmpty("List<Human>", list))
				return;

			bool even = true;
			int iter = 1;
			int i = 0;

			while (list.Count > 1)
			{
				while (list.Count > i)
				{
					if (even = !even)
						list.Remove(list[i]);
					else
						i++;
				}

				if (i >= list.Count)
					i = 0;

				callback($"Iteration [{iter++}].", list);
			}
		}

		public static void RemoveEachSecondItem(LinkedList<Human> list, Action<string, LinkedList<Human>> callback)
		{
			if (IsEmpty("LinkedList<Human>", list))
				return;

			bool even = true;
			int iter = 1;

			var current = list.First;

			while (list.Count > 1)
			{
				//current = list.First;
				while (current != null)
				{
					even = !even;

					if (even)
					{
						var remove = current;
						current = current.Next;
						list.Remove(remove);
					}
					else
						current = current.Next;
				}

				if (current == null)
					current = list.First;

				callback($"Iteration [{iter++}].", list);
			}
		}
		#endregion

		#region ICollection
		// List<T>       : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable, IList<T>, IList, IReadOnlyList<T>, IReadOnlyCollection<T>, 
		// LinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable, ISerializable, IDeserializationCallback
		// both          : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable

		public static void RemoveEachSecondItem_bad(ICollection<Human> list, Action<string, ICollection<Human>> callback)
		{
			if (IsNotImplemented("ICollection"))
				return;

			if (IsEmpty("ICollection", list))
				return;

			bool even = true;

			while (list.Count > 1)
			{
				foreach (var item in list)
				{
					if (even)
						list.Remove(item);
					even = !even;
				}
			}

			var iter = 0;
			callback($"Iteration [{iter++}].", list);
		}
		#endregion
	}
}