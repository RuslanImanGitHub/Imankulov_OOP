using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentProject
{
    /// <summary>
    /// Child class
    /// </summary>
    public class WageEmployee : EmployeeBase, IPayable
    {
        /// <summary>
        /// Employee's wage
        /// </summary>
        private double _wage;

        /// <summary>
        /// Employee's wage
        /// </summary>
        public double Wage
        {
            get => _wage;

            set => _wage = value;
        }

        /// <summary>
        /// Method for adding salary to an employees account
        /// </summary>
        /// <param name="Wage">Employee's wage</param>
        /// <returns></returns>
        public override double ChangeMoney() => Account += Wage;

        /// <summary>
        /// Constructor of Employee object
        /// </summary>
        /// <param name="name">Employee's name</param>
        /// <param name="surname">Employee's surname</param>
        /// <param name="age">Employee's age</param>
        /// <param name="userGender">Employee's gender</param>
        /// <param name="startingMoney">Starting money in employee's account</param>
        /// <param name="wage">Employee's wage</param>
        public WageEmployee(string name, string surname, int age, Gender userGender, double startingMoney, double wage)
          : base(name, surname, age, userGender, startingMoney)
        {
            Wage = wage;
        }

        /// <summary>
        /// Method returns random employee
        /// </summary>
        /// <param name="names">List with employee names</param>
        /// <param name="surnames">List with employee surnames</param>
        /// <returns></returns>
        public static WageEmployee GetRandomWageEmployee(List<string> names, List<string> surnames)
        {
            var rnd = new Random();

            var person = new WageEmployee(
                                   names[rnd.Next(0, names.Count() - 1)],
                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                   rnd.Next(_minAge, _maxAge),
                                   (Gender)rnd.Next(0, 2),
                                   rnd.Next(100, 600),
                                   rnd.Next(100, 600));
            return person;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string Info()
        {
            return $"{InfoBase()}, Wage: {Wage}";
        }
    }
}
