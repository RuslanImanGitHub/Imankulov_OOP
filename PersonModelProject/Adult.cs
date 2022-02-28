﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonModelProject
{
    public class Adult : Person
    {
        private string _passport;
        private bool _marriagestatus;
        private string _marriagepartner;
        private string _workplace;
        private const int MinAge = 18;
        private const int MaxAge = 150;

        public string Passport
        {
            get => _passport;

            set => _passport = value;
        }

        public bool MarriageStatus
        {
            get => _marriagestatus;

            set => _marriagestatus = value;
        }

        public string MarriagePartner
        {
            get => _marriagepartner;

            set
            {
                if (_marriagestatus == true)
                {
                    _marriagepartner = value;
                }
                else
                {
                    throw new Exception("Can't assign partner. Marriage status is incorrect");
                }
            }
        }

        public string Workplace
        {
            get => _workplace;

            set => _workplace = value;
        }

        public override int Age
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

        public Adult(string passport, string workplace, bool marriageStatus, string name, string surname, int age, Gender userGender)
            : base(name, surname, age, userGender)
        {
            Passport = passport;
            Workplace = workplace;
            MarriageStatus = marriageStatus;
        }

        public Adult(string marriagePartner, string passport, string workplace, bool marriageStatus, string name, string surname, int age, Gender userGender)
            : this(passport, workplace, marriageStatus, name, surname, age, userGender)
        {
            MarriagePartner = marriagePartner;
        }

        public override string Info()
        {
            string addition = null;
            if (MarriageStatus == true)
            {
                addition = $"Marriage partner {MarriagePartner}";
            }
            return $"{Name} {Surname}, Age {Age}, Gender {Gender}, Passport {Passport},Workplace {Workplace}, Marriage status {MarriageStatus}" + addition;
        }

        public static Adult GetRandomPerson(List<string> names, List<string> surnames, List<string> workplaces) //No marriage partner mirroring yet
        {
            var rnd = new Random();
            string surname = surnames[rnd.Next(0, surnames.Count() - 1)];

            var person = new Adult($"{names[rnd.Next(0, names.Count() - 1)]} {surname}",
                                   rnd.Next(1000,9999).ToString(),
                                   workplaces[rnd.Next(0, workplaces.Count() - 1)],
                                   rnd.Next(2) == 1,

                                   names[rnd.Next(0, names.Count() - 1)],
                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                   rnd.Next(MinAge, MaxAge),
                                   (Gender)rnd.Next(0, 2));
            return person;
        }
    }
}
