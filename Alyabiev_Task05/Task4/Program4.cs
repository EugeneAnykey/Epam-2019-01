/*
 * Написать свой собственный класс MyString, описывающий строку как массив символов.
 * Перегрузить для этого класса типовые операторы: 
 * 	+	– добавляет строку в конец текущей
 *  -	– удаляет подстроку из текущей строки
 *  ==	– сравнивает два объекта MyString
 *  
 *	ToString
 */

using System;

namespace Alyabiev.Task05.Task4
{
	class Program4
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("[Task 05 - 4] MyString.\n");

			var initial = new MyString("A chared string.".ToCharArray());
			var append = new MyString(" This is Ridiculous.".ToCharArray());
			var exlude = new MyString(" This is".ToCharArray());

			var compare1 = new MyString("A chared string. Ridiculous.".ToCharArray());
			var compare2 = new MyString("A chared string. Marvelous.".ToCharArray());

			var a1 = initial + append;
			Console.WriteLine("Add: {0}", a1.ToString());

			var a2 = a1 - exlude;
			Console.WriteLine("Remove: {0}", a2.ToString());

			OutputCompareResult(a2, compare1);
			Console.WriteLine();

			OutputCompareResult(a2, compare2);
			Console.WriteLine();

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}

		static void OutputCompareResult(MyString a, MyString b)
		{
			Console.WriteLine("Comparing\n 1: {0}\n 2: {1}", a.ToString(), b.ToString());
			var compareResult = (a == b) ? "equals" : "not equals";
			Console.WriteLine("\t: {0}", compareResult);
		}
	}
}