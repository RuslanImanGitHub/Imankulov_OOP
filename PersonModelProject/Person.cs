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
        /// Shows if Person's name was writen in cyrilic
        /// </summary>
        private string _cyrilic;

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
        /// Person's name
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                if (value != string.Empty)
                {
                    if (LanguageCheck(value))
                    {
                        _name = DoubleNameCheck(value)
                            ? DoubleNameHandler(value)
                            : FirstLetterToUpper(value);
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
                if (value != string.Empty)
                {
                    if (LanguageCheck(value) == true)
                    {
                        _surname = DoubleNameCheck(value)
                            ? DoubleNameHandler(value)
                            : FirstLetterToUpper(value);
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
                const int minAge = 0;
                const int maxAge = 150;
                if (value <= minAge || value > maxAge)
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
        public Person(string name, string surname, int age, Gender userGender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = userGender;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Person() : this("", "", 1, Gender.Unknown)
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
                                                   rnd.Next(1, 100),
                                                   (Gender)rnd.Next(0, 2));
            return person;
        }

        //TODO: naming | Выполненно
        //TODO: XML | Выполненно
        /// <summary>
        /// Shows info about the object
        /// </summary>
        public string Info
        {
            get
            {
                return $"{Name} {Surname} Age {Age} Gender {Gender}";
            }
        }

        /// <summary>
        /// Language check to make sure the name and surname is only in cyrilic or latin
        /// </summary>
        /// <param name="input">Name or surname</param>
        /// <returns></returns>
        private bool LanguageCheck(string input)
        {
            Regex regRUS = new Regex(@"^(([А-Яа-я]+)(-)?([А-Яа-я]+)?$)");
            if (regRUS.IsMatch(input) && (this._cyrilic == null || this._cyrilic == "Rus"))
            {
                this._cyrilic = "Rus";
                return regRUS.IsMatch(input);
            }

            Regex regENG = new Regex(@"^(([A-Za-z]+)(-)?([A-Za-z]+)?$)");
            if (regENG.IsMatch(input) && (this._cyrilic == null || this._cyrilic == "Eng"))
            {
                this._cyrilic = "Eng";
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
    }
}