﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalaryPaymentProject;

namespace SalaryPaymentGUI
{
    public partial class AddingEmployeeForm : Form
    {
        public event EventHandler<EventArgsEmployeeAdded> EmployeeAdded;
        
        //TODO: инкапсуляция?
        private static string _employeeType;

        //TODO: RSDN 
        private static List<Control> _dictAcquisitionList = new List<Control>();

        //TODO: инкапсуляция?
        private List<Control> dataAcquisitionList = new List<Control>();

        //TODO: RSDN 
        private static List<Control> _labelList = new List<Control>();

        //TODO: RSDN 
        private Dictionary<string, Action> Instructions = new Dictionary<string, Action>()
        {
            { 
                "Оклад", 
                () => {   
                    //TODO: RSDN
                    var fieldNames = new List<string> 
                    {
                        "Имя", "Фамилия", "Пол", 
                        "Возраст", "Стартовый баланс", "Ставка"
                    };
                    var controls = BuildFields(fieldNames);
                    _dictAcquisitionList = controls[0];
                    _labelList = controls[1];
                    _employeeType = "WageEmployee";
                 } },
            { 
                "Почасовая оплата",
                () => {
                    var fieldNames = new List<string> 
                    {
                        "Имя", "Фамилия", "Пол", "Возраст", "Стартовый баланс",
                        "Почасовая ставка", "Отработанные часы"
                    };
                    var controls = BuildFields(fieldNames);
                    _dictAcquisitionList = controls[0];
                    _labelList = controls[1];
                    _employeeType = "PerHourEmployee";
                 } },
            { 
                "Сдельная оплата",
                () => {
                    var fieldNames = new List<string> 
                    {
                        "Имя", "Фамилия", "Пол", "Возраст", "Стартовый баланс",
                        "Поштучная ставка", "Выработка"
                    };
                    var controls = BuildFields(fieldNames);
                    _dictAcquisitionList = controls[0];
                    _labelList = controls[1];
                    _employeeType = "PerPcsEmployee";
            } }
        };

        public AddingEmployeeForm()
        {
            InitializeComponent();
            var tmpEmployeeTypeKeys = Instructions.Keys.ToList();
            comboBox1.DataSource = tmpEmployeeTypeKeys;

            this.EmployeeCreationConfirmButton.Enabled = false;
        }


        private void EmployeeSalaryTypeChoiceButton_Click(object sender, EventArgs e)
        {
            Instructions[comboBox1.Text].Invoke();
            //TODO: | Убрал лишнее
            dataAcquisitionList = _dictAcquisitionList;

            this.Controls.AddRange(dataAcquisitionList.ToArray());
            this.Controls.AddRange(_labelList.ToArray());
            this.EmployeeSalaryTypeChoiceButton.Enabled = false;
            this.EmployeeCreationConfirmButton.Enabled = true;
        }

        private void EmployeeCreationConfirmButton_Click(object sender, EventArgs e)
        {
            switch (_employeeType)
            {

                case nameof(WageEmployee):
                    var wageEmployee = new WageEmployee(
                        dataAcquisitionList[0].Text, 
                        dataAcquisitionList[1].Text,
                        int.Parse(dataAcquisitionList[2].Text),
                                        (Gender)Enum.Parse(typeof(Gender), dataAcquisitionList[3].Text),
                                        double.Parse(dataAcquisitionList[4].Text), double.Parse(dataAcquisitionList[5].Text));
                    UpdateNewEmployee(wageEmployee);
                    break;
                case nameof(PerHourEmployee):
                    PerHourEmployee perHourEmployee = new PerHourEmployee(dataAcquisitionList[0].Text, dataAcquisitionList[1].Text,
                                        int.Parse(dataAcquisitionList[2].Text),
                                        (Gender)Enum.Parse(typeof(Gender), dataAcquisitionList[3].Text),
                                        double.Parse(dataAcquisitionList[4].Text), double.Parse(dataAcquisitionList[5].Text),
                                        int.Parse(dataAcquisitionList[6].Text));
                    UpdateNewEmployee(perHourEmployee);
                    break;
                case nameof(PerPcsEmployee):
                    PerPcsEmployee perPcsEmployee = new PerPcsEmployee(dataAcquisitionList[0].Text, dataAcquisitionList[1].Text,
                                        int.Parse(dataAcquisitionList[2].Text),
                                        (Gender)Enum.Parse(typeof(Gender), dataAcquisitionList[3].Text),
                                        double.Parse(dataAcquisitionList[4].Text), double.Parse(dataAcquisitionList[5].Text),
                                        int.Parse(dataAcquisitionList[6].Text));
                    UpdateNewEmployee(perPcsEmployee);
                    break;
            }
            this.EmployeeSalaryTypeChoiceButton.Enabled = true;
        }

        private void CancelEmployeeAddButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateNewEmployee(EmployeeBase newEmployee)
        {
            //TODO: RSDN | Done
            var AddedEmployee = new EventArgsEmployeeAdded(newEmployee);
            EmployeeAdded?.Invoke(this, AddedEmployee);
        }

        //TODO: RSDN
        private static List<List<Control>> BuildFields(List<string> FieldNames)
        {
            List<Control> labels = new List<Control>();
            List<Control> boxes = new List<Control>();
            var controls = new List<List<Control>>();
            int startPosition = 64;
            const int gap = 31;
            for (int i = 0; i < FieldNames.Count; i++)
            {
                
                Label newLabel = new Label();
                newLabel.Text = FieldNames[i];
                //TODO: const | Done
                newLabel.Location = new Point(12, startPosition + i * gap);
                newLabel.Size = new Size(200, 21);
                labels.Add(newLabel);
                
                if (FieldNames[i] == "Пол")
                {
                    ComboBox genderBox = new ComboBox();
                    genderBox.DataSource = Enum.GetValues(typeof(Gender));
                    genderBox.Location = new Point(150, 126);
                    genderBox.Size = new Size(121, 21);
                    boxes.Add(genderBox);
                }
                else
                {
                    TextBox newBox = new TextBox();
                    newBox.Location = new Point(150, startPosition + i * gap);
                    newBox.Size = new Size(121, 21);
                    boxes.Add((newBox));
                }
            }
            controls.Add(boxes);
            controls.Add(labels);
            return controls;
        }
    }
}
