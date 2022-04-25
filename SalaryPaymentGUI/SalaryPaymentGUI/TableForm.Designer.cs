namespace SalaryPaymentGUI
{
    partial class TableForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddEmployeeButton = new System.Windows.Forms.Button();
            this.DeleteEmployeeButton = new System.Windows.Forms.Button();
            this.CreateRandomEmployeeButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.ColumnSortComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataSortTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ActionSortComboBox = new System.Windows.Forms.ComboBox();
            this.SortButton = new System.Windows.Forms.Button();
            this.CancelFilterButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDataGridView.Controls.Add(this.dataGridView1);
            this.panelDataGridView.Location = new System.Drawing.Point(12, 12);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(895, 446);
            this.panelDataGridView.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(885, 431);
            this.dataGridView1.TabIndex = 0;
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.Location = new System.Drawing.Point(12, 19);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(129, 23);
            this.AddEmployeeButton.TabIndex = 1;
            this.AddEmployeeButton.Text = "Добавить сотрудника";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            this.AddEmployeeButton.Click += new System.EventHandler(this.AddEmployeeButton_Click);
            // 
            // DeleteEmployeeButton
            // 
            this.DeleteEmployeeButton.Location = new System.Drawing.Point(172, 19);
            this.DeleteEmployeeButton.Name = "DeleteEmployeeButton";
            this.DeleteEmployeeButton.Size = new System.Drawing.Size(129, 23);
            this.DeleteEmployeeButton.TabIndex = 2;
            this.DeleteEmployeeButton.Text = "Удалить сотрудника";
            this.DeleteEmployeeButton.UseVisualStyleBackColor = true;
            this.DeleteEmployeeButton.Click += new System.EventHandler(this.DeleteEmployeeButton_Click);
            // 
            // CreateRandomEmployeeButton
            // 
            this.CreateRandomEmployeeButton.Location = new System.Drawing.Point(1106, 348);
            this.CreateRandomEmployeeButton.Name = "CreateRandomEmployeeButton";
            this.CreateRandomEmployeeButton.Size = new System.Drawing.Size(129, 49);
            this.CreateRandomEmployeeButton.TabIndex = 6;
            this.CreateRandomEmployeeButton.Text = "Создать случайного сотрудника";
            this.CreateRandomEmployeeButton.UseVisualStyleBackColor = true;
            this.CreateRandomEmployeeButton.Click += new System.EventHandler(this.CreateRandomEmployeeButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(172, 19);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(128, 23);
            this.SaveFileButton.TabIndex = 10;
            this.SaveFileButton.Text = "Сохранить";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(11, 19);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(128, 23);
            this.LoadFileButton.TabIndex = 11;
            this.LoadFileButton.Text = "Загрузить";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // ColumnSortComboBox
            // 
            this.ColumnSortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnSortComboBox.FormattingEnabled = true;
            this.ColumnSortComboBox.Location = new System.Drawing.Point(11, 51);
            this.ColumnSortComboBox.Name = "ColumnSortComboBox";
            this.ColumnSortComboBox.Size = new System.Drawing.Size(129, 21);
            this.ColumnSortComboBox.TabIndex = 13;
            this.ColumnSortComboBox.SelectedIndexChanged += new System.EventHandler(this.ColumnSortComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Столбец для сортировки";
            // 
            // DataSortTextBox
            // 
            this.DataSortTextBox.Location = new System.Drawing.Point(11, 138);
            this.DataSortTextBox.Name = "DataSortTextBox";
            this.DataSortTextBox.Size = new System.Drawing.Size(130, 20);
            this.DataSortTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Информация для сортировки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Действие для сортировки";
            // 
            // ActionSortComboBox
            // 
            this.ActionSortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionSortComboBox.FormattingEnabled = true;
            this.ActionSortComboBox.Location = new System.Drawing.Point(11, 97);
            this.ActionSortComboBox.Name = "ActionSortComboBox";
            this.ActionSortComboBox.Size = new System.Drawing.Size(129, 21);
            this.ActionSortComboBox.TabIndex = 17;
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(172, 106);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(130, 23);
            this.SortButton.TabIndex = 19;
            this.SortButton.Text = "Отсортировать";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // CancelFilterButton
            // 
            this.CancelFilterButton.Location = new System.Drawing.Point(172, 135);
            this.CancelFilterButton.Name = "CancelFilterButton";
            this.CancelFilterButton.Size = new System.Drawing.Size(130, 23);
            this.CancelFilterButton.TabIndex = 20;
            this.CancelFilterButton.Text = "Сбросить";
            this.CancelFilterButton.UseVisualStyleBackColor = true;
            this.CancelFilterButton.Click += new System.EventHandler(this.CancelFilterButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SortButton);
            this.groupBox1.Controls.Add(this.CancelFilterButton);
            this.groupBox1.Controls.Add(this.ColumnSortComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DataSortTextBox);
            this.groupBox1.Controls.Add(this.ActionSortComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(923, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 168);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтрация";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LoadFileButton);
            this.groupBox2.Controls.Add(this.SaveFileButton);
            this.groupBox2.Location = new System.Drawing.Point(923, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 55);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Загрузка/Сохранение";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AddEmployeeButton);
            this.groupBox3.Controls.Add(this.DeleteEmployeeButton);
            this.groupBox3.Location = new System.Drawing.Point(923, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 56);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Добавление/Удаление";
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 462);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CreateRandomEmployeeButton);
            this.Controls.Add(this.panelDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableForm";
            this.Text = "Таблица сотрудников";
            this.panelDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

#endregion

        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddEmployeeButton;
        private System.Windows.Forms.Button DeleteEmployeeButton;
        private System.Windows.Forms.Button CreateRandomEmployeeButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.ComboBox ColumnSortComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DataSortTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ActionSortComboBox;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button CancelFilterButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

