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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ColumnSortComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataSortTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ActionSortComboBox = new System.Windows.Forms.ComboBox();
            this.SortButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDataGridView.Controls.Add(this.dataGridView1);
            this.panelDataGridView.Location = new System.Drawing.Point(12, 12);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(944, 591);
            this.panelDataGridView.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(934, 581);
            this.dataGridView1.TabIndex = 0;
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.Location = new System.Drawing.Point(962, 49);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(129, 23);
            this.AddEmployeeButton.TabIndex = 1;
            this.AddEmployeeButton.Text = "Добавить сотрудника";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            this.AddEmployeeButton.Click += new System.EventHandler(this.AddEmployeeButton_Click);
            // 
            // DeleteEmployeeButton
            // 
            this.DeleteEmployeeButton.Location = new System.Drawing.Point(962, 78);
            this.DeleteEmployeeButton.Name = "DeleteEmployeeButton";
            this.DeleteEmployeeButton.Size = new System.Drawing.Size(129, 23);
            this.DeleteEmployeeButton.TabIndex = 2;
            this.DeleteEmployeeButton.Text = "Удалить сотрудника";
            this.DeleteEmployeeButton.UseVisualStyleBackColor = true;
            this.DeleteEmployeeButton.Click += new System.EventHandler(this.DeleteEmployeeButton_Click);
            // 
            // CreateRandomEmployeeButton
            // 
            this.CreateRandomEmployeeButton.Location = new System.Drawing.Point(1092, 549);
            this.CreateRandomEmployeeButton.Name = "CreateRandomEmployeeButton";
            this.CreateRandomEmployeeButton.Size = new System.Drawing.Size(129, 49);
            this.CreateRandomEmployeeButton.TabIndex = 6;
            this.CreateRandomEmployeeButton.Text = "Создать случайного сотрудника";
            this.CreateRandomEmployeeButton.UseVisualStyleBackColor = true;
            this.CreateRandomEmployeeButton.Click += new System.EventHandler(this.CreateRandomEmployeeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(962, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Текущий тип сотрудников";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Оклад",
            "Почасовая оплата",
            "Сдельная оплата"});
            this.comboBox2.Location = new System.Drawing.Point(957, 549);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(129, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(961, 164);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(128, 23);
            this.SaveFileButton.TabIndex = 10;
            this.SaveFileButton.Text = "Сохранить";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(1095, 164);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(128, 23);
            this.LoadFileButton.TabIndex = 11;
            this.LoadFileButton.Text = "Загрузить";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(961, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 20);
            this.textBox1.TabIndex = 12;
            // 
            // ColumnSortComboBox
            // 
            this.ColumnSortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnSortComboBox.FormattingEnabled = true;
            this.ColumnSortComboBox.Location = new System.Drawing.Point(961, 241);
            this.ColumnSortComboBox.Name = "ColumnSortComboBox";
            this.ColumnSortComboBox.Size = new System.Drawing.Size(129, 21);
            this.ColumnSortComboBox.TabIndex = 13;
            this.ColumnSortComboBox.SelectedIndexChanged += new System.EventHandler(this.ColumnSortComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(958, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Столбец для сортировки";
            // 
            // DataSortTextBox
            // 
            this.DataSortTextBox.Location = new System.Drawing.Point(961, 328);
            this.DataSortTextBox.Name = "DataSortTextBox";
            this.DataSortTextBox.Size = new System.Drawing.Size(130, 20);
            this.DataSortTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(959, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Информация для сортировки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(959, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Действие для сортировки";
            // 
            // ActionSortComboBox
            // 
            this.ActionSortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionSortComboBox.FormattingEnabled = true;
            this.ActionSortComboBox.Location = new System.Drawing.Point(961, 287);
            this.ActionSortComboBox.Name = "ActionSortComboBox";
            this.ActionSortComboBox.Size = new System.Drawing.Size(129, 21);
            this.ActionSortComboBox.TabIndex = 17;
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(961, 354);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(130, 23);
            this.SortButton.TabIndex = 19;
            this.SortButton.Text = "Отсортировать";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1105, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Сбросить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 615);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ActionSortComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DataSortTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColumnSortComboBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateRandomEmployeeButton);
            this.Controls.Add(this.DeleteEmployeeButton);
            this.Controls.Add(this.AddEmployeeButton);
            this.Controls.Add(this.panelDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableForm";
            this.Text = "Form1";
            this.panelDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddEmployeeButton;
        private System.Windows.Forms.Button DeleteEmployeeButton;
        private System.Windows.Forms.Button CreateRandomEmployeeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox ColumnSortComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DataSortTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ActionSortComboBox;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button button1;
    }
}

