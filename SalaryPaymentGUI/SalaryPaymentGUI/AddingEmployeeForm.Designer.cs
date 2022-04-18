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
    partial class AddingEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmployeeSalaryTypeChoiceButton = new System.Windows.Forms.Button();
            this.CancelEmployeeAddButton = new System.Windows.Forms.Button();
            this.EmployeeCreationConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ставка",
            "Почасовая оплата",
            "Сдельная оплата"});
            this.comboBox1.Location = new System.Drawing.Point(12, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите тип начисления зарплаты для будущего работника";
            // 
            // EmployeeSalaryTypeChoiceButton
            // 
            this.EmployeeSalaryTypeChoiceButton.Location = new System.Drawing.Point(155, 35);
            this.EmployeeSalaryTypeChoiceButton.Name = "EmployeeSalaryTypeChoiceButton";
            this.EmployeeSalaryTypeChoiceButton.Size = new System.Drawing.Size(75, 23);
            this.EmployeeSalaryTypeChoiceButton.TabIndex = 2;
            this.EmployeeSalaryTypeChoiceButton.Text = "Выбрать";
            this.EmployeeSalaryTypeChoiceButton.UseVisualStyleBackColor = true;
            this.EmployeeSalaryTypeChoiceButton.Click += new System.EventHandler(this.EmployeeSalaryTypeChoiceButton_Click);
            // 
            // CancelEmployeeAddButton
            // 
            this.CancelEmployeeAddButton.Location = new System.Drawing.Point(325, 452);
            this.CancelEmployeeAddButton.Name = "CancelEmployeeAddButton";
            this.CancelEmployeeAddButton.Size = new System.Drawing.Size(75, 23);
            this.CancelEmployeeAddButton.TabIndex = 4;
            this.CancelEmployeeAddButton.Text = "Отменить";
            this.CancelEmployeeAddButton.UseVisualStyleBackColor = true;
            this.CancelEmployeeAddButton.Click += new System.EventHandler(this.CancelEmployeeAddButton_Click);
            // 
            // EmployeeCreationConfirmButton
            // 
            this.EmployeeCreationConfirmButton.Location = new System.Drawing.Point(244, 452);
            this.EmployeeCreationConfirmButton.Name = "EmployeeCreationConfirmButton";
            this.EmployeeCreationConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.EmployeeCreationConfirmButton.TabIndex = 5;
            this.EmployeeCreationConfirmButton.Text = "Создать";
            this.EmployeeCreationConfirmButton.UseVisualStyleBackColor = true;
            this.EmployeeCreationConfirmButton.Click += new System.EventHandler(this.EmployeeCreationConfirmButton_Click);
            // 
            // AddingEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 487);
            this.Controls.Add(this.EmployeeCreationConfirmButton);
            this.Controls.Add(this.CancelEmployeeAddButton);
            this.Controls.Add(this.EmployeeSalaryTypeChoiceButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddingEmployeeForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EmployeeSalaryTypeChoiceButton;
        private System.Windows.Forms.Button CancelEmployeeAddButton;
        private System.Windows.Forms.Button EmployeeCreationConfirmButton;
    }
}