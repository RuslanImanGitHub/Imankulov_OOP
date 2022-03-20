using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonModelProject
{
    /// <summary>
    /// Class PerHourEmployee
    /// </summary>
    public class PerHourEmployee : EmployeeBase, SalaryPaymentProject.IPayable
    {
        public double ChangeMoney(double HourlyPayment, double HoursWorked) => Account += (HourlyPayment * HoursWorked);

        public PerHourEmployee(string name, string surname, int age, Gender userGender, double startingMoney)
            : base(name, surname, age, userGender, startingMoney)
        {

        }

        public static PerHourEmployee GetRandomPerHourEmployee(List<string> names, List<string> surnames)
        {
            var rnd = new Random();

            var person = new PerHourEmployee(
                                   names[rnd.Next(0, names.Count() - 1)],
                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                   rnd.Next(_minAge, _maxAge),
                                   (Gender)rnd.Next(0, 2),
                                   rnd.Next(100,600));
            return person;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string Info()
        {
            return $"{base.InfoBase()}, Employee type: {this.GetType()}";
        }
    }
}
