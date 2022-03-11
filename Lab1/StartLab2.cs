using System;
using PersonModelProject;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class StartLab2
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
            List<string> workplaces = new List<string>
            {
                "Power industry", "Gas station", "Post office",
                "Power plant", "Data center", "Car manufacturing",
                "Design office", "Window manufacturing", "Network company"
            };
            List<string> facilities = new List<string>
            {
                "Church school", "Childcare center", "Middle school",
                "High school", "Low school", "Physics Math school",
                "social studies school", "STEM school #2"
            };
            
            PersonList list1 = new PersonList();

            PersonList[] lists = 
            {
                list1
            };

            Console.WriteLine("Creating a list of 7 people");
            var rnd = new Random();
            int adultsNumber = rnd.Next(1, 3);
            for (int i = 0; i < adultsNumber; i++)
            {
                var pairList = Adult.GetAPair(names, surnames, workplaces);
                for (int j = 0; j < pairList.Count; j++)
                {
                    list1.Add(pairList[j]);
                }
            }
            for (int i = 0; i < 7 - adultsNumber; i++)
            {
                list1.Add(Child.GetRandomPerson(names, surnames,facilities));
            }
            Show(lists);
            Console.ReadKey();
            Console.WriteLine("");

            var fourthPerson = list1.GetPersonByIndex(4);
            Console.WriteLine("4th person in the list is of the following object type:");
            Console.WriteLine($"{fourthPerson.GetType()}");
            Console.WriteLine($"{fourthPerson.Info()}");

            switch (fourthPerson)
            {
                case Child fourthChild:
                    Console.WriteLine(fourthChild.Fortnight());
                    break;
                case Adult fourthAdult:
                    Console.WriteLine(fourthAdult.GoToWork());
                    break;
            }
        }
        
        /// <summary>
        /// Prints all entries in PresonList object
        /// </summary>
        /// <param name="lists">List of PersonList objects that need to be printed</param>
        static void Show (PersonList[] lists)
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
