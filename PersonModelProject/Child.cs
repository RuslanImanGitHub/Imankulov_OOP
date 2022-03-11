using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonModelProject
{
    /// <summary>
    /// Child class
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Child's first parent
        /// </summary>
        private string _firstParent;

        /// <summary>
        /// Child's second parent
        /// </summary>
        private string _secondParent;

        /// <summary>
        /// Facility where child goes everyday
        /// </summary>
        private string _facility;

        /// <summary>
        /// Minimum age for a person
        /// </summary>
        private const int _minAge = 1;

        /// <summary>
        /// Maximum age for a child
        /// </summary>
        private const int _maxAge = 18;

        /// <summary>
        /// Minimum age for a person
        /// </summary>
        protected override int MinAge => _minAge;

        /// <summary>
        /// Maximum age for a child
        /// </summary>
        protected override int MaxAge => _maxAge;

        /// <summary>
        /// Child's mother
        /// </summary>
        public string FirstParent
        {
            get => _firstParent;
            set => _firstParent = value;
        }

        /// <summary>
        /// Child's father
        /// </summary>
        public string SecondParent
        {
            get => _secondParent;
            set => _secondParent = value;
        }

        /// <summary>
        /// Facility where child goes everyday
        /// </summary>
        public string Facility
        {
            get => _facility;
            set => _facility = value;
        }
        
        /// <summary>
        /// Constructor for a child without parents
        /// </summary>
        /// <param name="facility">Child's facility</param>
        /// <param name="name">Child's name</param>
        /// <param name="surname">Child's surname</param>
        /// <param name="age">Child's age</param>
        /// <param name="userGender">Child's gender</param>
        public Child(string facility, string name, string surname, int age, Gender userGender) 
            : base(name, surname, age, userGender)
        {
            Facility = facility;
        }

        /// <summary>
        /// Constructor for a child with one parent
        /// </summary>
        /// <param name="firstParent">Child's first parent</param>
        /// <param name="facility">Child's facility</param>
        /// <param name="name">Child's name</param>
        /// <param name="surname">Child's surname</param>
        /// <param name="age">Child's age</param>
        /// <param name="userGender">Child's gender</param>
        public Child(string firstParent, string facility, string name, string surname, int age, Gender userGender) 
            : this(facility ,name, surname, age, userGender)
        {
            FirstParent = firstParent;
        }

        /// <summary>
        /// constructor for a child with both parents
        /// </summary>
        /// <param name="firstParent">Child's first parent</param>
        /// <param name="secondParent">Child's second parent</param>
        /// <param name="facility">Child's facility</param>
        /// <param name="name">Child's name</param>
        /// <param name="surname">Child's surname</param>
        /// <param name="age">Child's age</param>
        /// <param name="userGender">Child's gender</param>
        public Child(string firstParent, string secondParent, string facility, string name, string surname, int age, Gender userGender) 
            : this(facility, name, surname, age, userGender)
        {
            FirstParent = firstParent;
            SecondParent = secondParent;
        }

        /// <summary>
        /// Returns random child
        /// </summary>
        /// <param name="names"></param>
        /// <param name="surnames"></param>
        /// <param name="facilities"></param>
        /// <returns></returns>
        public static Child GetRandomPerson(List<string> names, 
            List<string> surnames, List<string> facilities) 
        {
            var rnd = new Random();
            string surname = surnames[rnd.Next(0, surnames.Count() - 1)];

            var person = new Child($"{names[rnd.Next(0, names.Count() - 1)]} {surname}",
                                   $"{names[rnd.Next(0, names.Count() - 1)]} {surname}",
                                   facilities[rnd.Next(0, facilities.Count() - 1)],

                                   names[rnd.Next(0, names.Count() - 1)],
                                   surname,
                                   //TODO: | Ok
                                   rnd.Next(_minAge, _maxAge),
                                   (Gender)rnd.Next(0, 2));
            return person;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string Info()
        {
            string addition = null;
            if (SecondParent == null && FirstParent == null)
            {
                addition = $"Orphan";
            }
            else if (SecondParent == null)
            {
                addition = $"First parent {FirstParent}";
            }
            else if (FirstParent == null)
            {
                addition = $"First parent {SecondParent}";
            }
            else
            {
                addition = $"First parent {FirstParent}, Second parent {SecondParent}";
            }
            
            return $"{base.InfoBase()}, School or daycare {Facility}, Parents: " + addition;
        }

        /// <summary>
        /// Unique method for Child class
        /// </summary>
        /// <returns></returns>
        public string Fortnight()
        {
            return $"{this.Name} sure likes to play Fortnight";
        }
    }
}
