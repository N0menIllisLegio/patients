namespace Patients
{
    partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.patientsTable = new System.Windows.Forms.DataGridView();
      this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.secName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.place = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.addButton = new System.Windows.Forms.Button();
      this.deleteButton = new System.Windows.Forms.Button();
      this.searchField = new System.Windows.Forms.TextBox();
      this.SurnameRadioButton = new System.Windows.Forms.RadioButton();
      this.NameRadioButton = new System.Windows.Forms.RadioButton();
      ((System.ComponentModel.ISupportInitialize)(this.patientsTable)).BeginInit();
      this.SuspendLayout();
      // 
      // patientsTable
      // 
      this.patientsTable.AllowUserToAddRows = false;
      this.patientsTable.AllowUserToDeleteRows = false;
      this.patientsTable.AllowUserToResizeRows = false;
      this.patientsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.patientsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.patientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.patientsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.dataGridViewTextBoxColumn1,
            this.surname,
            this.name,
            this.secName,
            this.phone,
            this.date,
            this.place});
      this.patientsTable.Location = new System.Drawing.Point(14, 50);
      this.patientsTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.patientsTable.Name = "patientsTable";
      this.patientsTable.ReadOnly = true;
      this.patientsTable.RowHeadersVisible = false;
      this.patientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.patientsTable.Size = new System.Drawing.Size(861, 699);
      this.patientsTable.TabIndex = 0;
      this.patientsTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PatientsTable_CellDoubleClick);
      // 
      // ID
      // 
      this.ID.HeaderText = "ID";
      this.ID.Name = "ID";
      this.ID.ReadOnly = true;
      this.ID.Visible = false;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.dataGridViewTextBoxColumn1.HeaderText = "№";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn1.Width = 45;
      // 
      // surname
      // 
      this.surname.HeaderText = "Фамилия";
      this.surname.Name = "surname";
      this.surname.ReadOnly = true;
      // 
      // name
      // 
      this.name.HeaderText = "Имя";
      this.name.Name = "name";
      this.name.ReadOnly = true;
      // 
      // secName
      // 
      this.secName.HeaderText = "Отчество";
      this.secName.Name = "secName";
      this.secName.ReadOnly = true;
      // 
      // phone
      // 
      this.phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.phone.HeaderText = "Телефон";
      this.phone.Name = "phone";
      this.phone.ReadOnly = true;
      // 
      // date
      // 
      this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.date.HeaderText = "Дата посещения";
      this.date.Name = "date";
      this.date.ReadOnly = true;
      this.date.Width = 113;
      // 
      // place
      // 
      this.place.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.place.HeaderText = "Место хранения";
      this.place.Name = "place";
      this.place.ReadOnly = true;
      this.place.Width = 112;
      // 
      // addButton
      // 
      this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.addButton.BackColor = System.Drawing.Color.DarkGreen;
      this.addButton.ForeColor = System.Drawing.Color.White;
      this.addButton.Location = new System.Drawing.Point(693, 14);
      this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(88, 29);
      this.addButton.TabIndex = 1;
      this.addButton.Text = "Добавить";
      this.addButton.UseVisualStyleBackColor = false;
      this.addButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // deleteButton
      // 
      this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.deleteButton.BackColor = System.Drawing.Color.DarkRed;
      this.deleteButton.ForeColor = System.Drawing.Color.White;
      this.deleteButton.Location = new System.Drawing.Point(788, 14);
      this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.deleteButton.Name = "deleteButton";
      this.deleteButton.Size = new System.Drawing.Size(88, 29);
      this.deleteButton.TabIndex = 2;
      this.deleteButton.Text = "Удалить";
      this.deleteButton.UseVisualStyleBackColor = false;
      this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
      // 
      // searchField
      // 
      this.searchField.Location = new System.Drawing.Point(14, 14);
      this.searchField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.searchField.Name = "searchField";
      this.searchField.Size = new System.Drawing.Size(238, 23);
      this.searchField.TabIndex = 3;
      this.searchField.TextChanged += new System.EventHandler(this.SearchField_TextChanged);
      // 
      // SurnameRadioButton
      // 
      this.SurnameRadioButton.AutoSize = true;
      this.SurnameRadioButton.Checked = true;
      this.SurnameRadioButton.Location = new System.Drawing.Point(260, 15);
      this.SurnameRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.SurnameRadioButton.Name = "SurnameRadioButton";
      this.SurnameRadioButton.Size = new System.Drawing.Size(76, 19);
      this.SurnameRadioButton.TabIndex = 4;
      this.SurnameRadioButton.TabStop = true;
      this.SurnameRadioButton.Text = "Фамилия";
      this.SurnameRadioButton.UseVisualStyleBackColor = true;
      // 
      // NameRadioButton
      // 
      this.NameRadioButton.AutoSize = true;
      this.NameRadioButton.Location = new System.Drawing.Point(368, 15);
      this.NameRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.NameRadioButton.Name = "NameRadioButton";
      this.NameRadioButton.Size = new System.Drawing.Size(49, 19);
      this.NameRadioButton.TabIndex = 5;
      this.NameRadioButton.Text = "Имя";
      this.NameRadioButton.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(889, 763);
      this.Controls.Add(this.NameRadioButton);
      this.Controls.Add(this.SurnameRadioButton);
      this.Controls.Add(this.searchField);
      this.Controls.Add(this.deleteButton);
      this.Controls.Add(this.addButton);
      this.Controls.Add(this.patientsTable);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MinimumSize = new System.Drawing.Size(814, 571);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Пациенты";
      ((System.ComponentModel.ISupportInitialize)(this.patientsTable)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView patientsTable;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox searchField;
        private System.Windows.Forms.RadioButton SurnameRadioButton;
        private System.Windows.Forms.RadioButton NameRadioButton;
    private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn surname;
    private System.Windows.Forms.DataGridViewTextBoxColumn name;
    private System.Windows.Forms.DataGridViewTextBoxColumn secName;
    private System.Windows.Forms.DataGridViewTextBoxColumn phone;
    private System.Windows.Forms.DataGridViewTextBoxColumn date;
    private System.Windows.Forms.DataGridViewTextBoxColumn place;
  }
}

