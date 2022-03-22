using System;
using System.Collections.Generic;
using System.Text;
using SalaryPaymentProject;

namespace Lab3
{
    public class StartLab3
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var names = new List<string>
            {
                "Amari", "Ash", "Avery", "Bay", "Blake",
                "Cameron", "Casey", "Charlie", "Drew", "Emerson",
                "Jesse", "Morgan", "Remy", "Sam", "Bobbie"
            };
            var surnames = new List<string>
            {
                "Smith", "Johnson", "Williams", "Jones", "Brown",
                "Miller", "Wilson", "Moore", "Taylor", "Thomas",
                "Turner", "Mitchell", "Phillips", "Baker", "Adams"
            };
            
            var list1 = new List<IPayable>
            {
                PerHourEmployee.GetRandomPerHourEmployee(names, surnames),
                PerPcsEmployee.GetRandomPerPcsEmployee(names, surnames),
                WageEmployee.GetRandomWageEmployee(names, surnames)
            };

            List<IPayable>[] lists = 
            {
                list1
            };

            Console.WriteLine("Creating a list of 3 types of employees");
            
            Show(lists);
            Console.ReadKey();
            Console.WriteLine("");
            
            Console.WriteLine("Adding 100 to all accounts accept Wage Employee account");
            
            foreach (var payable in list1)
            {
                payable.ChangeMoney();
            }
            Console.WriteLine("");
            Show(lists);
            Console.ReadKey();
        }

        //TODO: RSDN
        /// <summary>
        /// Prints all entries in PresonList object
        /// </summary>
        /// <param name="lists">List of PersonList objects that need to be printed</param>
        static void Show (List<IPayable>[] lists)
        {
            for (int i = 0; i < lists.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"List{i + 1}");
                for (int j = 0; j < lists[i].Count; j++)
                {
                    //TODO: BUG
                    Console.WriteLine(((EmployeeBase)lists[i][j]).Info());
                    Console.WriteLine("");
                }
            }
        }
    }
}
