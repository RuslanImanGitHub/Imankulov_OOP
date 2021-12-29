using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace PersonModelProject
{
    public class Person_class
    {
        private string _name;
        private string _surname;
        private int _age;
        private gender _gender;

        public string Name
        {
            get => _name;

            set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get => _surname;

            set
            {
                _surname = value;
            }
        }
        public int Age
        {
            get => _age;

            set
            {
                if (value < 0 && value > 150)
                {
                    throw new Exception("Возраст должен быть в диапазоне от 0 до 150");
                }
                _age = value;
            }
        }
        public gender Gender
        {
            get => _gender;

            set
            {
                _gender = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="userGender"></param>
        public Person_class(string name, string surname, int age, gender userGender)
        {
            _name = name;
            _surname = surname;
            _age = age;
            _gender = userGender;
        }
        public Person_class() : this("default", "default", 0, gender.Unknown)
        { }
        public static Person_class GetRandomPerson(List<string> names, List<string> surnames)
        {
            Random rnd = new Random();
            Person_class person = new Person_class(names[rnd.Next(0, names.Count() - 1)],
                                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                                   rnd.Next(0, 100),
                                                   (gender)rnd.Next(0, 2));
            return person;
        }
        public string Show
        {
            get
            {
                return $"{Name} {Surname} Age {Age} Gender {Gender}";
            }
        }
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
        private static bool DoubleNameCheck(string input)
        {
            Regex regDouble = new Regex(@"-");
            return regDouble.IsMatch(input);
        }
        private string DoubleNameHandler(string input)
        {
            string[] doubleName = input.Split("-");
            return FirstLetterToUpper(doubleName[0]) + "-" + FirstLetterToUpper(doubleName[1]);
        }
        private string FirstLetterToUpper(string input)
        {
            return input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length - 1).ToLower();
        }
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