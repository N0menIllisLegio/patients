namespace Patients
{
    partial class Patient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient));
            this.label1 = new System.Windows.Forms.Label();
            this.sur_textBox = new System.Windows.Forms.TextBox();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sec_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comp_radioButton_kartaWpf = new System.Windows.Forms.RadioButton();
            this.patient_radioButton = new System.Windows.Forms.RadioButton();
            this.paper_radioButton = new System.Windows.Forms.RadioButton();
            this.comp_radioButton_dental = new System.Windows.Forms.RadioButton();
            this.Ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия:";
            // 
            // sur_textBox
            // 
            this.sur_textBox.Location = new System.Drawing.Point(78, 17);
            this.sur_textBox.Name = "sur_textBox";
            this.sur_textBox.Size = new System.Drawing.Size(165, 20);
            this.sur_textBox.TabIndex = 1;
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(78, 64);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(165, 20);
            this.name_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя:";
            // 
            // sec_textBox
            // 
            this.sec_textBox.Location = new System.Drawing.Point(78, 112);
            this.sec_textBox.Name = "sec_textBox";
            this.sec_textBox.Size = new System.Drawing.Size(165, 20);
            this.sec_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отчество:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comp_radioButton_kartaWpf);
            this.groupBox1.Controls.Add(this.patient_radioButton);
            this.groupBox1.Controls.Add(this.paper_radioButton);
            this.groupBox1.Controls.Add(this.comp_radioButton_dental);
            this.groupBox1.Location = new System.Drawing.Point(279, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 115);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Место хранения карточки:";
            // 
            // comp_radioButton_kartaWpf
            // 
            this.comp_radioButton_kartaWpf.AutoSize = true;
            this.comp_radioButton_kartaWpf.Location = new System.Drawing.Point(6, 42);
            this.comp_radioButton_kartaWpf.Name = "comp_radioButton_kartaWpf";
            this.comp_radioButton_kartaWpf.Size = new System.Drawing.Size(137, 17);
            this.comp_radioButton_kartaWpf.TabIndex = 3;
            this.comp_radioButton_kartaWpf.TabStop = true;
            this.comp_radioButton_kartaWpf.Text = "Компьютер (KartaWpf)";
            this.comp_radioButton_kartaWpf.UseVisualStyleBackColor = true;
            // 
            // patient_radioButton
            // 
            this.patient_radioButton.AutoSize = true;
            this.patient_radioButton.Location = new System.Drawing.Point(6, 87);
            this.patient_radioButton.Name = "patient_radioButton";
            this.patient_radioButton.Size = new System.Drawing.Size(68, 17);
            this.patient_radioButton.TabIndex = 2;
            this.patient_radioButton.TabStop = true;
            this.patient_radioButton.Text = "Пациент";
            this.patient_radioButton.UseVisualStyleBackColor = true;
            // 
            // paper_radioButton
            // 
            this.paper_radioButton.AutoSize = true;
            this.paper_radioButton.Location = new System.Drawing.Point(6, 64);
            this.paper_radioButton.Name = "paper_radioButton";
            this.paper_radioButton.Size = new System.Drawing.Size(129, 17);
            this.paper_radioButton.TabIndex = 1;
            this.paper_radioButton.TabStop = true;
            this.paper_radioButton.Text = "Бумажный носитель";
            this.paper_radioButton.UseVisualStyleBackColor = true;
            // 
            // comp_radioButton_dental
            // 
            this.comp_radioButton_dental.AutoSize = true;
            this.comp_radioButton_dental.Checked = true;
            this.comp_radioButton_dental.Location = new System.Drawing.Point(6, 20);
            this.comp_radioButton_dental.Name = "comp_radioButton_dental";
            this.comp_radioButton_dental.Size = new System.Drawing.Size(123, 17);
            this.comp_radioButton_dental.TabIndex = 0;
            this.comp_radioButton_dental.TabStop = true;
            this.comp_radioButton_dental.Text = "Компьютер (Dental)";
            this.comp_radioButton_dental.UseVisualStyleBackColor = true;
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(169, 156);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 7;
            this.Ok_button.Text = "ОК";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(279, 156);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 8;
            this.cancel_button.Text = "Отмена";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // calendar
            // 
            this.calendar.BackColor = System.Drawing.SystemColors.Window;
            this.calendar.Location = new System.Drawing.Point(507, 17);
            this.calendar.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.calendar.MinDate = new System.DateTime(1900, 12, 31, 0, 0, 0, 0);
            this.calendar.Name = "calendar";
            this.calendar.ShowWeekNumbers = true;
            this.calendar.TabIndex = 9;
            // 
            // Patient
            // 
            this.AcceptButton = this.Ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(708, 203);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sec_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sur_textBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ввод данных";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sur_textBox;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sec_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton patient_radioButton;
        private System.Windows.Forms.RadioButton paper_radioButton;
        private System.Windows.Forms.RadioButton comp_radioButton_dental;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.RadioButton comp_radioButton_kartaWpf;
    }
}