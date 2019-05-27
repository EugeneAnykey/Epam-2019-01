using System;

namespace Alyabiev.Task06.Task1
{
    class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Task 06 - 1] Employee class.\n");

            Employee[] emps = new[] {
				new Employee("John", "Smith", "", new DateTime(1976, 7, 21), new DateTime(2009, 2, 16), Occupations.Cleaner),
				new Employee("Гарри", "Васькин", "", new DateTime(1989, 5, 16), new DateTime(2001, 5, 6), Occupations.Worker),
                new Employee("Вася", "Гарькин", "", new DateTime(1980, 4, 15), new DateTime(2001, 5, 6), Occupations.Chief),
                new Employee("Джордж", "Буш", "", new DateTime(1965, 3, 14), new DateTime(1996, 3, 1), Occupations.President),
            };

            foreach (var e in emps)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine();
            }

            Console.Write("[!] finished.");
            Console.ReadKey(true);
        }
    }
}
