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
        private EmployeeBase _employee;

        //TODO: инкапсуляция - private set
        public EmployeeBase Employee
        {
            set => _employee = value;
            get => _employee;
        }

        public EventArgsEmployeeAdded(EmployeeBase setEmployee)
        {
            //TODO: null?
            this._employee = setEmployee;
        }
    }
}
