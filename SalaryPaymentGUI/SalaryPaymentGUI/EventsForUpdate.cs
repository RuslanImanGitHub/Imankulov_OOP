using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryPaymentProject;

namespace SalaryPaymentGUI
{
    public class EventsForUpdate : EventArgs
    {
        private EmployeeBase employee;

        public EmployeeBase Employee
        {
            set => employee = value;
            get => employee;
        }

        public EventsForUpdate(EmployeeBase setEmployee)
        {
            this.employee = setEmployee;
        }
        public EmployeeBase GetEmployee()
        {
            return Employee;
        }
    }
}
