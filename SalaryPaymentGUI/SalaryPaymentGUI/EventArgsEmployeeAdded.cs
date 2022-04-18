using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryPaymentProject;

namespace SalaryPaymentGUI
{
    //TODO: XML

    public class EventArgsEmployeeAdded : EventArgs
    {

        //TODO: инкапсуляция - private set | Done
        public EmployeeBase Employee { get; private set; }


        public EventArgsEmployeeAdded(EmployeeBase setEmployee)
        {
            //TODO: null? | Done
            if (setEmployee != null)
            {
                this.Employee = setEmployee;
            }
        }
    }
}
