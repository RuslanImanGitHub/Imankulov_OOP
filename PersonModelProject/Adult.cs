using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonModelProject
{
    /// <summary>
    /// Class adult
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Passport ID
        /// </summary>
        private string _passport;
        
        /// <summary>
        /// Marriage status of an adult (True - Married, False - Not married)
        /// </summary>
        private bool _marriageStatus;

        /// <summary>
        /// Marriage partner of an adult
        /// </summary>
        private string _marriagePartner;

        /// <summary>
        /// Workplace of an adult
        /// </summary>
        private string _workplace;

        /// <summary>
        /// 
        /// </summary>
        private const int _minAge = 18;

        /// <summary>
        /// 
        /// </summary>
        private const int _maxAge = 150;

        /// <summary>
        /// Minimum age for a person to be considered adult
        /// </summary>
        protected override int MinAge => _minAge;

        /// <summary>
        /// Maximum age of a person
        /// </summary>
        protected override int MaxAge => _maxAge;

        /// <summary>
        /// Passport ID
        /// </summary>
        public string Passport
        {
            get => _passport;

            set => _passport = value;
        }

        /// <summary>
        /// Marriage status of an adult (True - Married, False - Not married)
        /// </summary>
        public bool MarriageStatus
        {
            get => _marriageStatus;

            set => _marriageStatus = value;
        }

        /// <summary>
        /// Marriage partner of an adult
        /// </summary>
        public string MarriagePartner
        {
            get => _marriagePartner;

            set
            {
                if (_marriageStatus == true)
                {
                    _marriagePartner = value;
                }
                else
                {
                    throw new Exception("Can't assign partner. Marriage status is incorrect");
                }
            }
        }

        /// <summary>
        /// Workplace of an adult
        /// </summary>
        public string Workplace
        {
            get => _workplace;

            set => _workplace = value;
        }
        
        /// <summary>
        /// Adult constructor without marriage partner
        /// </summary>
        /// <param name="passport">Adult's passport ID</param>
        /// <param name="workplace">Adult's workplace</param>
        /// <param name="marriageStatus">Adult's marriage status</param>
        /// <param name="name">Adult's name</param>
        /// <param name="surname">Adult's surname</param>
        /// <param name="age">Adult's age</param>
        /// <param name="userGender">Adult's gender</param>
        public Adult(string passport, string workplace, bool marriageStatus,
            string name, string surname, int age, Gender userGender)
            : base(name, surname, age, userGender)
        {
            Passport = passport;
            Workplace = workplace;
            MarriageStatus = marriageStatus;
        }

        /// <summary>
        /// Adult constructor with marriage partner
        /// </summary>
        /// <param name="marriagePartner">Adult's marriage partner</param>
        /// <param name="passport">Adult's passport ID</param>
        /// <param name="workplace">Adult's workplace</param>
        /// <param name="marriageStatus">Adult's marriage status</param>
        /// <param name="name">Adult's name</param>
        /// <param name="surname">Adult's surname</param>
        /// <param name="age">Adult's age</param>
        /// <param name="userGender">Adult's gender</param>
        public Adult(string marriagePartner, string passport, string workplace, bool marriageStatus,
            string name, string surname, int age, Gender userGender)
            : this(passport, workplace, marriageStatus, name, surname, age, userGender)
        {
            MarriagePartner = marriagePartner;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string Info()
        {
            string addition = null;
            if (MarriageStatus == true)
            {
                addition = $"Marriage partner {MarriagePartner}";
            }

            return $"{base.Info1()}, Passport {Passport}, " +
                   $"Workplace {Workplace}, Marriage status {MarriageStatus} {addition}";
        }

        /// <summary>
        /// Returns random Adult
        /// </summary>
        /// <param name="names">List with names</param>
        /// <param name="surnames">List with surnames</param>
        /// <param name="workplaces">List with workplaces</param>
        /// <param name="isMarried">Flag to mark married adults</param>
        /// <returns></returns>
        public static Adult GetRandomAdult(List<string> names, List<string> surnames, List<string> workplaces, bool isMarried)
        {
            var rnd = new Random();

            var person = new Adult(rnd.Next(1000,9999).ToString(),
                                   workplaces[rnd.Next(0, workplaces.Count() - 1)],
                                   isMarried,

                                   names[rnd.Next(0, names.Count() - 1)],
                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                   rnd.Next(_minAge, _maxAge),
                                   (Gender)rnd.Next(0, 2));
            return person;
        }

        //TODO: XML
        public static List<Adult> GetAPair(List<string> names, List<string> surnames, List<string> workplaces)
        {
            var rnd = new Random();
            List<Adult> pair = new List<Adult>();
            pair.Add(GetRandomAdult(names, surnames, workplaces, true));

            var person = new Adult($"{pair[0].Name} {pair[0].Surname}",
                                   rnd.Next(1000, 9999).ToString(),
                                   workplaces[rnd.Next(0, workplaces.Count() - 1)],
                                   true,

                                   names[rnd.Next(0, names.Count() - 1)],
                                   pair[0].Surname,
                                   pair[0].Age + rnd.Next(0, 8),
                                   (Gender)rnd.Next(0, 2));
            pair[0].MarriagePartner = $"{person.Name} {person.Surname}";
            pair.Add(person);
            return pair;
        }

        /// <summary>
        /// Unique method for Adult class
        /// </summary>
        /// <returns></returns>
        public string GoToWork()
        {
            return $"{this.Name} went to work to {this.Workplace}";
        }
    }
}
