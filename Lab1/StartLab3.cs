using System;
using PersonModelProject;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class StartLab3
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<string> names = new List<string>
            {
                "Amari", "Ash", "Avery", "Bay", "Blake",
                "Cameron", "Casey", "Charlie", "Drew", "Emerson",
                "Jesse", "Morgan", "Remy", "Sam", "Bobbie"
            };
            List<string> surnames = new List<string>
            {
                "Smith", "Johnson", "Williams", "Jones", "Brown",
                "Miller", "Wilson", "Moore", "Taylor", "Thomas",
                "Turner", "Mitchell", "Phillips", "Baker", "Adams"
            };
            
            EmployeeList list1 = new EmployeeList();

            EmployeeList[] lists = 
            {
                list1
            };

            Console.WriteLine("Creating a list of 3 types of employees");
            list1.Add(PerHourEmployee.GetRandomPerHourEmployee(names, surnames));
            list1.Add(PerPcsEmployee.GetRandomPerPcsEmployee(names, surnames));
            list1.Add(WageEmployee.GetRandomWageEmployee(names, surnames));

            Show(lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Adding 100 to all accounts");
            ((PerHourEmployee)list1.GetPersonByIndex(0)).ChangeMoney(25, 4);
            ((PerPcsEmployee)list1.GetPersonByIndex(1)).ChangeMoney(5, 20);
            ((WageEmployee)list1.GetPersonByIndex(2)).ChangeMoney(100);
            Console.WriteLine("");
            Show(lists);
            Console.ReadKey();

        }

        /// <summary>
        /// Prints all entries in PresonList object
        /// </summary>
        /// <param name="lists">List of PersonList objects that need to be printed</param>
        static void Show (EmployeeList[] lists)
        {
            for (int i = 0; i < lists.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"List{i + 1}");
                for (int j = 0; j < lists[i].Length; j++)
                {
                    Console.WriteLine(lists[i].GetPersonByIndex(j).Info());
                    Console.WriteLine("");
                }
            }
        }
    }
}
