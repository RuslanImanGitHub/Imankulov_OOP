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
            this.EmployeeTypeSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelEmployeeAddButton = new System.Windows.Forms.Button();
            this.EmployeeCreationConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmployeeTypeSelector
            // 
            this.EmployeeTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmployeeTypeSelector.FormattingEnabled = true;
            this.EmployeeTypeSelector.Items.AddRange(new object[] {
            "Ставка",
            "Почасовая оплата",
            "Сдельная оплата"});
            this.EmployeeTypeSelector.Location = new System.Drawing.Point(12, 35);
            this.EmployeeTypeSelector.Name = "EmployeeTypeSelector";
            this.EmployeeTypeSelector.Size = new System.Drawing.Size(121, 21);
            this.EmployeeTypeSelector.TabIndex = 0;
            this.EmployeeTypeSelector.SelectedIndexChanged += new System.EventHandler(this.EmployeeTypeSelector_SelectedIndexChanged);
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
            // CancelEmployeeAddButton
            // 
            this.CancelEmployeeAddButton.Location = new System.Drawing.Point(260, 331);
            this.CancelEmployeeAddButton.Name = "CancelEmployeeAddButton";
            this.CancelEmployeeAddButton.Size = new System.Drawing.Size(75, 23);
            this.CancelEmployeeAddButton.TabIndex = 4;
            this.CancelEmployeeAddButton.Text = "Отменить";
            this.CancelEmployeeAddButton.UseVisualStyleBackColor = true;
            this.CancelEmployeeAddButton.Click += new System.EventHandler(this.CancelEmployeeAddButton_Click);
            // 
            // EmployeeCreationConfirmButton
            // 
            this.EmployeeCreationConfirmButton.Location = new System.Drawing.Point(179, 331);
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
            this.ClientSize = new System.Drawing.Size(348, 366);
            this.Controls.Add(this.EmployeeCreationConfirmButton);
            this.Controls.Add(this.CancelEmployeeAddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmployeeTypeSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddingEmployeeForm";
            this.Text = "Добавление сотрудников";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EmployeeTypeSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelEmployeeAddButton;
        private System.Windows.Forms.Button EmployeeCreationConfirmButton;
    }
}