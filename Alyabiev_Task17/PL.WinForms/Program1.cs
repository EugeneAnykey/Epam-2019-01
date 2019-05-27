/* Занятие 17. Технология ADO.NET
 * 
 * Задание
 * 
 * Для приложения **Пользователи и награды** использовать спроектированную в прошлом задании базу данных для хранения информации о пользователях и наградах.
 * 
 * Для приложения **Пользователи и награды** из предыдущего задания необходимо добавить ещё одну реализацию слоя доступа к данным, таким образом, чтобы данные о пользователях и наградах хранились в базе данных, выполненной в предыдущем задании.
 *
 * Требования:
 * Использовать присоединённую модель *ADO.NET*;
 * Строка подключения в БД должна считываться из файла конфигурации;
 * В файле конфигурации должна быть настройка, позволяющая выбирать используемые слои доступа к данным (БД или коллекции).
 */

using System;
using System.Configuration;
using System.Windows.Forms;

namespace Alyabiev.Task17.Awarder
{
	static class Program1
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			const string DatabaseKey = "database";
			var context = ConfigurationManager.AppSettings["context"];

			Application.Run(new PL.WinForms.MainForm(DatabaseKey == context));
		}
	}
}
