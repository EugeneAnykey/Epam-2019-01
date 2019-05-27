using System;
using Alyabiev.Task06.Task1;

namespace Alyabiev.Task11.Task2
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Task 11 - 2] Employee - IEquatable.\n");

            EmployeeEx[] emps = new[] {
                new EmployeeEx("John", "Smith", "", new DateTime(1976, 7, 21), new DateTime(2009, 2, 16), Occupations.Cleaner),
                new EmployeeEx("John", "Smith", "", new DateTime(1976, 7, 21), new DateTime(2009, 2, 16), Occupations.Cleaner),
                new EmployeeEx("Гарри", "Васькин", "", new DateTime(1989, 5, 16), new DateTime(2001, 5, 6), Occupations.Worker),
                new EmployeeEx("Вася", "Гарькин", "", new DateTime(1980, 4, 15), new DateTime(2001, 5, 6), Occupations.Chief),
                new EmployeeEx("Джордж", "Буш", "", new DateTime(1965, 3, 14), new DateTime(1996, 3, 1), Occupations.President),
                new EmployeeEx("Джордж", "Буш", "", new DateTime(1965, 3, 14), new DateTime(1996, 3, 1), Occupations.President),
                new EmployeeEx("Джордж", "Буш", "", new DateTime(1965, 3, 14), new DateTime(1996, 3, 1), Occupations.VicePresiddent),
                new EmployeeEx("Джордж", "Буш", "", new DateTime(1965, 3, 14), new DateTime(1980, 1, 1), Occupations.VicePresiddent),
            };

            for (int i = 0; i < emps.Length - 1; i++)
            {
                Console.WriteLine($"{emps[i].ShortName} == {emps[i + 1].ShortName} ? {emps[i].Equals(emps[i + 1])}");
            }

            Console.Write("[!] finished.");
            Console.ReadKey(true);
        }
    }
}
