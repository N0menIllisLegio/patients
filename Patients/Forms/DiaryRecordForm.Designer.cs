namespace Patients
{
    partial class DiaryRecordForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiaryRecordForm));
      this.label1 = new System.Windows.Forms.Label();
      this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.label2 = new System.Windows.Forms.Label();
      this.complaintTextBox = new System.Windows.Forms.RichTextBox();
      this.addButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(14, 29);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Дата:";
      // 
      // dateTimePicker
      // 
      this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dateTimePicker.Location = new System.Drawing.Point(80, 25);
      this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.dateTimePicker.Name = "dateTimePicker";
      this.dateTimePicker.Size = new System.Drawing.Size(263, 23);
      this.dateTimePicker.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(14, 102);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(54, 15);
      this.label2.TabIndex = 2;
      this.label2.Text = "Жалоба:";
      // 
      // complaintTextBox
      // 
      this.complaintTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.complaintTextBox.Location = new System.Drawing.Point(80, 55);
      this.complaintTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.complaintTextBox.Name = "complaintTextBox";
      this.complaintTextBox.Size = new System.Drawing.Size(263, 110);
      this.complaintTextBox.TabIndex = 3;
      this.complaintTextBox.Text = "";
      // 
      // addButton
      // 
      this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.addButton.Location = new System.Drawing.Point(121, 173);
      this.addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(88, 27);
      this.addButton.TabIndex = 4;
      this.addButton.Text = "Добавить";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(216, 173);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(88, 27);
      this.cancelButton.TabIndex = 5;
      this.cancelButton.Text = "Отмена";
      this.cancelButton.UseVisualStyleBackColor = true;
      // 
      // DiaryRecordForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(383, 215);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.addButton);
      this.Controls.Add(this.complaintTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.dateTimePicker);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(394, 254);
      this.Name = "DiaryRecordForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Новая запись в дневнике";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox complaintTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
    }
}