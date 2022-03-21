using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentProject
{
    /// <summary>
    /// Interface for salary payment
    /// </summary>
    public interface IPayable
    {
        //TODO: Убрать реализацию | Ok
        /// <summary>
        /// Method for adding salary to an employees account
        /// </summary>
        /// <param name="currentBalance">Current balance of an employee</param>
        /// <param name="change">Payment for person</param>
        /// <returns></returns>
        double ChangeMoney();

    }
}
