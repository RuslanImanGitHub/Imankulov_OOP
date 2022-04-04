using System;
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
        
        //TODO: RSDN
        public string EmployeeType;

        //TODO: RSDN
        List<Control> DataAcquisitionList = new List<Control>();


        Dictionary<string, Action> dictionary = new Dictionary<string, Action>()
        {
            { "Ставка", () => { } }
        };

        public AddingEmployeeForm()
        {
            InitializeComponent();
            var tmpEmployeeTypeKeys = dictionary.Keys.ToList();
            comboBox1.DataSource = tmpEmployeeTypeKeys;

            this.EmployeeCreationConfirmButton.Enabled = false;
        }


        private void EmployeeSalaryTypeChoiceButton_Click(object sender, EventArgs e)
        {
            //TODO: duplication
            Label nameLabel = new Label();
            nameLabel.Text = "Имя";
            nameLabel.Location = new Point(12, 64);
            nameLabel.Size = new Size(200, 21);
            TextBox nameBox = new TextBox();
            nameBox.Location = new Point(150, 64);
            nameBox.Size = new Size(121, 21);

            //TODO: duplication
            Label surnameLabel = new Label();
            surnameLabel.Text = "фамилия";
            surnameLabel.Location = new Point(12, 95);
            surnameLabel.Size = new Size(200, 21);
            TextBox surnameBox = new TextBox();
            surnameBox.Location = new Point(150, 95);
            surnameBox.Size = new Size(121, 21);

            //TODO: duplication
            Label genderLabel = new Label();
            genderLabel.Text = "Пол";
            genderLabel.Location = new Point(12, 126);
            genderLabel.Size = new Size(200, 21);
            ComboBox genderBox = new ComboBox();
            genderBox.DataSource = Enum.GetValues(typeof(Gender));
            genderBox.Location = new Point(150, 126);
            genderBox.Size = new Size(121, 21);

            Label ageLabel = new Label();
            ageLabel.Text = "Возраст";
            ageLabel.Location = new Point(12, 157);
            ageLabel.Size = new Size(200, 21);
            TextBox ageBox = new TextBox();
            ageBox.Location = new Point(150, 157);
            ageBox.Size = new Size(121, 21);

            Label accountLabel = new Label();
            accountLabel.Text = "Стартовый баланс";
            accountLabel.Location = new Point(12, 188);
            accountLabel.Size = new Size(200, 21);
            TextBox accountBox = new TextBox();
            accountBox.Location = new Point(150, 188);
            accountBox.Size = new Size(121, 21);

            //TODO: RSDN
            List<Control> controlList = new List<Control> { nameBox, surnameBox, ageBox, genderBox, accountBox };
            List<Label> labelList = new List<Label> { nameLabel, surnameLabel, genderLabel, ageLabel, accountLabel };

            
            dictionary[comboBox1.Text].Invoke();

            //TODO: строковые ключи
            if (this.comboBox1.Text == "Ставка")
            {
                Label wageLabel = new Label();
                wageLabel.Text = "Оклад";
                wageLabel.Location = new Point(12, 219);
                wageLabel.Size = new Size(200, 21);
                TextBox wageBox = new TextBox();
                wageBox.Location = new Point(150, 219);
                wageBox.Size = new Size(121, 21);
                EmployeeType = "WageEmployee";
                controlList.Add(wageBox);
                labelList.Add(wageLabel);
            }

            if (this.comboBox1.Text == "Почасовая оплата")
            {
                Label hourlyPaymentLabel = new Label();
                hourlyPaymentLabel.Text = "Почасовая ставка";
                hourlyPaymentLabel.Location = new Point(12, 219);
                hourlyPaymentLabel.Size = new Size(200, 21);
                TextBox hourlyPaymentBox = new TextBox();
                hourlyPaymentBox.Location = new Point(150, 219);
                hourlyPaymentBox.Size = new Size(121, 21);
                controlList.Add(hourlyPaymentBox);
                labelList.Add(hourlyPaymentLabel);

                Label hoursWorkedLabel = new Label();
                hoursWorkedLabel.Text = "Отработанные часы";
                hoursWorkedLabel.Location = new Point(12, 250);
                hoursWorkedLabel.Size = new Size(200, 21);
                TextBox hoursWorkedBox = new TextBox();
                hoursWorkedBox.Location = new Point(150, 250);
                hoursWorkedBox.Size = new Size(121, 21);
                controlList.Add(hoursWorkedBox);
                labelList.Add(hoursWorkedLabel);
                EmployeeType = "PerHourEmployee";
                
            }

            if (this.comboBox1.Text == "Сдельная оплата")
            {
                Label paymentPerOnePcsLabel = new Label();
                paymentPerOnePcsLabel.Text = "Поштучная ставка";
                paymentPerOnePcsLabel.Location = new Point(12, 219);
                paymentPerOnePcsLabel.Size = new Size(200, 21);
                TextBox paymentPerOnePcsBox = new TextBox();
                paymentPerOnePcsBox.Location = new Point(150, 219);
                paymentPerOnePcsBox.Size = new Size(121, 21);
                controlList.Add(paymentPerOnePcsBox);
                labelList.Add(paymentPerOnePcsLabel);

                Label amountPcsLabel = new Label();
                amountPcsLabel.Text = "Выработка";
                amountPcsLabel.Location = new Point(12, 250);
                amountPcsLabel.Size = new Size(200, 21);
                TextBox amountPcsBox = new TextBox();
                amountPcsBox.Location = new Point(150, 250);
                amountPcsBox.Size = new Size(121, 21);
                controlList.Add(amountPcsBox);
                labelList.Add(amountPcsLabel);
                EmployeeType = "PerPcsEmployee";
            }
            DataAcquisitionList = controlList;
            this.Controls.AddRange(controlList.ToArray());
            this.Controls.AddRange(labelList.ToArray());
            this.EmployeeSalaryTypeChoiceButton.Enabled = false;
            this.EmployeeCreationConfirmButton.Enabled = true;
        }

        private void EmployeeCreationConfirmButton_Click(object sender, EventArgs e)
        {
            switch (EmployeeType)
            {
                case "WageEmployee":
                    WageEmployee wageEmployee = new WageEmployee(DataAcquisitionList[0].Text, DataAcquisitionList[1].Text,
                                        int.Parse(DataAcquisitionList[2].Text),
                                        (Gender)Enum.Parse(typeof(Gender), DataAcquisitionList[3].Text),
                                        double.Parse(DataAcquisitionList[4].Text), double.Parse(DataAcquisitionList[5].Text));
                    UpdateNewEmployee(wageEmployee);
                    break;
                case "PerHourEmployee":
                    PerHourEmployee perHourEmployee = new PerHourEmployee(DataAcquisitionList[0].Text, DataAcquisitionList[1].Text,
                                        int.Parse(DataAcquisitionList[2].Text),
                                        (Gender)Enum.Parse(typeof(Gender), DataAcquisitionList[3].Text),
                                        double.Parse(DataAcquisitionList[4].Text), double.Parse(DataAcquisitionList[5].Text),
                                        int.Parse(DataAcquisitionList[6].Text));
                    UpdateNewEmployee(perHourEmployee);
                    break;
                case "PerPcsEmployee":
                    PerPcsEmployee perPcsEmployee = new PerPcsEmployee(DataAcquisitionList[0].Text, DataAcquisitionList[1].Text,
                                        int.Parse(DataAcquisitionList[2].Text),
                                        (Gender)Enum.Parse(typeof(Gender), DataAcquisitionList[3].Text),
                                        double.Parse(DataAcquisitionList[4].Text), double.Parse(DataAcquisitionList[5].Text),
                                        int.Parse(DataAcquisitionList[6].Text));
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
            //TODO: RSDN
            var b = new EventArgsEmployeeAdded(newEmployee)
            {
                Employee = newEmployee
            };
            EmployeeAdded?.Invoke(this, b);
        }
    }
}
