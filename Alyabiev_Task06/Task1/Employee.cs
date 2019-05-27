/* Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст).
 * Написать программу, демонстрирующую использование этого класса.
 */

using System;

namespace Alyabiev.Task06.Task1
{
	public class Employee : User
    {
        static int LatestFreeId = 1;

		#region field: Id,
		readonly int id;

        // стаж работы
        public int WorksYears { get { return YearsPassed(startWork); } }

        // начало работы
        DateTime startWork;
        public DateTime StartWork
        {
            get { return startWork; }
            set
            {
				if (YearsPassed(Birthdate, value) < 10)
                    throw new ArgumentException("Дата устройства на работу не может быть установлена ранее возраста в 10 лет.");

                startWork = value;
            }
        }

        // должность
        public Occupations Occupation { get; set; }
        #endregion

        public Employee(string name, string surname, string patrname, DateTime birthday, DateTime startWork, Occupations occupation = Occupations.Unknown) : base (name, surname, patrname, birthday)
		{
			Occupation = occupation;
            StartWork = startWork;
            id = LatestFreeId++;
		}

		public override string ToString()
		{
            return string.Format(
                $"{base.ToString()}\n Работает {Occupation} " +
                $"с {startWork.ToShortDateString()} - " +
				$"{WorksYears} {RusNumeralsFollowingWord.StringEndingForNumeric(WorksYears, YearsVariants)}."
                );
		}
	}
}