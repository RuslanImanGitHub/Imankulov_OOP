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
        //TODO: public? | Done
        /// <summary>
        /// Datasource for datagridview
        /// </summary>
        private BindingList<EmployeeBase> _employees = new BindingList<EmployeeBase>();

        //TODO: public? | Done
        /// <summary>
        /// List of random employees that are transferd to datasource 
        /// </summary>
        private static BindingList<EmployeeBase> _employeesDict = new BindingList<EmployeeBase>();
        /// <summary>
        /// TableForm constructor 
        /// </summary>
        public TableForm()
        {
            InitializeComponent();

            #if !DEBUG
            this.CreateRandomEmployeeButton.Visible = false;
            this.comboBox2.Visible = false;
            #endif
            this.dataGridView1.DataSource = _employees;
            this.dataGridView1.AllowUserToAddRows = false;

            var columnNames = new List<string>();
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                columnNames.Add(this.dataGridView1.Columns[i].Name);
            }
            this.ColumnSortComboBox.DataSource = columnNames;
        }
        /// <summary>
        /// ButtonClick that creates AddingEmployeeForm to add a new employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// ButtonClick that deletes an employee selected in datagridview from datasource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var dataSource = (BindingList<EmployeeBase>)this.dataGridView1.DataSource;
                dataSource.Remove((EmployeeBase)row.DataBoundItem);
            }
        }

        /// <summary>
        /// Creates random employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateRandomEmployeeButton_Click(object sender, EventArgs e)
        {
            _employeesDict = _employees;
            GenerateRandomEmployee();
            _employees = _employeesDict;
            this.dataGridView1.DataSource = _employees;
            this.dataGridView1.Update();
        }

        //TODO: RSDN | Done
        /// <summary>
        /// Dictinary that is used to get random employee of a specified type
        /// </summary>
        private static Dictionary<string, Action> _randomEmployeeDictionary = new Dictionary<string, Action>()
        {
            { "Оклад",
                () => { _employeesDict.Add(WageEmployee.GetRandomWageEmployee());
                                } },
            { "Почасовая оплата",
                () => { _employeesDict.Add(PerHourEmployee.GetRandomPerHourEmployee());
                                } },
            { "Сдельная оплата",
                () => { _employeesDict.Add(PerPcsEmployee.GetRandomPerPcsEmployee());
                                } },
            {"", () => {} }
        };
        /// <summary>
        /// Method that is used to get random employee
        /// </summary>
        private void  GenerateRandomEmployee()
        {
            _randomEmployeeDictionary[comboBox2.Text].Invoke();
        }
        /// <summary>
        /// Method that catches event from AddingEmployeeForm and adds employee to datasource
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void UpdateDelegateWithNewEmployee (object source, EventArgsEmployeeAdded e)
        {
            _employees.Add(e.Employee);
        }
        /// <summary>
        /// ButtonClick that loads file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var streamReader = new StreamReader(openFileDialog.FileName))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(BindingList<EmployeeBase>));
                        _employees = (BindingList<EmployeeBase>)serializer.Deserialize(streamReader);
                        this.dataGridView1.DataSource = _employees;
                        this.StatusTextBox.Text = $"Загружен файл {openFileDialog.FileName}";
                    }
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                    this.StatusTextBox.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// ButtonClick that saves datasource to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    serializer.Serialize(fileStream, _employees);
                    fileStream.Close();
                    this.StatusTextBox.Text = $"Сохранен файл {saveFile.FileName}";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    this.StatusTextBox.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Choses what kind of sorting actions can user do to selected column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// ButtonClick that intializes filtering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortButton_Click(object sender, EventArgs e)
        {
            var listDataSource = (BindingList<EmployeeBase>)this.dataGridView1.DataSource;
            var sortedEmployees = new BindingList<EmployeeBase>();
            var selectedColumn = this.ColumnSortComboBox.Text;
            if (Double.TryParse(this.DataSortTextBox.Text, out double numericData))
            {
                foreach (EmployeeBase employee in listDataSource)
                {
                    if (CheckItem(ToDouble(employee, selectedColumn), numericData,
                            this.ActionSortComboBox.SelectedIndex))
                    {
                        sortedEmployees.Add(employee);
                    }
                }
                this.dataGridView1.DataSource = sortedEmployees;
            }
            else
            {
                var stringData = this.DataSortTextBox.Text;
                if (selectedColumn == "Gender")
                {
                    stringData = (string)this.ActionSortComboBox.SelectedItem;
                }
                foreach (EmployeeBase employee in listDataSource)
                {

                    if (CheckItem(ToString(employee, selectedColumn), stringData,
                            this.ActionSortComboBox.SelectedIndex))
                    {
                        sortedEmployees.Add(employee);
                    }
                }
                this.dataGridView1.DataSource = sortedEmployees;
                //TODO: duplication | Done
            }
        }
        /// <summary>
        /// Method that is used to convert value from employee object to double
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="selectedColumn"></param>
        /// <returns></returns>
        private double ToDouble(EmployeeBase employee, string selectedColumn)
        {
            //TODO: Передать как аргумент название проперти | Done
            return Convert.ToDouble(employee.GetType().GetProperty(selectedColumn).GetValue(employee));
        }
        /// <summary>
        /// Method that is used to convert value from employee object to string
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="selectedColumn"></param>
        /// <returns></returns>
        private string ToString(EmployeeBase employee, string selectedColumn)
        {
            return Convert.ToString(employee.GetType().GetProperty(selectedColumn).GetValue(employee));
        }
        /// <summary>
        /// Method that performs sorting operations for doubles
        /// </summary>
        /// <param name="value1">Value that is being measured</param>
        /// <param name="value2">Value that is set as goal</param>
        /// <param name="checkingType">Operation type</param>
        /// <returns></returns>
        private bool CheckItem(double value1, double value2, int checkingType)
        {
            string errorText = "Can't perform that operation";
            switch (checkingType)
            {
                case 0:
                    return value1 == value2;
                case 1:
                    return value1 > value2;
                case 2:
                    return value1 < value2;
                default:
                    MessageBox.Show(errorText);
                    return false;
            }
        }
        /// <summary>
        /// Method that performs sorting operations for strings
        /// </summary>
        /// <param name="value1">Value that is being measured</param>
        /// <param name="value2">Value that is set as goal</param>
        /// <param name="checkingType">Operation type</param>
        /// <returns></returns>
        private bool CheckItem(string value1, string value2, int checkingType)
        {
            switch (checkingType)
            {
                case 0:
                    return value1 == value2;
                default:
                    return value1 == value2;
            }
        }
        /// <summary>
        /// ButtonClick that resets filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelFilterButton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = _employees;
        }
    }
}
