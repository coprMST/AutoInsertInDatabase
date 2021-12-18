
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
            this.goInsertData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.countRecords = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listTables = new System.Windows.Forms.ComboBox();
            this.listDatabases = new System.Windows.Forms.ComboBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.genderUnset = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.genderWoman = new System.Windows.Forms.RadioButton();
            this.genderMan = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.insertInAll = new System.Windows.Forms.RadioButton();
            this.insertInCB = new System.Windows.Forms.RadioButton();
            this.insertInDB = new System.Windows.Forms.RadioButton();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutoInsert = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AdditionallyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // goInsertData
            // 
            this.goInsertData.Enabled = false;
            this.goInsertData.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goInsertData.Location = new System.Drawing.Point(19, 327);
            this.goInsertData.Name = "goInsertData";
            this.goInsertData.Size = new System.Drawing.Size(346, 83);
            this.goInsertData.TabIndex = 32;
            this.goInsertData.Text = "START";
            this.goInsertData.UseVisualStyleBackColor = true;
            this.goInsertData.Click += new System.EventHandler(this.GoInsertData_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
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
            10,
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
            this.listDatabases.SelectedIndexChanged += new System.EventHandler(this.listDatabases_SelectedIndexChanged);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.TypeColumn,
            this.AutoInsert,
            this.AdditionallyColumn});
            this.dataGrid.Enabled = false;
            this.dataGrid.Location = new System.Drawing.Point(393, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(678, 398);
            this.dataGrid.TabIndex = 34;
            // 
            // genderUnset
            // 
            this.genderUnset.AutoSize = true;
            this.genderUnset.Checked = true;
            this.genderUnset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genderUnset.Location = new System.Drawing.Point(12, 25);
            this.genderUnset.Name = "genderUnset";
            this.genderUnset.Size = new System.Drawing.Size(78, 24);
            this.genderUnset.TabIndex = 35;
            this.genderUnset.TabStop = true;
            this.genderUnset.Text = "Любой";
            this.genderUnset.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.genderWoman);
            this.groupBox2.Controls.Add(this.genderUnset);
            this.groupBox2.Controls.Add(this.genderMan);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(19, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 61);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пол   ";
            // 
            // genderWoman
            // 
            this.genderWoman.AutoSize = true;
            this.genderWoman.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genderWoman.Location = new System.Drawing.Point(242, 25);
            this.genderWoman.Name = "genderWoman";
            this.genderWoman.Size = new System.Drawing.Size(92, 24);
            this.genderWoman.TabIndex = 37;
            this.genderWoman.Text = "Женский";
            this.genderWoman.UseVisualStyleBackColor = true;
            // 
            // genderMan
            // 
            this.genderMan.AutoSize = true;
            this.genderMan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genderMan.Location = new System.Drawing.Point(119, 25);
            this.genderMan.Name = "genderMan";
            this.genderMan.Size = new System.Drawing.Size(92, 24);
            this.genderMan.TabIndex = 36;
            this.genderMan.Text = "Мужской";
            this.genderMan.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.insertInAll);
            this.groupBox4.Controls.Add(this.insertInCB);
            this.groupBox4.Controls.Add(this.insertInDB);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(19, 231);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(346, 90);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вставка данных   ";
            // 
            // insertInAll
            // 
            this.insertInAll.AutoSize = true;
            this.insertInAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insertInAll.Location = new System.Drawing.Point(97, 55);
            this.insertInAll.Name = "insertInAll";
            this.insertInAll.Size = new System.Drawing.Size(133, 24);
            this.insertInAll.TabIndex = 37;
            this.insertInAll.Text = "Оба варианта";
            this.insertInAll.UseVisualStyleBackColor = true;
            // 
            // insertInCB
            // 
            this.insertInCB.AutoSize = true;
            this.insertInCB.Checked = true;
            this.insertInCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insertInCB.Location = new System.Drawing.Point(189, 25);
            this.insertInCB.Name = "insertInCB";
            this.insertInCB.Size = new System.Drawing.Size(151, 24);
            this.insertInCB.TabIndex = 36;
            this.insertInCB.TabStop = true;
            this.insertInCB.Text = "В буфер обмена";
            this.insertInCB.UseVisualStyleBackColor = true;
            // 
            // insertInDB
            // 
            this.insertInDB.AutoSize = true;
            this.insertInDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insertInDB.Location = new System.Drawing.Point(12, 25);
            this.insertInDB.Name = "insertInDB";
            this.insertInDB.Size = new System.Drawing.Size(135, 24);
            this.insertInDB.TabIndex = 35;
            this.insertInDB.Text = "В базу данных";
            this.insertInDB.UseVisualStyleBackColor = true;
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
            "my insert",
            "Логин",
            "Пароль",
            "Фамилия",
            "Имя",
            "Отчество",
            "Дата рождения",
            "Пол (в первую букву)",
            "Пол (полностью)",
            "Номер телефона",
            "Электронная почта",
            "Домашний адрес",
            "Код паспорта",
            "Серия паспорта",
            "Номер паспорта",
            "Серия и номер паспорта",
            "Кем выдан",
            "Дата выдачи паспорта",
            "Страна",
            "Регион",
            "Город",
            "Специальность",
            "Название специальности",
            "Название ОУ"});
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
            this.ClientSize = new System.Drawing.Size(1089, 432);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.goInsertData);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoInsertInDatabase v1.2";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button goInsertData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown countRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox listTables;
        private System.Windows.Forms.ComboBox listDatabases;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.RadioButton genderUnset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton genderWoman;
        private System.Windows.Forms.RadioButton genderMan;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton insertInAll;
        private System.Windows.Forms.RadioButton insertInCB;
        private System.Windows.Forms.RadioButton insertInDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn AutoInsert;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionallyColumn;
    }
}

