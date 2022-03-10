using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace PersonModelProject
{
    //TODO: RSDN | Ok
    /// <summary>
    /// Class person
    /// </summary>
    abstract public class PersonBase
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
        /// Locale of Person's name
        /// </summary>
        private string _locale;

        /// <summary>
        /// Person's age
        /// </summary>
        protected int _age;

        /// <summary>
        /// Person's gender
        /// </summary>
        private Gender _gender;
        
        /// <summary>
        /// Minimal age accepted by programm
        /// </summary>
        private const int MinAge = 1;

        /// <summary>
        /// Maximal age accepted by programm
        /// </summary>
        private const int MaxAge = 150;

        /// <summary>
        /// Person's name
        /// </summary>
        public string Name
        {
            get => _name;

            set => _name = CheckNaming(value);
        }

        /// <summary>
        /// Person's surname
        /// </summary>
        public string Surname
        {
            get => _surname;

            set => _surname = CheckNaming(value);
        }

        //TODO: duplication | Unresolvable
        /// <summary>
        /// Person's age
        /// </summary>
        public virtual int Age
        {
            get => _age;

            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new Exception($"Age must be in range from {MinAge} to {MaxAge}");
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
        protected PersonBase(string name, string surname, int age, Gender userGender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = userGender;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected PersonBase() : this(null, null, 1, Gender.Unknown)
        { }

        /// <summary>
        /// Shows info about the object
        /// </summary>
        public abstract string Info();

        /// <summary>
        /// Shows info about the object
        /// </summary>
        protected string Info1()
        {
            return $"{Name} {Surname} Age {Age} Gender {Gender}";
        }

        /// <summary>
        /// Language check to make sure the name and surname is only in cyrilic or latin
        /// </summary>
        /// <param name="input">Name or surname</param>
        /// <returns></returns>
        private void LanguageCheck(string input)
        {
            if (input == null)
            {
                return;
            }

            var regexes = new List<(Regex, string)>
            {
                (new Regex(@"^(([А-Яа-я]+)(-)?([А-Яа-я]+)?$)"), "Rus"),
                (new Regex(@"^(([A-Za-z]+)(-)?([A-Za-z]+)?$)"), "Eng")
            };

            foreach (var regexValue in regexes.Where(regexValue => regexValue.Item1.IsMatch(input)))
            {
                if (_locale == null)
                {
                    _locale = regexValue.Item2;
                }
                else
                {
                    if (_locale != regexValue.Item2)
                    {
                        throw new Exception("Not in the same localization");
                    }
                }
                return;
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
        /// <exception cref="Exception"></exception>
        private string CheckNaming(string input)
        {
            if (input != string.Empty)
            {
                LanguageCheck(input);
                if (input != null)
                {
                    return DoubleNameCheck(input)
                            ? DoubleNameHandler(input)
                            : FirstLetterToUpper(input);
                }
                return input;
            }
            else
            {
                throw new ArgumentException("Input string should not be empty");
            }
        }
    }
}