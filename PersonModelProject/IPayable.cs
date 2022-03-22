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
        /// <summary>
        /// Method for adding salary to an employees account
        /// </summary>
        /// <returns></returns>
        double ChangeMoney();

    }
}
