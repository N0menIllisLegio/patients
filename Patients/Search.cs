using System;
using System.Data;
using System.Windows.Forms;

namespace Patients
{
    public partial class Search : Form
    {
        public Search()
        {            
            InitializeComponent();
            Data.SearchingDataTable.Rows.Clear();
            searchTable.DataSource = Data.SearchingDataTable;
            if (searchTable?.Columns["Id"] != null)
            {
                searchTable.Columns["Id"].Visible = false;
            }         
        }

        private void Reload()
        {
            Data.SearchingDataTable.Rows.Clear();
            string searchingWord = srch_textBox.Text.Trim().ToLower();

            foreach (DataRow row in Data.PatientsInfo.Rows)
            {
                string surname = row["Фамилия"].ToString().ToLower().Trim();
                if (surname.IndexOf(searchingWord, StringComparison.Ordinal) == 0)
                {
                    Data.SearchingDataTable.ImportRow(row);
                }
            }
        }

        private void srch_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            srch_textBox.Clear();
        }

        private void srch_textBox_TextChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void searchTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (searchTable.SelectedRows.Count != 0)
            {
                int id = (int)searchTable.SelectedRows[0].Cells["Id"].Value;
                Patient form = new Patient(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Reload();
                }
            }
            else
            {
                MessageBox.Show(@"Не выбрана строка.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}