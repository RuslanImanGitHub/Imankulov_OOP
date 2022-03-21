using System;
using System.Collections.Generic;
using System.Text;
using SalaryPaymentProject;

//TODO:| namespace synced
namespace Lab3
{
    //TODO: RSDN | Ok
    public class StartLab3
    {
        //TODO: RSDN | Ok
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
            
            List<IPayable> list1 = new List<IPayable>();


            List<IPayable>[] lists = 
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

            //TODO: нет полиморфизма | Ok
            Console.WriteLine("Adding 100 to all accounts accept Wage Employee account");
            for (int i = 0; i < list1.Count; i++)
            {
                list1[i].ChangeMoney();
            }
            Console.WriteLine("");
            Show(lists);
            Console.ReadKey();
        }

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
                    Console.WriteLine(((EmployeeBase)lists[i][j]).Info());
                    Console.WriteLine("");
                }
            }
        }
    }
}
