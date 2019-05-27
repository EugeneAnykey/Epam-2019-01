/* Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст).
 * Написать программу, демонстрирующую использование этого класса.
 */

using System;
using Alyabiev.Task06.Task1;

namespace Alyabiev.Task11.Task2
{
	public class EmployeeEx : Employee, IEquatable<Employee>
    {
        public EmployeeEx(string name, string surname, string patrname, DateTime birthday, DateTime startWork, Occupations occupation = Occupations.Unknown) : 
            base (name, surname, patrname, birthday, startWork, occupation)
		{
        }

        public string ShortName => $"{Surname}, {Name}";

        public bool Equals(Employee other)
        {
            return
                Name == other.Name &
                Surname == other.Surname &
                Patrname == other.Patrname &
                Birthdate.Equals(other.Birthdate) &
                this.StartWork.Equals(other.StartWork) &
                Occupation.Equals(other.Occupation);
        }
    }
}