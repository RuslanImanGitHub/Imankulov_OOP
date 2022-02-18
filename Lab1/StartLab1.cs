using System;
using PersonModelProject;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab1
{
    public class StartLab1
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
            string consoleName = "Default";
            string consoleSurname = "Default";
            var defaultPerson = new Person(consoleName, consoleSurname);
            var actionsTupleList = new List<(Action Action, string Message)>
            {
                (
                    () => { consoleName = Console.ReadLine(); },
                    "Enter name of person:"
                ),
                (
                    () => { consoleSurname = CheckNaming(Console.ReadLine(), consoleName); },
                    "Enter surname of person:"),
                (
                    () => { defaultPerson = new Person(consoleName, consoleSurname); },
                    "Writing name and surname to person"),
                (
                    () => { defaultPerson.Age = Convert.ToInt32(Console.ReadLine()); },
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
        
        /// <summary>
        /// Language check to make sure the name and surname is only in cyrilic or latin
        /// </summary>
        /// <param name="input">Name or surname</param>
        /// <returns></returns>
        private static string LanguageCheck(string input)
        {
            if (input == null)
            {
                return null;
            }

            var regexes = new List<(Regex, string)>
            {
                (new Regex(@"^(([А-Яа-я]+)(-)?([А-Яа-я]+)?$)"), "Rus"),
                (new Regex(@"^(([A-Za-z]+)(-)?([A-Za-z]+)?$)"), "Eng")
            };

            foreach (var regexValue in regexes.Where(regexValue => regexValue.Item1.IsMatch(input)))
            {
                return regexValue.Item2;
            }

            throw new Exception($"Use only latin or cyrilic to write {input}");
        }

        /// <summary>
        /// Checks if there is a "-" in the name
        /// </summary>
        /// <param name="input">Name or surname</param>
        /// <returns></returns>
        private static bool DoubleNameCheck(string input)
        {
            Regex regDouble = new Regex(@"-");
            return regDouble.IsMatch(input);
        }

        /// <summary>
        /// Changes double names first letter being in Upper case
        /// </summary>
        /// <param name="input">Name or surname</param>
        /// <returns></returns>
        private static string DoubleNameHandler(string input)
        {
            string[] doubleName = input.Split("-");
            return FirstLetterToUpper(doubleName[0]) + "-"
                + FirstLetterToUpper(doubleName[1]);
        }

        /// <summary>
        /// Changes string to first letter being in Upper case and the rest in lower case
        /// </summary>
        /// <param name="input">Name or Surname</param>
        /// <returns></returns>
        private static string FirstLetterToUpper(string input)
        {
            return input.Substring(0, 1).ToUpper() +
                input.Substring(1, input.Length - 1).ToLower();
        }

        /// <summary>
        /// Used to performe check on inputs for naming and to keep the same locale for names and surnames
        /// </summary>
        /// <param name="input">Value that is supposed to be inputed</param>
        /// <param name="nameOrSurname">Value of name or surname to keep the same locale</param>
        /// <exception cref="Exception"></exception>
        private static string CheckNaming(string input, string nameOrSurname)
        {
            if (input != string.Empty)
            {
                if (LanguageCheck(input) == LanguageCheck(nameOrSurname)
                    || LanguageCheck(nameOrSurname) == null)
                {
                    return DoubleNameCheck(input)
                            ? DoubleNameHandler(input)
                            : FirstLetterToUpper(input);
                }
                throw new Exception("Not in the same localization");
            }
            else
            {
                throw new Exception("Input string should not be empty");
            }
        }
    }
}
