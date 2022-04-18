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
        //TODO: public?
        public BindingList<EmployeeBase> employees = new BindingList<EmployeeBase>();

        //TODO: public?
        public static BindingList<EmployeeBase> _employeesDict = new BindingList<EmployeeBase>();

        //TODO: 
        public EventHandler<EventArgsEmployeeAdded> _updateDelegate;

        public TableForm()
        {
            InitializeComponent();

            #if !DEBUG
            this.CreateRandomEmployeeButton.Visible = false;
            this.comboBox2.Visible = false;
            #endif
            this.dataGridView1.DataSource = employees;
            this.dataGridView1.AllowUserToAddRows = false;

            var columnNames = new List<string>();
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                columnNames.Add(this.dataGridView1.Columns[i].Name);
            }
            this.ColumnSortComboBox.DataSource = columnNames;
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

        //TODO:
        private void CalculateSalaryButton_Click(object sender, EventArgs e)
        {
            foreach(EmployeeBase employee in employees)
            {
                employee.ChangeMoney();
                this.dataGridView1.Update();
            }
        }

        private void CreateRandomEmployeeButton_Click(object sender, EventArgs e)
        {
            _employeesDict = employees;
            GenerateRandomEmployee();
            employees = _employeesDict;
            this.dataGridView1.DataSource = employees;
            this.dataGridView1.Update();
        }

        //TODO:
        static List<string> names = new List<string>
        {
            "Amari", "Ash", "Avery", "Bay", "Blake",
            "Cameron", "Casey", "Charlie", "Drew", "Emerson",
            "Jesse", "Morgan", "Remy", "Sam", "Bobbie"
        };

        //TODO:
        static List<string> surnames = new List<string>
        {
            "Smith", "Johnson", "Williams", "Jones", "Brown",
            "Miller", "Wilson", "Moore", "Taylor", "Thomas",
            "Turner", "Mitchell", "Phillips", "Baker", "Adams"
        };

        //TODO: RSDN
        Dictionary<string, Action> RandomEmployeeDictionary = new Dictionary<string, Action>()
        {
            { "Оклад", () => { _employeesDict.Add(WageEmployee.GetRandomWageEmployee(names, surnames));
                                } },
            { "Почасовая оплата", () => { _employeesDict.Add(PerHourEmployee.GetRandomPerHourEmployee(names, surnames));
                                } },
            { "Сдельная оплата", () => { _employeesDict.Add(PerPcsEmployee.GetRandomPerPcsEmployee(names, surnames));
                                } },
            {"", () => {} }
        };
        private void  GenerateRandomEmployee()
        {
            RandomEmployeeDictionary[comboBox2.Text].Invoke();
        }

        public void UpdateDelegateWithNewEmployee (object source, EventArgsEmployeeAdded e)
        {
            employees.Add(e.Employee);
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //TODO:
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
                        else if (currnetType == typeof(string))
                        {
                            var textOperations = new string[] { "=" };
                            this.ActionSortComboBox.DataSource = textOperations;
                        }
                        else if (currnetType == typeof(Gender))
                        {
                            this.ActionSortComboBox.DataSource = Enum.GetNames(typeof(Gender));
                        }
                    }
                }
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            currencyManager.SuspendBinding();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                var row = this.dataGridView1.Rows[i];
                for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                {
                    var column = this.dataGridView1.Columns[j];

                    if ((string)ColumnSortComboBox.SelectedItem == "Gender")
                    {
                        if (column.Name == this.ColumnSortComboBox.SelectedItem)
                        {
                            //TODO: RSDN
                            //TODO: duplication 1
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
                                        //TODO: duplication 2
                                        if (CheckItem(Convert.ToDouble(row.Cells[column.Index].Value),
                                                numericData,
                                                this.ActionSortComboBox.SelectedIndex))
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
                                        //TODO: duplication 1
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
                                        //TODO: duplication 2
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
                                        //TODO: duplication 2

                                        var isLessValue = 
                                            Convert.ToDouble(row.Cells[column.Index].Value) < numericData;
                                        row.Selected = isLessValue;
                                        row.Visible = isLessValue;
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            currencyManager.ResumeBinding();
        }

        private bool CheckItem(double value1, double value2, int checkingType)
        {
            switch (checkingType)
            {
                case 0:
                    return value1 > value2;
                case 1:
                    return value1 < value2;
                default:
                    return value1 == value2;
            }
        }

        //TODO: RSDN
        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = employees;
        }
    }
}
