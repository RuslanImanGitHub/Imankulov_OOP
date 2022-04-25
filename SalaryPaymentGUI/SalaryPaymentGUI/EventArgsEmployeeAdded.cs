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
        /// <summary>
        /// Property to write (private) or get employee
        /// </summary>
        public EmployeeBase Employee { get; }

        /// <summary>
        /// Event constructor
        /// </summary>
        /// <param name="setEmployee">Employee that is being added</param>
        public EventArgsEmployeeAdded(EmployeeBase setEmployee)
        {
            if (setEmployee != null)
            {
                this.Employee = setEmployee;
            }
            else
            {
                throw new Exception("You must select non-null employee");
            }

        }
    }
}
