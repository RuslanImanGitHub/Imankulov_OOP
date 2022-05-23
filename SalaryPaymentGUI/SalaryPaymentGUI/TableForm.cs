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
    /// <summary>
    /// Form where you can load/save and filter data 
    /// </summary>
    public partial class TableForm : Form
    {
        /// <summary>
        /// Datasource for datagridview
        /// </summary>
        private BindingList<EmployeeBase> _employees = new BindingList<EmployeeBase>();

        /// <summary>
        /// Dictionary with string keys and actions
        /// </summary>
        private readonly Dictionary<string, Action> _randomEmployeeDictionary;

        /// <summary>
        /// TableForm constructor 
        /// </summary>
        public TableForm()
        {
            InitializeComponent();

            #if !DEBUG
            this.CreateRandomEmployeeButton.Visible = false;
            #endif
            this.dataGridView1.DataSource = _employees;
            this.dataGridView1.AllowUserToAddRows = false;

            var columnNames = new List<string>();
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                columnNames.Add(this.dataGridView1.Columns[i].Name);
            }
            this.ColumnSortComboBox.DataSource = columnNames;
            
            this._randomEmployeeDictionary = new Dictionary<string, Action>()
            {
                { nameof(WageEmployee),
                    () => { _employees.Add(WageEmployee.GetRandomWageEmployee());
                    } },
                { nameof(PerHourEmployee),
                    () => { _employees.Add(PerHourEmployee.GetRandomPerHourEmployee());
                    } },
                { nameof(PerPcsEmployee),
                    () => { _employees.Add(PerPcsEmployee.GetRandomPerPcsEmployee());
                    } },
                {"", () => {} }

            };
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
            this.AddEmployeeButton.Enabled = false;
            addingEmployeeForm.Show();
            addingEmployeeForm.FormClosed += (s, a) => this.AddEmployeeButton.Enabled = true;
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
            GenerateRandomEmployee();
            this.dataGridView1.DataSource = _employees;
            this.dataGridView1.Update();
        }


        /// <summary>
        /// Method that is used to get random employee
        /// </summary>
        private void  GenerateRandomEmployee()
        {
            Random random = new Random();
            List<string> employeeTypes = new List<string>()
            {
                nameof(WageEmployee),
                nameof(PerHourEmployee),
                nameof(PerPcsEmployee)
            };
            this._randomEmployeeDictionary[employeeTypes[random.Next(0,2)]].Invoke();
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
                    }
                }
                catch (Exception ex)
                {
                    if (ex is FormatException ||
                        ex is InvalidOperationException ||
                        ex is ArgumentException ||
                        ex is ArgumentOutOfRangeException)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString(),
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        throw;
                    }
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString(),
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.DataSortTextBox.Show();
            this.label3.Show();
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
                            this.DataSortTextBox.Hide();
                            this.label3.Hide();
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

            var stringData = this.DataSortTextBox.Text;
            if (selectedColumn == "Gender")
            {
                stringData = (string)this.ActionSortComboBox.SelectedItem;
            }
            foreach (EmployeeBase employee in listDataSource)
            {
                if (Double.TryParse(this.DataSortTextBox.Text, out double numericData))
                {
                    try
                    {
                        var doubleValue = Convert.ToDouble(GetValue(employee, selectedColumn));
                        if (CheckItem(doubleValue, numericData,
                                this.ActionSortComboBox.SelectedIndex))
                        {
                            sortedEmployees.Add(employee);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    
                }
                else
                {
                    var stringValue = Convert.ToString(GetValue(employee, selectedColumn));
                    if (stringValue == stringData)
                    {
                        sortedEmployees.Add(employee);
                    }
                }
                this.dataGridView1.DataSource = sortedEmployees;
            }
            //this.dataGridView1.DataSource = sortedEmployees;
        }

        /// <summary>
        /// Returns selected property of selected item
        /// </summary>
        /// <param name="employee">Employee from employeeList</param>
        /// <param name="selectedColumn">Property that needs to be returned</param>
        /// <returns></returns>
        private static object GetValue(EmployeeBase employee, string selectedColumn)
        {
            return employee.GetType().GetProperty(selectedColumn).GetValue(employee);
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
