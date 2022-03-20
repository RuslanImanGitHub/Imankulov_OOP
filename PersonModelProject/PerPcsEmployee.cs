using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonModelProject
{
    /// <summary>
    /// Class PerPcsEmployee
    /// </summary>
    public class PerPcsEmployee : EmployeeBase, SalaryPaymentProject.IPayable
    {
        public double ChangeMoney(double PaymentPerOnePcs, double PcsAmount) => Account += (PaymentPerOnePcs * PcsAmount);

        public PerPcsEmployee(string name, string surname, int age, Gender userGender, double startingMoney)
            : base(name, surname, age, userGender, startingMoney)
        {

        }

        public static PerPcsEmployee GetRandomPerPcsEmployee(List<string> names, List<string> surnames)
        {
            var rnd = new Random();

            var person = new PerPcsEmployee(
                                   names[rnd.Next(0, names.Count() - 1)],
                                   surnames[rnd.Next(0, surnames.Count() - 1)],
                                   rnd.Next(_minAge, _maxAge),
                                   (Gender)rnd.Next(0, 2),
                                   rnd.Next(100, 600));
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
