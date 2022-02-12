using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace PersonModelProject
{
    //TODO: XML | Выполненно
    //TODO: RSDN
    /// <summary>
    /// Class person
    /// </summary>
    public class Person
    {
        private string _name;
        private string _surname;
        private int _age;
        private gender _gender;
        /// <summary>
        /// Person's name
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                //TODO: Проверка на null | Выполненно
                //TODO: Проверка предметной области | Выполненно
                if (value != string.Empty)
                {
                    if (LanguageCheck(value) == true)
                    {
                        if (DoubleNameCheck(value) == true)
                        {
                            _name = DoubleNameHandler(value);
                        }
                        else
                        {
                            _name = FirstLetterToUpper(value);
                        }
                    }
                    else
                    {
                        throw new Exception($"Use only latin or cyrilic to write {value}");
                    }
                }
            }
        }
        /// <summary>
        /// Person's surname
        /// </summary>
        public string Surname
        {
            get => _surname;

            set
            {
                //TODO: Проверка на null | Выполненно
                //TODO: Проверка предметной области | Выполненно
                if (value != string.Empty)
                {
                    if (LanguageCheck(value) == true)
                    {
                        if (DoubleNameCheck(value) == true)
                        {
                            _surname = DoubleNameHandler(value);
                        }
                        else
                        {
                            _surname = FirstLetterToUpper(value);
                        }
                    }
                    else
                    {
                        throw new Exception($"Use only latin or cyrilic to write {value}");
                    }
                }
            }
        }
        /// <summary>
        /// Person's age
        /// </summary>
        public int Age
        {
            get => _age;

            set
            {
                //TODO: to const | Выполненно
                int _minAge = 0;
                int _maxAge = 150;
                if (value < _minAge && value > _maxAge)
                {
                    throw new Exception("Age must be in range from 0 to 150");
                }
                else
                {
                    _age = value;
                }
            }
        }
        /// <summary>
        /// Person's gender
        /// </summary>
        public gender Gender
        {
            get => _gender;

            set
            {
                _gender = value;
            }
        }
        /// <summary>
        /// Constructor of Person object
        /// </summary>
        /// <param name="name">Person's name</param>
        /// <param name="surname">Person's surname</param>
        /// <param name="age">Person's age</param>
        /// <param name="userGender">Person's gender</param>
        public Person(string name, string surname, int age, gender userGender)
        {
            //TODO: вызывать свойства | Выполненно
            Name = name;
            Surname = surname;
            Age = age;
            Gender = userGender;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Person() : this("default", "default", 0, gender.Unknown)
        { }
        /// <summary>
        /// Generator of random Person from lists of names and surnames
        /// </summary>
        /// <param name="names">List with random names</param>
        /// <param name="surnames">List with random surnames</param>
        /// <returns></returns>
        public static Person GetRandomPerson(List<string> names, List<string> surnames)
        {
            Random rnd = new Random();
            Person person = new Person(names[rnd.Next(0, names.Count() - 1)],
                                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                                   rnd.Next(0, 100),
                                                   (gender)rnd.Next(0, 2));
            return person;
        }

        //TODO: naming / Выполненно
        public string ShowPerson
        {
            get
            {
                return $"{Name} {Surname} Age {Age} Gender {Gender}";
            }
        }

        //TODO: Отделить консольный ввод-вывод от логики класса
        /// <summary>
        /// Reads information about person from console and performs checks
        /// </summary>
        /// <returns></returns>
        /*
        public Person_class ReadConsole()
        {
            Console.WriteLine("Input data according to the following sample: Name Surname Age Gender");
            Console.WriteLine("Input \"Help\" for more details");
            Console.WriteLine();
            string input = Console.ReadLine();
            Person_class person = new Person_class();
            if (input == "Help" | input == "help")
            {
                Console.WriteLine("Name and surname format - Use only latin or cyrilyc characters." +
                    " If you want to input double name or surname use \"-\" between names");
                Console.WriteLine(" Age and Gender format - Use numbers Age [0-150], Gender [0-male, 1-female, 2-other, 3-unknown]");
            }
            if (input != string.Empty)
            {
                
                string[] semiInput = input.Split(" ");

                if (LanguageCheck(semiInput[0]) == true)
                {
                    if (DoubleNameCheck(semiInput[0]) == true)
                    {
                        person.Name = DoubleNameHandler(semiInput[0]);
                    }
                    else
                    {
                        person.Name = FirstLetterToUpper(semiInput[0]);
                    }
                }
                else
                {
                    Console.WriteLine($"Use only latin or cyrilic to write {semiInput[0]}");
                }

                if (LanguageCheck(semiInput[1]) == true)
                {
                    if (DoubleNameCheck(semiInput[1]) == true)
                    {
                        person.Surname = DoubleNameHandler(semiInput[1]);
                    }
                    else
                    {
                        person.Surname = FirstLetterToUpper(semiInput[1]);
                    }
                }
                else
                {
                    Console.WriteLine($"Use only latin or cyrilic to write {semiInput[1]}");
                }

                bool age_parsing = int.TryParse(semiInput[2], out int AgeConsole);
                if (age_parsing)
                {
                    person.Age = AgeConsole;
                }
                else
                {
                    Console.WriteLine($"Failed to parse into int - {semiInput[2]}");
                }

                if (GenderCheck(semiInput[3]) == true)
                {
                    bool gender_parsing = int.TryParse(semiInput[3], out int GenderConsole);
                    if (gender_parsing)
                    {
                        person.Gender = (gender)GenderConsole;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to parse into int - {semiInput[3]}");
                    }
                }
                else
                {
                    Console.WriteLine("Use numbers [0-3] to specify gender. Type \"Help\" for additional info");
                }

                return person;
            }
            else
            {
                Console.WriteLine("Empty input");
            }
            Console.WriteLine("Returning default person");
            return person;
        }
        */
        /// <summary>
        /// Language check to make sure the name is only in cyrilic or latin
        /// </summary>
        /// <param name="input">Name or surname</param>
        /// <returns></returns>
        private static bool LanguageCheck(string input)
        {
            Regex regRUS = new Regex(@"^(([А-Яа-я]+)(-)?([А-Яа-я]+)?$)");
            if (regRUS.IsMatch(input))
            {
                return regRUS.IsMatch(input);
            }
            Regex regENG = new Regex(@"^(([A-Za-z]+)(-)?([A-Za-z]+)?$)");
            if (regENG.IsMatch(input))
            {
                return regENG.IsMatch(input);
            }
            return false;
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
        /// Changes double names to match standard of first letter being in Upper case
        /// </summary>
        /// <param name="input">Name or surname</param>
        /// <returns></returns>
        private string DoubleNameHandler(string input)
        {
            string[] doubleName = input.Split("-");
            return FirstLetterToUpper(doubleName[0]) + "-" + FirstLetterToUpper(doubleName[1]);
        }
        /// <summary>
        /// Changes string to match standard of first letter being in Upper case and the rest in lower case
        /// </summary>
        /// <param name="input">Name or Surname</param>
        /// <returns></returns>
        private string FirstLetterToUpper(string input)
        {
            return input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1).ToLower();
        }
        /// <summary>
        /// Checks if gender input is correct
        /// </summary>
        /// <param name="input">Number of the chosen gender</param>
        /// <returns></returns>
        private static bool GenderCheck(string input)
        {
            if (input == "0" | input == "1" | input == "2" | input == "3")
            {
                return true;
            }
            return false;
        }
    }
}