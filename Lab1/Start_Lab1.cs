using System;
using PersonModelProject;
using System.Collections.Generic;

namespace Lab1
{
    class Start_Lab1
    {
        static void Main()
        {
            Start_Lab1 Lab1 = new Start_Lab1();
            List<string> names = new List<string>
            {"Amari", "Ash", "Avery", "Bay", "Blake",
             "Cameron", "Casey", "Charlie", "Drew", "Emerson",
             "Jesse", "Morgan", "Remy", "Sam", "Bobbie"};
            List<string> surnames = new List<string>
            {"Smith", "Johnson", "Williams", "Jones", "Brown",
             "Miller", "Wilson", "Moore", "Taylor", "Thomas",
             "Turner", "Mitchell", "Phillips", "Baker", "Adams"};
            PersonList_class List1 = new PersonList_class();
            PersonList_class List2 = new PersonList_class();

            Console.WriteLine("Creating 2 list of 3 people");
            for (int i = 0; i < 3; i++)
            {
                List1.Add(Person_class.GetRandomPerson(names, surnames));
                // Person_class person2 = Person_class.GetRandomPerson(names, surnames);
                List2.Add(Person_class.GetRandomPerson(names, surnames));
            }
            Lab1.Show(List1, List2);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Adding new person to list #1");
            List1.Add(Person_class.GetRandomPerson(names, surnames));
            Lab1.Show(List1, List2);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Puting 2nd person from List1 as the last element of List2");
            List2.Add(List1.GetPersonByIndex(1));
            Lab1.Show(List1, List2);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Deleting 2nd person from List1");
            List1.RemoveIndex(1);
            Lab1.Show(List1, List2);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Deleting List2");
            List2.Clear();
            Lab1.Show(List1, List2);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Adding person from console");
            Person_class consolePerson = new Person_class();
            List2.Add(consolePerson.ReadConsole());
            Lab1.Show(List1, List2);
            Console.ReadKey();
        }
        public void Show (PersonList_class List1, PersonList_class List2)
        {
            PersonList_class[] Lists = new PersonList_class[]
            {
                List1, List2
            };

            for (int i = 0; i < Lists.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"List{i + 1}");
                for (int j = 0; j < Lists[i].Length(); j++)
                {
                    Console.WriteLine(Lists[i].GetPersonByIndex(j).Show);
                }
            }
        }
    }
}
