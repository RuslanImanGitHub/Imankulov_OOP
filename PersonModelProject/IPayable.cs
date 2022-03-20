using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPaymentProject
{
    public interface IPayable
    {
        double Account { get; set; } 
        double ChangeMoney(double currentBalance, double change) => currentBalance + change;

    }
}
