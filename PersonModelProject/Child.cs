using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonModelProject
{
    public class Child : Person
    {
        private string _mother;
        private string _father;
        private string _facility;
        private const int MinAge = 1;
        private const int MaxAge = 18;

        public string Mother
        {
            get => _mother;
            set => _mother = value;
        }

        public string Father
        {
            get => _father;
            set => _father = value;
        }

        public string Facility
        {
            get => _facility;
            set => _facility = value;
        }

        //TODO: duplication
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

        public Child(string facility, string name, string surname, int age, Gender1 userGender) : base(name, surname, age, userGender)
        {
            Facility = facility;
        }

        public Child(string mother, string facility, string name, string surname, int age, Gender1 userGender) : this(facility ,name, surname, age, userGender)
        {
            Mother = mother;
        }

        /*public Child(string father, string facility, string name, string surname, int age, Gender userGender) : this(facility, name, surname, age, userGender)
        {
            Father = father;
        } */
        // Одинаковые параметры, спросить

        public Child(string mother, string father, string facility, string name, string surname, int age, Gender1 userGender) : this(facility, name, surname, age, userGender)
        {
            Mother = mother;
            Father = father;
        }

        public static Child GetRandomPerson(List<string> names, List<string> surnames, List<string> facilities) //Только полные родители
        {
            var rnd = new Random();
            string surname = surnames[rnd.Next(0, surnames.Count() - 1)];

            var person = new Child($"{names[rnd.Next(0, names.Count() - 1)]} {surname}",
                                   $"{names[rnd.Next(0, names.Count() - 1)]} {surname}",
                                   facilities[rnd.Next(0, facilities.Count() - 1)],

                                   names[rnd.Next(0, names.Count() - 1)],
                                   surname,
                                   rnd.Next(MinAge, MaxAge),
                                   (Gender1)rnd.Next(0, 2));
            return person;
        }
        
        public override string Info()
        {
            string addition = null;
            if (Father == null && Mother == null)
            {
                addition = $"Orphan";
            }
            else if (Father == null)
            {
                addition = $"Mother {Mother}";
            }
            else if (Mother == null)
            {
                addition = $"Father {Father}";
            }
            else
            {
                addition = $"Mother {Mother}, Father {Father}";
            }
            //TODO: duplication
            return $"{Name} {Surname}, Age {Age}, Gender {Gender}, School or daycare {Facility}, Parents: " + addition;
        }

    }
}
