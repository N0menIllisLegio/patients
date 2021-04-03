
namespace Patients.Forms
{
  partial class DentalRecordsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dentalRecordsGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dentalRecordsGridView)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dentalRecordsGridView
            // 
            this.dentalRecordsGridView.AllowUserToAddRows = false;
            this.dentalRecordsGridView.AllowUserToDeleteRows = false;
            this.dentalRecordsGridView.AllowUserToResizeRows = false;
            this.dentalRecordsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dentalRecordsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dentalRecordsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Date,
            this.Number,
            this.FromStatus,
            this.ToStatus,
            this.Diagnosis});
            this.dentalRecordsGridView.Location = new System.Drawing.Point(12, 51);
            this.dentalRecordsGridView.MultiSelect = false;
            this.dentalRecordsGridView.Name = "dentalRecordsGridView";
            this.dentalRecordsGridView.ReadOnly = true;
            this.dentalRecordsGridView.RowHeadersVisible = false;
            this.dentalRecordsGridView.RowTemplate.Height = 25;
            this.dentalRecordsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dentalRecordsGridView.Size = new System.Drawing.Size(680, 298);
            this.dentalRecordsGridView.TabIndex = 0;
            this.dentalRecordsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DentalRecordsGridView_CellDoubleClick);
            this.dentalRecordsGridView.SelectionChanged += new System.EventHandler(this.DentalRecordsGridViewSelectionChanged);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Format = "dd.MM.yyyy";
            this.Date.DefaultCellStyle = dataGridViewCellStyle1;
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 57;
            // 
            // Number
            // 
            this.Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Number.HeaderText = "Зуб";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 52;
            // 
            // FromStatus
            // 
            this.FromStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FromStatus.HeaderText = "С";
            this.FromStatus.Name = "FromStatus";
            this.FromStatus.ReadOnly = true;
            this.FromStatus.Width = 40;
            // 
            // ToStatus
            // 
            this.ToStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ToStatus.HeaderText = "На";
            this.ToStatus.Name = "ToStatus";
            this.ToStatus.ReadOnly = true;
            this.ToStatus.Width = 47;
            // 
            // Diagnosis
            // 
            this.Diagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Diagnosis.HeaderText = "Диагноз, причина";
            this.Diagnosis.Name = "Diagnosis";
            this.Diagnosis.ReadOnly = true;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.DarkGreen;
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(12, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(107, 33);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddDentalRecordButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.DarkRed;
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(125, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(107, 33);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteDiaryRecordButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.exitButton.Location = new System.Drawing.Point(585, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(107, 33);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 352);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(704, 22);
            this.statusStrip.TabIndex = 5;
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // DentalRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dentalRecordsGridView);
            this.MinimumSize = new System.Drawing.Size(720, 390);
            this.Name = "DentalRecordsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дневник зуба №{0}";
            ((System.ComponentModel.ISupportInitialize)(this.dentalRecordsGridView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dentalRecordsGridView;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Button deleteButton;
    private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    private System.Windows.Forms.DataGridViewTextBoxColumn Number;
    private System.Windows.Forms.DataGridViewTextBoxColumn FromStatus;
    private System.Windows.Forms.DataGridViewTextBoxColumn ToStatus;
    private System.Windows.Forms.DataGridViewTextBoxColumn Diagnosis;
    private System.Windows.Forms.Button exitButton;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel toolStripLabel;
  }
}