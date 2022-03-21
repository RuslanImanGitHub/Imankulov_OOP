using System;
using System.Collections.Generic;
using System.Text;
using SalaryPaymentProject;

//TODO:| namespace synced
namespace Lab3
{
    //TODO: RSDN
    public class StartLab3
    {
        //TODO: RSDN
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
            
            List<EmployeeBase> list1 = new List<EmployeeBase>();


            List<EmployeeBase>[] lists = 
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

            //TODO: нет полиморфизма | Check
            Console.WriteLine("Adding 100 to all accounts");
            for (int i = 0; i < list1.Count; i++)
                switch (list1[i])
                {
                    case PerHourEmployee Employee:
                        Employee.ChangeMoney(25, 4);
                        break;
                    case PerPcsEmployee Employee:
                        Employee.ChangeMoney(5, 20);
                        break;
                    case WageEmployee Employee:
                        Employee.ChangeMoney(100);
                        break;
                }
            Console.WriteLine("");
            Show(lists);
            Console.ReadKey();
        }

        /// <summary>
        /// Prints all entries in PresonList object
        /// </summary>
        /// <param name="lists">List of PersonList objects that need to be printed</param>
        static void Show (List<EmployeeBase>[] lists)
        {
            for (int i = 0; i < lists.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"List{i + 1}");
                for (int j = 0; j < lists[i].Count; j++)
                {
                    Console.WriteLine(lists[i][j].Info());
                    Console.WriteLine("");
                }
            }
        }
    }
}
