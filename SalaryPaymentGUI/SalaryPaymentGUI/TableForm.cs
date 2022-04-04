using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalaryPaymentProject;
using System.Xml;
using System.Xml.Serialization;

namespace SalaryPaymentGUI
{
    public partial class TableForm : Form
    {
        //TODO:
        public BindingList<EmployeeBase> employees = new BindingList<EmployeeBase>();
        public BindingList<WageEmployee> wageEmployees = new BindingList<WageEmployee>();
        public BindingList<PerHourEmployee> perHourEmployees = new BindingList<PerHourEmployee>();
        public BindingList<PerPcsEmployee> perPcsEmployees = new BindingList<PerPcsEmployee>();
        //TODO:
        public EventHandler<EventArgsEmployeeAdded> updateDelegate;

        public TableForm()
        {
            InitializeComponent();

            #if !DEBUG
            this.CreateRandomEmployeeButton.Visible = false;
            this.comboBox2.Visible = false;
            #endif
            this.dataGridView1.DataSource = employees;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            var addingEmployeeForm = new AddingEmployeeForm();
            addingEmployeeForm.EmployeeAdded += UpdateDelegateWithNewEmployee;
            addingEmployeeForm.Closed += (o, args) =>
            {
                addingEmployeeForm.EmployeeAdded -= UpdateDelegateWithNewEmployee;
            };
            addingEmployeeForm.Show();
        }

        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var dataSource = (BindingList<EmployeeBase>)this.dataGridView1.DataSource;
                dataSource.Remove((EmployeeBase)row.DataBoundItem);
            }
        }

        private void CalculateSalaryButton_Click(object sender, EventArgs e)
        {
            foreach(EmployeeBase employee in employees)
            {
                employee.ChangeMoney();
            }
        }

        private void CreateRandomEmployeeButton_Click(object sender, EventArgs e)
        {
            employees.Add(GenerateRandomEmployee());
            //wageEmployees.Add(newEmployee);
        }

        private EmployeeBase GenerateRandomEmployee()
        {
            var names = new List<string>
            {
                "Amari", "Ash", "Avery", "Bay", "Blake",
                "Cameron", "Casey", "Charlie", "Drew", "Emerson",
                "Jesse", "Morgan", "Remy", "Sam", "Bobbie"
            };
            var surnames = new List<string>
            {
                "Smith", "Johnson", "Williams", "Jones", "Brown",
                "Miller", "Wilson", "Moore", "Taylor", "Thomas",
                "Turner", "Mitchell", "Phillips", "Baker", "Adams"
            };

            switch (this.comboBox2.Text)
            {
                //TODO: строковые ключи
                case "Оклад":
                {
                    return WageEmployee.GetRandomWageEmployee(names, surnames);
                }
                case "Почасовя оплата":
                {
                    return PerHourEmployee.GetRandomPerHourEmployee(names, surnames);
                }
                case "Сдельная оплата":
                default:
                {
                    return PerPcsEmployee.GetRandomPerPcsEmployee(names, surnames);
                }
            }
        }

        public void UpdateDelegateWithNewEmployee (object source, EventArgsEmployeeAdded e)
        {
            employees.Add(e.GetEmployee());

            switch (e.GetEmployee())
            {
                case WageEmployee newEmployee:
                    this.wageEmployees.Add(newEmployee);
                break;

                case PerHourEmployee newEmployee:
                    this.perHourEmployees.Add(newEmployee);
                    break;

                case PerPcsEmployee newEmployee:
                    this.perPcsEmployees.Add(newEmployee);
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: строковые ключи
            if (this.comboBox1.Text == "Оклад")
            {
                this.dataGridView1.DataSource = this.wageEmployees;
            }
            if (this.comboBox1.Text == "Почасовя оплата")
            {
                this.dataGridView1.DataSource = this.perHourEmployees;
            }
            if (this.comboBox1.Text == "Сдельная оплата")
            {
                this.dataGridView1.DataSource = this.perPcsEmployees;
            }
            if (this.comboBox1.Text == "Все")
            {
                this.dataGridView1.DataSource = this.employees;
            }

            var columnNames = new List<string>();
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                columnNames.Add(this.dataGridView1.Columns[i].Name);
            }
            this.ColumnSortComboBox.DataSource = columnNames;
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var streamReader = new StreamReader(openFileDialog.FileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(BindingList<EmployeeBase>));
                    employees = (BindingList<EmployeeBase>)serializer.Deserialize(streamReader);
                    this.dataGridView1.DataSource = employees;
                }
            }
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML|*.xml";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileStream = new FileStream(saveFile.FileName, FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(BindingList<EmployeeBase>));
                    serializer.Serialize(fileStream, employees);
                    fileStream.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void ColumnSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentSelection = ColumnSortComboBox.SelectedItem;
            if (currentSelection != null)
            {
                foreach (DataGridViewColumn column in this.dataGridView1.Columns)
                {
                    if (column.Name == currentSelection)
                    {
                        var currnetType = column.ValueType;

                        if (currnetType == typeof(Int32) || currnetType == typeof(double))
                        {
                            var numericOperations = new string[] { "=", ">", "<" };
                            this.ActionSortComboBox.DataSource = numericOperations;
                        }
                        if (currnetType == typeof(string))
                        {
                            var textOperations = new string[] { "=" };
                            this.ActionSortComboBox.DataSource = textOperations;
                        }
                        if (currnetType == typeof(Gender))
                        {
                            this.ActionSortComboBox.DataSource = Enum.GetNames(typeof(Gender));
                        }
                    }
                }
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            /*
             * Код для сортировки источника данных, а не самого datagridview
             * 
            // Работает только с листом employee base :(
            BindingList<EmployeeBase> listDataSource = (BindingList<EmployeeBase>)this.dataGridView1.DataSource;
            BindingList<EmployeeBase> sortedEmployees = new BindingList<EmployeeBase>();

            if (Double.TryParse(this.DataSortTextBox.Text, out double numericData))
            {
                switch (this.ActionSortComboBox.SelectedIndex)
                {
                    case 0:
                        foreach (EmployeeBase employee in listDataSource)
                        {
                            if (Convert.ToDouble(employee.GetType().GetProperty(this.ColumnSortComboBox.Text).GetValue(employee)) == numericData)
                            {
                                sortedEmployees.Add(employee);
                            }
                        }
                        this.dataGridView1.DataSource = sortedEmployees;
                        break;

                    case 1:
                        foreach (EmployeeBase employee in listDataSource)
                        {
                            if (Convert.ToDouble(employee.GetType().GetProperty(this.ColumnSortComboBox.Text).GetValue(employee)) > numericData)
                            {
                                sortedEmployees.Add(employee);
                            }
                        }
                        this.dataGridView1.DataSource = sortedEmployees;
                        break;

                    case 2:
                        foreach (EmployeeBase employee in listDataSource)
                        {
                            if (Convert.ToDouble(employee.GetType().GetProperty(this.ColumnSortComboBox.Text).GetValue(employee)) < numericData)
                            {
                                sortedEmployees.Add(employee);
                            }
                        }
                        this.dataGridView1.DataSource = sortedEmployees;
                        break;
                }

            }
            else
            {
                if ((string)ColumnSortComboBox.SelectedItem == "Gender")
                {
                    foreach (EmployeeBase employee in listDataSource)
                    {
                        if (employee.GetType().GetProperty(this.ColumnSortComboBox.Text).GetValue(employee).ToString() == (string)this.ActionSortComboBox.SelectedItem)
                        {
                            sortedEmployees.Add(employee);
                        }
                    }
                    this.dataGridView1.DataSource = sortedEmployees;
                }
                else
                {
                    foreach (EmployeeBase employee in listDataSource)
                    {
                        if ((string)employee.GetType().GetProperty(this.ColumnSortComboBox.Text).GetValue(employee) == this.DataSortTextBox.Text)
                        {
                            sortedEmployees.Add(employee);
                        }
                    }
                    this.dataGridView1.DataSource = sortedEmployees;
                }
            }
            */

            //Код для сортировки датагридвью, работает без привязки к данным
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            currencyManager.SuspendBinding();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                var row = this.dataGridView1.Rows[i];
                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    var column = this.dataGridView1.Columns[j];
                    //TODO:
                    if ((string)ColumnSortComboBox.SelectedItem == "Gender")
                    {
                        if (column.Name == this.ColumnSortComboBox.SelectedItem)
                        {
                            if (row.Cells[column.Index].Value.ToString() == this.ActionSortComboBox.SelectedItem.ToString())
                            {
                                row.Selected = true;
                                row.Visible = true;
                            }
                            else
                            {
                                row.Selected = false;
                                row.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        switch(this.ActionSortComboBox.SelectedIndex)
                        {
                            case 0:
                                if (column.Name == this.ColumnSortComboBox.SelectedItem)
                                {
                                    if (double.TryParse(this.DataSortTextBox.Text, out double numericData))
                                    {
                                        if (Convert.ToDouble(row.Cells[column.Index].Value) == numericData)
                                        {
                                            row.Selected = true;
                                            row.Visible = true;
                                        }
                                        else
                                        {
                                            row.Selected = false;
                                            row.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        if (row.Cells[column.Index].Value.ToString() == this.DataSortTextBox.Text.ToString())
                                        {
                                            row.Selected = true;
                                            row.Visible = true;
                                        }
                                        else
                                        {
                                            row.Selected = false;
                                            row.Visible = false;
                                        }
                                    }
                                }
                                break;
                            case 1:
                                if (column.Name == this.ColumnSortComboBox.SelectedItem)
                                {
                                    if (double.TryParse(this.DataSortTextBox.Text, out double numericData))
                                    {
                                        if (Convert.ToDouble(row.Cells[column.Index].Value) > numericData)
                                        {
                                            row.Selected = true;
                                            row.Visible = true;
                                        }
                                        else
                                        {
                                            row.Selected = false;
                                            row.Visible = false;
                                        }
                                    }
                                }
                                break;
                            case 2:
                                if (column.Name == this.ColumnSortComboBox.SelectedItem)
                                {
                                    if (double.TryParse(this.DataSortTextBox.Text, out double numericData))
                                    {
                                        if (Convert.ToDouble(row.Cells[column.Index].Value) < numericData)
                                        {
                                            row.Selected = true;
                                            row.Visible = true;
                                        }
                                        else
                                        {
                                            row.Selected = false;
                                            row.Visible = false;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            currencyManager.ResumeBinding();
        }
    }
}
