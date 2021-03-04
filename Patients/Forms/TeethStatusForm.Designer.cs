namespace Patients.Forms
{
    partial class TeethStatusForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeethStatusForm));
      this.healthyTooth = new System.Windows.Forms.RadioButton();
      this.cariesTooth = new System.Windows.Forms.RadioButton();
      this.sealTooth = new System.Windows.Forms.RadioButton();
      this.removedTooth = new System.Windows.Forms.RadioButton();
      this.rootTooth = new System.Windows.Forms.RadioButton();
      this.artificialCrownTooth = new System.Windows.Forms.RadioButton();
      this.artificialTooth = new System.Windows.Forms.RadioButton();
      this.dataTextBox = new System.Windows.Forms.RichTextBox();
      this.saveButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.teethStatusesPanel = new System.Windows.Forms.Panel();
      this.teethStatusesPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // healthyTooth
      // 
      this.healthyTooth.AutoSize = true;
      this.healthyTooth.Checked = true;
      this.healthyTooth.ForeColor = System.Drawing.Color.Green;
      this.healthyTooth.Location = new System.Drawing.Point(14, 7);
      this.healthyTooth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.healthyTooth.Name = "healthyTooth";
      this.healthyTooth.Size = new System.Drawing.Size(102, 19);
      this.healthyTooth.TabIndex = 0;
      this.healthyTooth.TabStop = true;
      this.healthyTooth.Text = "Здоровый зуб";
      this.healthyTooth.UseVisualStyleBackColor = true;
      // 
      // cariesTooth
      // 
      this.cariesTooth.AutoSize = true;
      this.cariesTooth.ForeColor = System.Drawing.Color.Peru;
      this.cariesTooth.Location = new System.Drawing.Point(14, 32);
      this.cariesTooth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.cariesTooth.Name = "cariesTooth";
      this.cariesTooth.Size = new System.Drawing.Size(186, 19);
      this.cariesTooth.TabIndex = 1;
      this.cariesTooth.TabStop = true;
      this.cariesTooth.Text = "Кариес, осложнения кариеса";
      this.cariesTooth.UseVisualStyleBackColor = true;
      // 
      // sealTooth
      // 
      this.sealTooth.AutoSize = true;
      this.sealTooth.ForeColor = System.Drawing.Color.Blue;
      this.sealTooth.Location = new System.Drawing.Point(14, 57);
      this.sealTooth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.sealTooth.Name = "sealTooth";
      this.sealTooth.Size = new System.Drawing.Size(70, 19);
      this.sealTooth.TabIndex = 2;
      this.sealTooth.TabStop = true;
      this.sealTooth.Text = "Пломба";
      this.sealTooth.UseVisualStyleBackColor = true;
      // 
      // removedTooth
      // 
      this.removedTooth.AutoSize = true;
      this.removedTooth.ForeColor = System.Drawing.Color.Black;
      this.removedTooth.Location = new System.Drawing.Point(14, 82);
      this.removedTooth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.removedTooth.Name = "removedTooth";
      this.removedTooth.Size = new System.Drawing.Size(111, 19);
      this.removedTooth.TabIndex = 3;
      this.removedTooth.TabStop = true;
      this.removedTooth.Text = "Зуб отсутствует";
      this.removedTooth.UseVisualStyleBackColor = true;
      // 
      // rootTooth
      // 
      this.rootTooth.AutoSize = true;
      this.rootTooth.ForeColor = System.Drawing.Color.Red;
      this.rootTooth.Location = new System.Drawing.Point(14, 108);
      this.rootTooth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.rootTooth.Name = "rootTooth";
      this.rootTooth.Size = new System.Drawing.Size(65, 19);
      this.rootTooth.TabIndex = 4;
      this.rootTooth.TabStop = true;
      this.rootTooth.Text = "Корень";
      this.rootTooth.UseVisualStyleBackColor = true;
      // 
      // artificialCrownTooth
      // 
      this.artificialCrownTooth.AutoSize = true;
      this.artificialCrownTooth.ForeColor = System.Drawing.Color.Gold;
      this.artificialCrownTooth.Location = new System.Drawing.Point(14, 133);
      this.artificialCrownTooth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.artificialCrownTooth.Name = "artificialCrownTooth";
      this.artificialCrownTooth.Size = new System.Drawing.Size(156, 19);
      this.artificialCrownTooth.TabIndex = 5;
      this.artificialCrownTooth.TabStop = true;
      this.artificialCrownTooth.Text = "Искусственная коронка";
      this.artificialCrownTooth.UseVisualStyleBackColor = true;
      // 
      // artificialTooth
      // 
      this.artificialTooth.AutoSize = true;
      this.artificialTooth.ForeColor = System.Drawing.Color.White;
      this.artificialTooth.Location = new System.Drawing.Point(14, 158);
      this.artificialTooth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.artificialTooth.Name = "artificialTooth";
      this.artificialTooth.Size = new System.Drawing.Size(132, 19);
      this.artificialTooth.TabIndex = 6;
      this.artificialTooth.TabStop = true;
      this.artificialTooth.Text = "Искусственный зуб";
      this.artificialTooth.UseVisualStyleBackColor = true;
      // 
      // dataTextBox
      // 
      this.dataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataTextBox.Location = new System.Drawing.Point(244, 14);
      this.dataTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.dataTextBox.Name = "dataTextBox";
      this.dataTextBox.Size = new System.Drawing.Size(322, 219);
      this.dataTextBox.TabIndex = 7;
      this.dataTextBox.Text = "";
      // 
      // saveButton
      // 
      this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.saveButton.Location = new System.Drawing.Point(149, 239);
      this.saveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(88, 27);
      this.saveButton.TabIndex = 8;
      this.saveButton.Text = "Сохранить";
      this.saveButton.UseVisualStyleBackColor = true;
      this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(244, 239);
      this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(88, 27);
      this.cancelButton.TabIndex = 9;
      this.cancelButton.Text = "Отмена";
      this.cancelButton.UseVisualStyleBackColor = true;
      // 
      // teethStatusesPanel
      // 
      this.teethStatusesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.teethStatusesPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.teethStatusesPanel.Controls.Add(this.cariesTooth);
      this.teethStatusesPanel.Controls.Add(this.healthyTooth);
      this.teethStatusesPanel.Controls.Add(this.sealTooth);
      this.teethStatusesPanel.Controls.Add(this.artificialCrownTooth);
      this.teethStatusesPanel.Controls.Add(this.artificialTooth);
      this.teethStatusesPanel.Controls.Add(this.removedTooth);
      this.teethStatusesPanel.Controls.Add(this.rootTooth);
      this.teethStatusesPanel.Location = new System.Drawing.Point(12, 14);
      this.teethStatusesPanel.Name = "teethStatusesPanel";
      this.teethStatusesPanel.Size = new System.Drawing.Size(225, 219);
      this.teethStatusesPanel.TabIndex = 10;
      // 
      // TeethStatusForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(583, 278);
      this.ControlBox = false;
      this.Controls.Add(this.teethStatusesPanel);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.saveButton);
      this.Controls.Add(this.dataTextBox);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(598, 294);
      this.Name = "TeethStatusForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Статус локалис";
      this.teethStatusesPanel.ResumeLayout(false);
      this.teethStatusesPanel.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton healthyTooth;
        private System.Windows.Forms.RadioButton cariesTooth;
        private System.Windows.Forms.RadioButton sealTooth;
        private System.Windows.Forms.RadioButton removedTooth;
        private System.Windows.Forms.RadioButton rootTooth;
        private System.Windows.Forms.RadioButton artificialCrownTooth;
        private System.Windows.Forms.RadioButton artificialTooth;
        private System.Windows.Forms.RichTextBox dataTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Panel teethStatusesPanel;
  }
}