namespace Patients
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.srch_textBox = new System.Windows.Forms.TextBox();
            this.searchTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.searchTable)).BeginInit();
            this.SuspendLayout();
            // 
            // srch_textBox
            // 
            this.srch_textBox.Location = new System.Drawing.Point(12, 12);
            this.srch_textBox.Name = "srch_textBox";
            this.srch_textBox.Size = new System.Drawing.Size(194, 20);
            this.srch_textBox.TabIndex = 0;
            this.srch_textBox.Text = "Введите фамилию";
            this.srch_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.srch_textBox_MouseClick);
            this.srch_textBox.TextChanged += new System.EventHandler(this.srch_textBox_TextChanged);
            // 
            // searchTable
            // 
            this.searchTable.AllowUserToAddRows = false;
            this.searchTable.AllowUserToDeleteRows = false;
            this.searchTable.AllowUserToResizeColumns = false;
            this.searchTable.AllowUserToResizeRows = false;
            this.searchTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchTable.BackgroundColor = System.Drawing.Color.White;
            this.searchTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.searchTable.ColumnHeadersHeight = 40;
            this.searchTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.searchTable.EnableHeadersVisualStyles = false;
            this.searchTable.Location = new System.Drawing.Point(12, 38);
            this.searchTable.Name = "searchTable";
            this.searchTable.ReadOnly = true;
            this.searchTable.RowHeadersVisible = false;
            this.searchTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.searchTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchTable.Size = new System.Drawing.Size(775, 424);
            this.searchTable.TabIndex = 2;
            this.searchTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchTable_CellDoubleClick);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.searchTable);
            this.Controls.Add(this.srch_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск";
            ((System.ComponentModel.ISupportInitialize)(this.searchTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox srch_textBox;
        private System.Windows.Forms.DataGridView searchTable;
    }
}