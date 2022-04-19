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
        /// <summary>
        /// EventHandler to get employee to TableForm
        /// </summary>
        public event EventHandler<EventArgsEmployeeAdded> EmployeeAdded;
        
        //TODO: инкапсуляция? | Done
        /// <summary>
        /// Indicates what type employee is being created
        /// </summary>
        private static string _employeeType;

        //TODO: RSDN | Done
        /// <summary>
        /// List of controls that is used to get them from action in _instructions
        /// </summary>
        private static List<Control> _dictAcquisitionList = new List<Control>();

        //TODO: инкапсуляция? | Done
        /// <summary>
        /// list of interactable controls that is used to get them on the form
        /// </summary>
        private List<Control> _dataAcquisitionList = new List<Control>();

        //TODO: RSDN | Done
        /// <summary>
        /// list of label controls that is used to get them on the form
        /// </summary>
        private static List<Control> _labelList = new List<Control>();

        //TODO: RSDN | Done
        /// <summary>
        /// Dictinary that is used to create controls according to employee type that is being created
        /// </summary>
        private Dictionary<string, Action> _instructions = new Dictionary<string, Action>()
        {
            { 
                "Оклад", 
                () => {   
                    //TODO: RSDN | Done
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

        /// <summary>
        /// AddingEmployeeForm constructor
        /// </summary>
        public AddingEmployeeForm()
        {
            InitializeComponent();
            var tmpEmployeeTypeKeys = _instructions.Keys.ToList();
            comboBox1.DataSource = tmpEmployeeTypeKeys;

            this.EmployeeCreationConfirmButton.Enabled = false;
        }

        /// <summary>
        /// ButtonClick that creates fields to accept information about employees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeSalaryTypeChoiceButton_Click(object sender, EventArgs e)
        {
            _instructions[comboBox1.Text].Invoke();
            //TODO: | Убрал лишнее
            _dataAcquisitionList = _dictAcquisitionList;

            this.Controls.AddRange(_dataAcquisitionList.ToArray());
            this.Controls.AddRange(_labelList.ToArray());
            foreach (Control control in _dataAcquisitionList)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            this.EmployeeSalaryTypeChoiceButton.Enabled = false;
            this.EmployeeCreationConfirmButton.Enabled = true;
        }
        /// <summary>
        /// ButtonClick that reads info from fields about employees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeCreationConfirmButton_Click(object sender, EventArgs e)
        {
            switch (_employeeType)
            {

                case nameof(WageEmployee):
                    var wageEmployee = new WageEmployee(
                        _dataAcquisitionList[0].Text, 
                        _dataAcquisitionList[1].Text,
                        int.Parse(_dataAcquisitionList[3].Text),
                        (Gender)Enum.Parse(typeof(Gender), _dataAcquisitionList[2].Text),
                        double.Parse(_dataAcquisitionList[4].Text),
                        double.Parse(_dataAcquisitionList[5].Text));
                    UpdateNewEmployee(wageEmployee);
                    break;
                case nameof(PerHourEmployee):
                    var perHourEmployee = new PerHourEmployee(
                        _dataAcquisitionList[0].Text,
                        _dataAcquisitionList[1].Text,
                        int.Parse(_dataAcquisitionList[3].Text),
                        (Gender)Enum.Parse(typeof(Gender), _dataAcquisitionList[2].Text),
                        double.Parse(_dataAcquisitionList[4].Text),
                        double.Parse(_dataAcquisitionList[5].Text),
                        int.Parse(_dataAcquisitionList[6].Text));
                    UpdateNewEmployee(perHourEmployee);
                    break;
                case nameof(PerPcsEmployee):
                    var perPcsEmployee = new PerPcsEmployee(
                        _dataAcquisitionList[0].Text,
                        _dataAcquisitionList[1].Text,
                        int.Parse(_dataAcquisitionList[3].Text),
                        (Gender)Enum.Parse(typeof(Gender), _dataAcquisitionList[2].Text),
                        double.Parse(_dataAcquisitionList[4].Text),
                        double.Parse(_dataAcquisitionList[5].Text),
                        int.Parse(_dataAcquisitionList[6].Text));
                    UpdateNewEmployee(perPcsEmployee);
                    break;
            }
            this.EmployeeSalaryTypeChoiceButton.Enabled = true;
            foreach (Control control in _dataAcquisitionList)
            {
                this.Controls.Remove(control);
            }
            foreach (Control control in _labelList)
            {
                this.Controls.Remove(control);
            }
        }
        /// <summary>
        /// ButtonClick that closes AddingEmployeeForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEmployeeAddButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Event that triggers UpdateDelegateWithNewEmployee event in TableForm
        /// </summary>
        /// <param name="newEmployee"></param>
        public void UpdateNewEmployee(EmployeeBase newEmployee)
        {
            //TODO: RSDN | Done
            var AddedEmployee = new EventArgsEmployeeAdded(newEmployee);
            EmployeeAdded?.Invoke(this, AddedEmployee);
        }
        /// <summary>
        /// Method to create fields to accept information about new employee
        /// </summary>
        /// <param name="fieldNames">Names of fields that should be created</param>
        /// <returns></returns>
        //TODO: RSDN | Done
        private static List<List<Control>> BuildFields(List<string> fieldNames)
        {
            List<Control> labels = new List<Control>();
            List<Control> boxes = new List<Control>();
            var controls = new List<List<Control>>();
            int startPosition = 64;
            const int gap = 31;
            for (int i = 0; i < fieldNames.Count; i++)
            {
                
                Label newLabel = new Label();
                newLabel.Text = fieldNames[i];
                //TODO: const | Done
                newLabel.Location = new Point(12, startPosition + i * gap);
                newLabel.Size = new Size(200, 21);
                labels.Add(newLabel);
                
                if (fieldNames[i] == "Пол")
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
