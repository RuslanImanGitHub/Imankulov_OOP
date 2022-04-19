using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryPaymentProject;

namespace SalaryPaymentGUI
{
    /// <summary>
    /// Event that is used to transfer employee from AddingEmployeeForm to TableForm
    /// </summary>
    public class EventArgsEmployeeAdded : EventArgs
    {

        //TODO: инкапсуляция - private set | Done
        /// <summary>
        /// Property to write (private) or get employee
        /// </summary>
        public EmployeeBase Employee { get; private set; }

        /// <summary>
        /// Event constructor
        /// </summary>
        /// <param name="setEmployee">Employee that is being added</param>
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
