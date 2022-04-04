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
        //TODO:
        private EmployeeBase employee;

        public EmployeeBase Employee
        {
            set => employee = value;
            get => employee;
        }

        public EventArgsEmployeeAdded(EmployeeBase setEmployee)
        {
            this.employee = setEmployee;
        }

        //TODO:
        public EmployeeBase GetEmployee()
        {
            return Employee;
        }
    }
}
