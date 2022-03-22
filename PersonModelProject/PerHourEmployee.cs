using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentProject
{
    /// <summary>
    /// Class PerHourEmployee
    /// </summary>
    public class PerHourEmployee : EmployeeBase, IPayable
    {
        /// <summary>
        /// Employee's hourly payment
        /// </summary>
        private double _hourlyPayment;

        /// <summary>
        /// How many hours have employee worked
        /// </summary>
        private int _hoursWorked;

        /// <summary>
        /// Employee's hourly payment
        /// </summary>
        public double HourlyPayment
        {
            get => _hourlyPayment;

            set => _hourlyPayment = value;
        }

        /// <summary>
        /// How many hours have employee worked
        /// </summary>
        public int HoursWorked
        {
            get => _hoursWorked;

            set => _hoursWorked = value;
        }

        /// <summary>
        /// Method for adding salary to an employees account
        /// </summary>
        /// <returns></returns>
        public override double ChangeMoney() => Account += HourlyPayment * HoursWorked;

        /// <summary>
        /// Constructor of Employee object
        /// </summary>
        /// <param name="name">Employee's name</param>
        /// <param name="surname">Employee's surname</param>
        /// <param name="age">Employee's age</param>
        /// <param name="userGender">Employee's gender</param>
        /// <param name="startingMoney">Starting money in employee's account</param>
        /// <param name="hourlyPayment">Employee's hourly payment</param>
        /// <param name="hoursWorked">How many hours have employee worked</param>
        public PerHourEmployee(string name, string surname, int age, Gender userGender,
                               double startingMoney, double hourlyPayment, int hoursWorked)
            : base(name, surname, age, userGender, startingMoney)
        {
            HourlyPayment = hourlyPayment;
            HoursWorked = hoursWorked;
        }

        /// <summary>
        /// Method returns random employee
        /// </summary>
        /// <param name="names">List with employee names</param>
        /// <param name="surnames">List with employee surnames</param>
        /// <returns></returns>
        public static PerHourEmployee GetRandomPerHourEmployee(List<string> names, List<string> surnames)
        {
            var rnd = new Random();

            var person = new PerHourEmployee(
                                   names[rnd.Next(0, names.Count() - 1)],
                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                   rnd.Next(_minAge, _maxAge),
                                   (Gender)rnd.Next(0, 2),
                                   rnd.Next(100, 600),
                                   rnd.Next(25, 50),
                                   rnd.Next(1, 5));
            return person;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string Info()
        {
            return $"{InfoBase()}, HourlyPayment: {HourlyPayment}, HoursWorked: {HoursWorked}";
        }
    }
}
