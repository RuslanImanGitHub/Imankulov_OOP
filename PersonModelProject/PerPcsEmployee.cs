using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryPaymentProject
{
    /// <summary>
    /// Class PerPcsEmployee
    /// </summary>
    public class PerPcsEmployee : EmployeeBase, IPayable
    {
        /// <summary>
        /// How much money employee gets per one pcs production
        /// </summary>
        private double _paymentPerOnePcs;

        /// <summary>
        /// How much pcs employee produced
        /// </summary>
        private double _pcsAmount;

        /// <summary>
        /// How much money employee gets per one pcs production
        /// </summary>
        public double PaymentPerOnePcs
        {
            get => _paymentPerOnePcs;

            set => _paymentPerOnePcs = value;
        }

        /// <summary>
        /// How much pcs employee produced
        /// </summary>
        public double PcsAmount
        {
            get => _pcsAmount;

            set => _pcsAmount = value;
        }

        /// <summary>
        /// Method for adding salary to an employees account
        /// </summary>
        /// <param name="PaymentPerOnePcs">Payment for a piece of equipment employee made</param>
        /// <param name="PcsAmount">Amount of equipment employee made</param>
        /// <returns></returns>
        public override double ChangeMoney() => Account += PaymentPerOnePcs * PcsAmount;

        /// <summary>
        /// Constructor of Employee object
        /// </summary>
        /// <param name="name">Employee's name</param>
        /// <param name="surname">Employee's surname</param>
        /// <param name="age">Employee's age</param>
        /// <param name="userGender">Employee's gender</param>
        /// <param name="startingMoney">Starting money in employee's account</param>
        /// <param name="paymentPerOnePcs">How much money employee gets per one pcs production</param>
        /// <param name="pcsAmount">How much pcs employee produced</param>
        public PerPcsEmployee(string name, string surname, int age, Gender userGender, 
                              double startingMoney, double paymentPerOnePcs, double pcsAmount)
            : base(name, surname, age, userGender, startingMoney)
        {
            PaymentPerOnePcs = paymentPerOnePcs;
            PcsAmount = pcsAmount;
        }

        public PerPcsEmployee(): this(null, null, 18, Gender.Unknown, 0, 0, 0)
        { }

        /// <summary>
        /// Method returns random employee
        /// </summary>
        /// <param name="names">List with employee names</param>
        /// <param name="surnames">List with employee surnames</param>
        /// <returns></returns>
        public static PerPcsEmployee GetRandomPerPcsEmployee(List<string> names, List<string> surnames)
        {
            var rnd = new Random();

            var person = new PerPcsEmployee(
                                   names[rnd.Next(0, names.Count() - 1)],
                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                   rnd.Next(_minAge, _maxAge),
                                   (Gender)rnd.Next(0, 2),
                                   rnd.Next(100, 600),
                                   rnd.Next(10, 50),
                                   rnd.Next(1, 10));
            return person;
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string Info()
        {
            return $"{InfoBase()}, PaymentPerOnePcs: {PaymentPerOnePcs}, PcsAmount: {PcsAmount}";
        }
    }
}
