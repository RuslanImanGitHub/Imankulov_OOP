using System;
using PersonModelProject;
using System.Collections.Generic;

namespace Lab1
{
    //TODO: RSDN
    public class Start_Lab1
    {
        public static void Main()
        {
            //TODO: переделать в статик | Выполненно

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
            PersonList List1 = new PersonList();
            PersonList List2 = new PersonList();

            PersonList[] Lists = new PersonList[]
            {
                List1, List2
            };

            Console.WriteLine("Creating 2 list of 3 people");
            for (int i = 0; i < 3; i++)
            {
                List1.Add(Person.GetRandomPerson(names, surnames));
                // Person_class person2 = Person_class.GetRandomPerson(names, surnames);
                List2.Add(Person.GetRandomPerson(names, surnames));
            }

            Show(Lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Adding new person to list #1");
            List1.Add(Person.GetRandomPerson(names, surnames));
            Show(Lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Puting 2nd person from List1 as the last element of List2");
            List2.Add(List1.GetPersonByIndex(1));
            Show(Lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Deleting 2nd person from List1");
            List1.RemoveIndex(1);
            Show(Lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Deleting List2");
            List2.Clear();
            Show(Lists);
            Console.ReadKey();
            Console.WriteLine("");

            Console.WriteLine("Adding person from console");
            List2.Add(ReadPersonFromConsole());
            Show(Lists);
            Console.ReadKey();
        }

        //TODO: XML | Выполненно
        //TODO: RSDN
        /// <summary>
        /// Prints all entries in PresonList object
        /// </summary>
        /// <param name="Lists">List of PersonList objects that need to be printed</param>
        static void Show (PersonList[] Lists)
        {
            for (int i = 0; i < Lists.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"List{i + 1}");
                for (int j = 0; j < Lists[i].Length; j++)
                {
                    Console.WriteLine(Lists[i].GetPersonByIndex(j).ShowPerson);
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
                                defaultPerson.Gender = gender.Male;
                                return;
                            }
                            case 2:
                            {
                                defaultPerson.Gender = gender.Female;
                                return;
                            }
                            case 3:
                            {
                                defaultPerson.Gender = gender.Other;
                                return;
                            }
                            case 4:
                            {
                                defaultPerson.Gender = gender.Unknown;
                                return;
                            }
                            default:
                            {
                                Console.WriteLine("Error, you must enter 1, 2, 3 or 4");
                                break;
                            }
                        }
                    },
                    "Enter gender of person. 1 - Male, 2 - Female, 3 - Other, 4 - Unknown")
            };

            foreach (var actionTuple in actionsTupleList)
            {
                ActionHandler(actionTuple.Action, actionTuple.Message);
            }
            return defaultPerson;
        }

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
