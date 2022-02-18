using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace PersonModelProject
{
    /// <summary>
    /// Class person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Person's name
        /// </summary>
        private string _name;

        /// <summary>
        /// Person's surname
        /// </summary>
        private string _surname;

        /// <summary>
        /// Person's age
        /// </summary>
        private int _age;

        /// <summary>
        /// Person's gender
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Minimal age accepted by programm
        /// </summary>
        public const int minAge = 1;

        /// <summary>
        /// Maximal age accepted by programm
        /// </summary>
        public const int maxAge = 150;

        /// <summary>
        /// Person's name
        /// </summary>
        public string Name
        {
            get => _name;

            set => _name = CheckNaming(value, _surname);
        }

        /// <summary>
        /// Person's surname
        /// </summary>
        public string Surname
        {
            get => _surname;

            set => _surname = CheckNaming(value, _name);
        }

        /// <summary>
        /// Person's age
        /// </summary>
        public int Age
        {
            get => _age;

            set
            {
                if (value < minAge || value > maxAge)
                {
                    throw new Exception($"Age must be in range from {minAge} to {maxAge}");
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
        public Gender Gender
        {
            get => _gender;

            set => _gender = value;
        }

        /// <summary>
        /// Constructor of Person object
        /// </summary>
        /// <param name="name">Person's name</param>
        /// <param name="surname">Person's surname</param>
        /// <param name="age">Person's age</param>
        /// <param name="userGender">Person's gender</param>
        public Person(string name, string surname, int age, Gender userGender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = userGender;
        }
        /// <summary>
        /// Partial constructor of Person object
        /// </summary>
        /// <param name="name">Person's name</param>
        /// <param name="surname">Person's surname</param>
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Person() : this(null, null, 1, Gender.Unknown)
        { }

        /// <summary>
        /// Generator of random Person from lists of names and surnames
        /// </summary>
        /// <param name="names">List with random names</param>
        /// <param name="surnames">List with random surnames</param>
        /// <returns></returns>
        public static Person GetRandomPerson(List<string> names, List<string> surnames)
        {
            var rnd = new Random();
            var person = new Person(names[rnd.Next(0, names.Count() - 1)],
                                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                                   rnd.Next(minAge, maxAge),
                                                   (Gender)rnd.Next(0, 2));
            return person;
        }
        
        /// <summary>
        /// Shows info about the object
        /// </summary>
        public string Info => $"{Name} {Surname} Age {Age} Gender {Gender}";

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
        public static string CheckNaming(string input, string nameOrSurname)
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