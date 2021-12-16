
namespace AutoInsertInDatabaseOnRussian
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.checkList = new System.Windows.Forms.Panel();
            this.PasportNumber = new System.Windows.Forms.CheckBox();
            this.Region = new System.Windows.Forms.CheckBox();
            this.City = new System.Windows.Forms.CheckBox();
            this.Country = new System.Windows.Forms.CheckBox();
            this.Email = new System.Windows.Forms.CheckBox();
            this.Phone = new System.Windows.Forms.CheckBox();
            this.Password = new System.Windows.Forms.CheckBox();
            this.Login = new System.Windows.Forms.CheckBox();
            this.Gender = new System.Windows.Forms.CheckBox();
            this.DateOfBirth = new System.Windows.Forms.CheckBox();
            this.PasportSerial = new System.Windows.Forms.CheckBox();
            this.Address = new System.Windows.Forms.CheckBox();
            this.FatherName = new System.Windows.Forms.CheckBox();
            this.FirstName = new System.Windows.Forms.CheckBox();
            this.LastName = new System.Windows.Forms.CheckBox();
            this.GoInsertData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.countRecords = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listTables = new System.Windows.Forms.ComboBox();
            this.listDatabases = new System.Windows.Forms.ComboBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutoInsert = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AdditionallyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // checkList
            // 
            this.checkList.Controls.Add(this.PasportNumber);
            this.checkList.Controls.Add(this.Region);
            this.checkList.Controls.Add(this.City);
            this.checkList.Controls.Add(this.Country);
            this.checkList.Controls.Add(this.Email);
            this.checkList.Controls.Add(this.Phone);
            this.checkList.Controls.Add(this.Password);
            this.checkList.Controls.Add(this.Login);
            this.checkList.Controls.Add(this.Gender);
            this.checkList.Controls.Add(this.DateOfBirth);
            this.checkList.Controls.Add(this.PasportSerial);
            this.checkList.Controls.Add(this.Address);
            this.checkList.Controls.Add(this.FatherName);
            this.checkList.Controls.Add(this.FirstName);
            this.checkList.Controls.Add(this.LastName);
            this.checkList.Enabled = false;
            this.checkList.Location = new System.Drawing.Point(364, 12);
            this.checkList.Name = "checkList";
            this.checkList.Size = new System.Drawing.Size(198, 457);
            this.checkList.TabIndex = 33;
            // 
            // PasportNumber
            // 
            this.PasportNumber.AutoSize = true;
            this.PasportNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasportNumber.Location = new System.Drawing.Point(12, 332);
            this.PasportNumber.Name = "PasportNumber";
            this.PasportNumber.Size = new System.Drawing.Size(158, 24);
            this.PasportNumber.TabIndex = 45;
            this.PasportNumber.Text = "Номер_паспорта";
            this.PasportNumber.UseVisualStyleBackColor = true;
            // 
            // Region
            // 
            this.Region.AutoSize = true;
            this.Region.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Region.Location = new System.Drawing.Point(12, 392);
            this.Region.Name = "Region";
            this.Region.Size = new System.Drawing.Size(81, 24);
            this.Region.TabIndex = 43;
            this.Region.Text = "Регион";
            this.Region.UseVisualStyleBackColor = true;
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.City.Location = new System.Drawing.Point(12, 422);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(75, 24);
            this.City.TabIndex = 42;
            this.City.Text = "Город";
            this.City.UseVisualStyleBackColor = true;
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Country.Location = new System.Drawing.Point(12, 362);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(84, 24);
            this.Country.TabIndex = 41;
            this.Country.Text = "Страна";
            this.Country.UseVisualStyleBackColor = true;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Checked = true;
            this.Email.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Email.Location = new System.Drawing.Point(12, 242);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(184, 24);
            this.Email.TabIndex = 40;
            this.Email.Text = "Электронная_почта";
            this.Email.UseVisualStyleBackColor = true;
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Checked = true;
            this.Phone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Phone.Location = new System.Drawing.Point(12, 212);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(166, 24);
            this.Phone.TabIndex = 39;
            this.Phone.Text = "Номер_телефона";
            this.Phone.UseVisualStyleBackColor = true;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password.Location = new System.Drawing.Point(12, 32);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(86, 24);
            this.Password.TabIndex = 38;
            this.Password.Text = "Пароль";
            this.Password.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login.Location = new System.Drawing.Point(12, 2);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(74, 24);
            this.Login.TabIndex = 37;
            this.Login.Text = "Логин";
            this.Login.UseVisualStyleBackColor = true;
            // 
            // Gender
            // 
            this.Gender.AutoSize = true;
            this.Gender.Checked = true;
            this.Gender.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Gender.Location = new System.Drawing.Point(12, 182);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(59, 24);
            this.Gender.TabIndex = 36;
            this.Gender.Text = "Пол";
            this.Gender.UseVisualStyleBackColor = true;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.AutoSize = true;
            this.DateOfBirth.Checked = true;
            this.DateOfBirth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateOfBirth.Location = new System.Drawing.Point(12, 152);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(152, 24);
            this.DateOfBirth.TabIndex = 35;
            this.DateOfBirth.Text = "Дата_рождения";
            this.DateOfBirth.UseVisualStyleBackColor = true;
            // 
            // PasportSerial
            // 
            this.PasportSerial.AutoSize = true;
            this.PasportSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasportSerial.Location = new System.Drawing.Point(12, 302);
            this.PasportSerial.Name = "PasportSerial";
            this.PasportSerial.Size = new System.Drawing.Size(155, 24);
            this.PasportSerial.TabIndex = 34;
            this.PasportSerial.Text = "Серия_паспорта";
            this.PasportSerial.UseVisualStyleBackColor = true;
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Address.Location = new System.Drawing.Point(12, 272);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(164, 24);
            this.Address.TabIndex = 33;
            this.Address.Text = "Домашний_адрес";
            this.Address.UseVisualStyleBackColor = true;
            // 
            // FatherName
            // 
            this.FatherName.AutoSize = true;
            this.FatherName.Checked = true;
            this.FatherName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FatherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FatherName.Location = new System.Drawing.Point(12, 122);
            this.FatherName.Name = "FatherName";
            this.FatherName.Size = new System.Drawing.Size(102, 24);
            this.FatherName.TabIndex = 32;
            this.FatherName.Text = "Отчество";
            this.FatherName.UseVisualStyleBackColor = true;
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.Checked = true;
            this.FirstName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstName.Location = new System.Drawing.Point(12, 92);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(59, 24);
            this.FirstName.TabIndex = 31;
            this.FirstName.Text = "Имя";
            this.FirstName.UseVisualStyleBackColor = true;
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Checked = true;
            this.LastName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastName.Location = new System.Drawing.Point(12, 62);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(100, 24);
            this.LastName.TabIndex = 30;
            this.LastName.Text = "Фамилия";
            this.LastName.UseVisualStyleBackColor = true;
            // 
            // GoInsertData
            // 
            this.GoInsertData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GoInsertData.Location = new System.Drawing.Point(12, 177);
            this.GoInsertData.Name = "GoInsertData";
            this.GoInsertData.Size = new System.Drawing.Size(346, 83);
            this.GoInsertData.TabIndex = 32;
            this.GoInsertData.Text = "Внести записи";
            this.GoInsertData.UseVisualStyleBackColor = true;
            this.GoInsertData.Click += new System.EventHandler(this.GoInsertData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.countRecords);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listTables);
            this.groupBox1.Controls.Add(this.listDatabases);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 146);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database  ";
            // 
            // countRecords
            // 
            this.countRecords.Enabled = false;
            this.countRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countRecords.Location = new System.Drawing.Point(156, 99);
            this.countRecords.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.countRecords.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.countRecords.Name = "countRecords";
            this.countRecords.Size = new System.Drawing.Size(184, 26);
            this.countRecords.TabIndex = 5;
            this.countRecords.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(28, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество >>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(55, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Таблица >>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "База данных >>";
            // 
            // listTables
            // 
            this.listTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listTables.Enabled = false;
            this.listTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listTables.FormattingEnabled = true;
            this.listTables.Location = new System.Drawing.Point(156, 65);
            this.listTables.Name = "listTables";
            this.listTables.Size = new System.Drawing.Size(184, 28);
            this.listTables.TabIndex = 1;
            this.listTables.SelectedIndexChanged += new System.EventHandler(this.listTables_SelectedIndexChanged);
            // 
            // listDatabases
            // 
            this.listDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listDatabases.Enabled = false;
            this.listDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listDatabases.FormattingEnabled = true;
            this.listDatabases.Location = new System.Drawing.Point(156, 31);
            this.listDatabases.Name = "listDatabases";
            this.listDatabases.Size = new System.Drawing.Size(184, 28);
            this.listDatabases.TabIndex = 0;
            this.listDatabases.SelectedIndexChanged += new System.EventHandler(this.ListDatabases_SelectedValueChanged);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.TypeColumn,
            this.AutoInsert,
            this.AdditionallyColumn});
            this.dataGrid.Location = new System.Drawing.Point(566, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(680, 456);
            this.dataGrid.TabIndex = 34;
            // 
            // NameColumn
            // 
            this.NameColumn.Frozen = true;
            this.NameColumn.HeaderText = "Название столбца";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NameColumn.Width = 250;
            // 
            // TypeColumn
            // 
            this.TypeColumn.Frozen = true;
            this.TypeColumn.HeaderText = "Тип данных";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TypeColumn.Width = 150;
            // 
            // AutoInsert
            // 
            this.AutoInsert.HeaderText = "Автозаполнение";
            this.AutoInsert.Items.AddRange(new object[] {
            "null",
            "Имя",
            "Отчество",
            "Фамилия"});
            this.AutoInsert.Name = "AutoInsert";
            this.AutoInsert.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AutoInsert.Width = 150;
            // 
            // AdditionallyColumn
            // 
            this.AdditionallyColumn.HeaderText = "Дополнительно";
            this.AdditionallyColumn.Name = "AdditionallyColumn";
            this.AdditionallyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AdditionallyColumn.Width = 125;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 480);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.checkList);
            this.Controls.Add(this.GoInsertData);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoInsertInDatabaseOnRussian";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.checkList.ResumeLayout(false);
            this.checkList.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel checkList;
        private System.Windows.Forms.CheckBox PasportNumber;
        private System.Windows.Forms.CheckBox Region;
        private System.Windows.Forms.CheckBox City;
        private System.Windows.Forms.CheckBox Country;
        private System.Windows.Forms.CheckBox Email;
        private System.Windows.Forms.CheckBox Phone;
        private System.Windows.Forms.CheckBox Password;
        private System.Windows.Forms.CheckBox Login;
        private System.Windows.Forms.CheckBox Gender;
        private System.Windows.Forms.CheckBox DateOfBirth;
        private System.Windows.Forms.CheckBox PasportSerial;
        private System.Windows.Forms.CheckBox Address;
        private System.Windows.Forms.CheckBox FatherName;
        private System.Windows.Forms.CheckBox FirstName;
        private System.Windows.Forms.CheckBox LastName;
        private System.Windows.Forms.Button GoInsertData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown countRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox listTables;
        private System.Windows.Forms.ComboBox listDatabases;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn AutoInsert;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionallyColumn;
    }
}

