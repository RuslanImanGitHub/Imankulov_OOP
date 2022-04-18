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
        //TODO: | Done Убрал метод, все делается через свойства
        private EmployeeBase _employee;

        public EmployeeBase Employee
        {
            set => _employee = value;
            get => _employee;
        }

        public EventArgsEmployeeAdded(EmployeeBase setEmployee)
        {
            this._employee = setEmployee;
        }
    }
}
