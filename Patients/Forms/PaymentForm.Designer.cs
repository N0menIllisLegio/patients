
namespace Patients.Forms
{
  partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.paymentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paymentAmountNumeric = new System.Windows.Forms.NumericUpDown();
            this.AddPaymentButton = new System.Windows.Forms.Button();
            this.CancelPaymentButton = new System.Windows.Forms.Button();
            this.diagnosisRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paymentAmountNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentDatePicker
            // 
            this.paymentDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.paymentDatePicker.Location = new System.Drawing.Point(79, 12);
            this.paymentDatePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.paymentDatePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.paymentDatePicker.Name = "paymentDatePicker";
            this.paymentDatePicker.Size = new System.Drawing.Size(231, 23);
            this.paymentDatePicker.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Дата:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "У.е.";
            // 
            // paymentAmountNumeric
            // 
            this.paymentAmountNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentAmountNumeric.DecimalPlaces = 2;
            this.paymentAmountNumeric.Location = new System.Drawing.Point(79, 38);
            this.paymentAmountNumeric.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.paymentAmountNumeric.Name = "paymentAmountNumeric";
            this.paymentAmountNumeric.Size = new System.Drawing.Size(231, 23);
            this.paymentAmountNumeric.TabIndex = 17;
            this.paymentAmountNumeric.ThousandsSeparator = true;
            // 
            // AddPaymentButton
            // 
            this.AddPaymentButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddPaymentButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddPaymentButton.Location = new System.Drawing.Point(80, 189);
            this.AddPaymentButton.Name = "AddPaymentButton";
            this.AddPaymentButton.Size = new System.Drawing.Size(75, 23);
            this.AddPaymentButton.TabIndex = 18;
            this.AddPaymentButton.Text = "Добавить";
            this.AddPaymentButton.UseVisualStyleBackColor = true;
            this.AddPaymentButton.Click += new System.EventHandler(this.AddPaymentButton_Click);
            // 
            // CancelPaymentButton
            // 
            this.CancelPaymentButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelPaymentButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelPaymentButton.Location = new System.Drawing.Point(161, 189);
            this.CancelPaymentButton.Name = "CancelPaymentButton";
            this.CancelPaymentButton.Size = new System.Drawing.Size(75, 23);
            this.CancelPaymentButton.TabIndex = 19;
            this.CancelPaymentButton.Text = "Отмена";
            this.CancelPaymentButton.UseVisualStyleBackColor = true;
            // 
            // diagnosisRichTextBox
            // 
            this.diagnosisRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagnosisRichTextBox.Location = new System.Drawing.Point(79, 64);
            this.diagnosisRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.diagnosisRichTextBox.Name = "diagnosisRichTextBox";
            this.diagnosisRichTextBox.Size = new System.Drawing.Size(231, 120);
            this.diagnosisRichTextBox.TabIndex = 20;
            this.diagnosisRichTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Диагноз:";
            // 
            // PaymentForm
            // 
            this.AcceptButton = this.AddPaymentButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelPaymentButton;
            this.ClientSize = new System.Drawing.Size(334, 224);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.diagnosisRichTextBox);
            this.Controls.Add(this.CancelPaymentButton);
            this.Controls.Add(this.AddPaymentButton);
            this.Controls.Add(this.paymentAmountNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paymentDatePicker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 240);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оплата";
            ((System.ComponentModel.ISupportInitialize)(this.paymentAmountNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DateTimePicker paymentDatePicker;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown paymentAmountNumeric;
    private System.Windows.Forms.Button AddPaymentButton;
    private System.Windows.Forms.Button CancelPaymentButton;
    private System.Windows.Forms.RichTextBox diagnosisRichTextBox;
    private System.Windows.Forms.Label label3;
  }
}