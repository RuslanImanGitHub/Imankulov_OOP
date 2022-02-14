using System;
using PersonModelProject;
using System.Collections.Generic;

namespace Lab1
{
    public class StartLab1
    {
        public static void Main()
        {
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
            
            PersonList list1 = new PersonList();
            PersonList list2 = new PersonList();

            PersonList[] lists = new PersonList[]
            {
                list1, list2
            };

            Console.WriteLine("Creating 2 list of 3 people");
            for (int i = 0; i < 3; i++)
            {
                list1.Add(Person.GetRandomPerson(names, surnames));
                // Person_class person2 = Person_class.GetRandomPerson(names, surnames);
                list2.Add(Person.GetRandomPerson(names, surnames));
            }

            Show(lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Adding new person to list #1");
            list1.Add(Person.GetRandomPerson(names, surnames));
            Show(lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Puting 2nd person from List1 as the last element of List2");
            list2.Add(list1.GetPersonByIndex(1));
            Show(lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Deleting 2nd person from List1");
            list1.RemoveIndex(1);
            Show(lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Deleting List2");
            list2.Clear();
            Show(lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Adding person from console");
            list2.Add(ReadPersonFromConsole());
            Show(lists);
            Console.ReadKey();
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
                    Console.WriteLine(lists[i].GetPersonByIndex(j).Info);
                }
            }
        }

        /// <summary>
        /// Input person from console
        /// </summary>
        /// <returns>Instance person</returns>
        static Person ReadPersonFromConsole()
        {
            var defaultPerson = new Person();
            var actionsTupleList = new List<(Action Action, string Message)>
            {
                (
                    () => { defaultPerson.Name = Console.ReadLine(); },
                    "Enter name of person:"
                ),
                (
                    () =>
                    {
                        defaultPerson.Surname = Console.ReadLine();
                    },
                    "Enter surname of person:"),
                (
                    () =>
                    {
                        defaultPerson.Age = Convert.ToInt32(Console.ReadLine());
                    },
                    "Enter age of person:"),
                (
                    () =>
                    {
                        int personGender = Convert.ToInt32(Console.ReadLine());
                        switch (personGender)
                        {
                            case 1:
                            {
                                defaultPerson.Gender = Gender.Male;
                                return;
                            }
                            case 2:
                            {
                                defaultPerson.Gender = Gender.Female;
                                return;
                            }
                            case 3:
                            {
                                defaultPerson.Gender = Gender.Other;
                                return;
                            }
                            case 4:
                            {
                                defaultPerson.Gender = Gender.Unknown;
                                return;
                            }
                            default:
                            {
                                Console.WriteLine("Error, you must enter 1, 2, 3 or anything else");
                                break;
                            }
                        }
                    },
                    "Enter gender of person. 1 - Male, 2 - Female, 3 - Other, other input - Unknown")
            };

            foreach (var actionTuple in actionsTupleList)
            {
                ActionHandler(actionTuple.Action, actionTuple.Message);
            }
            return defaultPerson;
        }

        /// <summary>
        /// Handles console input actions
        /// </summary>
        /// <param name="action">Function that will be performed</param>
        /// <param name="inputMessage">Message that will be displayed in console</param>
        private static void ActionHandler(Action action, string inputMessage)
        {
            while (true)
            {
                Console.WriteLine(inputMessage);
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again!");
                }
            }
        }
    }
}
