using System;
using System.Data;
using System.Windows.Forms;

namespace Patients
{  
    public partial class MainForm : Form
    {
        private const string FileName = "PatientsDB.xml";

        public MainForm()
        { 
            Data.SetTables();
            Data.LoadTable(FileName);
            InitializeComponent();
            dataTable.DataSource = Data.PatientsInfo;
            if (dataTable?.Columns["Id"] != null)
            {
                dataTable.Columns["Id"].Visible = false;
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            Patient form = new Patient();
            form.ShowDialog();
            Data.PatientsInfo.AcceptChanges();
        }

        private void del_button_Click(object sender, EventArgs e)
        {
            if (dataTable.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow selectedRow in dataTable.SelectedRows)
                {
                    DataRowView boundedItem = (DataRowView)selectedRow.DataBoundItem;
               
                    switch (MessageBox.Show($@"Вы действительно хотите удалить {boundedItem["Фамилия"]} {boundedItem["Имя"]} {boundedItem["Отчество"]}?",
                        @"Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            Data.PatientsInfo.Rows.Remove(boundedItem.Row);
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.Cancel:
                            return;
                        default:
                            MessageBox.Show(@"Для выхода нажмите отмена");
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Не выбрана строка.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            if (dataTable.SelectedRows.Count != 0)
            {
                int id = (int)dataTable.SelectedRows[0].Cells["Id"].Value;
                Patient form = new Patient(id);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"Не выбрана строка.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            if (Data.PatientsInfo.Rows.Count != 0)
            {
                Search form = new Search();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"База пуста.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.SaveTable(FileName);
        }
    }
}
