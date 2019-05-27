/*
 * Напишите программу, которая заменяет все найденные в тексте HTML теги на знак “_”. Обязательно использовать регулярные выражения.
 * 
 * Пример:
 *   Введите HTML текст: <b>Это</b> текст <i>с</i> <font color=”red”>HTML</font> кодами 
 *   Результат замены: _Это_ текст _с_ _HTML_ кодами
 */

using System;
using System.Text.RegularExpressions;

namespace Alyabiev.Task04.Task5
{
	class Program5
	{
		static void Main(string[] args)
		{
			Console.WriteLine("[Task 04 - 5] Tags remover.\n");

			const string replacement = "_";
			const string pattern = @"(<.+?>)+";

			var tagedLine = "<body> <h1>It's a new day!</h1> <div class=\"article\"> <a href='lost-link.html'>a link must be here</a> <br /> <img src='no path' /> <p>some text</p> <p>another text</p> </div> </body>";

			Console.WriteLine($"Taged line: {tagedLine}\n");
			Console.WriteLine($"Tags replaced: {Regex.Replace(tagedLine, pattern, replacement)}\n");

			Console.Write("[!] finished.");
			Console.ReadKey(true);
		}
	}
}