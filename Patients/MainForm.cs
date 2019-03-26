using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Patients
{
    public partial class MainForm : Form
    {
        private readonly DataBaseContext _db;

        public MainForm()
        {
            InitializeComponent();
            
            try
            {
                _db = DataBaseContext.GetInstance();
                _db.Diaries.Load();
                _db.Patients.Load();
                RefreshTable(null);
            }
            catch
            {
                addButton.Enabled = false;
                deleteButton.Enabled = false;
                searchField.Enabled = false;
                patientsTable.Enabled = false;

                MessageBox.Show("Ну удалось загрузить базу данных!\nПроверьте файл базы данных PatientsDB.db в корневом каталоге.",
                    @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EditForm form = new EditForm();
           
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshTable(null);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (patientsTable.SelectedRows.Count != 0)
            {
                List<Patient> forDeletion = new List<Patient>();

                foreach (DataGridViewRow selectedRow in patientsTable.SelectedRows)
                {
                    Patient patient = _db.GetPatientById((int)selectedRow.Cells[0].Value);

                    switch (MessageBox.Show($@"Вы действительно хотите удалить {patient.Surname} {patient.Name} {patient.SecondName}?",
                        @"Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            forDeletion.Add(patient);
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

                if (forDeletion.Count > 0)
                {
                    _db.DeletePatient(forDeletion);
                    _db.SaveChanges();
                    RefreshTable(null);
                }
            }
            else
            {
                MessageBox.Show(@"Не выбрана строка.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void patientsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (patientsTable.SelectedRows.Count == 1)
            {               
                Patient patient = _db.GetPatientById((int)patientsTable.SelectedRows[0].Cells[0].Value);
                EditForm form = new EditForm(ref patient);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshTable(null);
                }
            }
            else
            {
                MessageBox.Show(@"Выбрано неверное количество строк.", 
                    @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshTable(List<Patient> patients)
        {
            patientsTable.Rows.Clear();
            
            foreach (var patient in patients ?? _db.GetAllPatients())
            {
                patientsTable.Rows.Add(patient.Id, patient.Surname, patient.Name, 
                    patient.SecondName, patient.PhoneNumber, patient.LastVisitDate.ToString("dd MMMM yyyy"),
                    patient.Place);
            }
        }

        private void searchField_TextChanged(object sender, EventArgs e)
        {
            var searchRequest = EditForm.Register(searchField.Text);
            List<Patient> searchResultList = null;

            if (searchRequest != " ")
            {
                if (SurnameRadioButton.Checked)
                {
                    searchResultList = _db.GetAllPatients()
                        .Where(patient => patient.Surname.LastIndexOf(searchRequest) == 0).ToList();
                }
                else
                {
                    searchResultList = _db.GetAllPatients()
                        .Where(patient => patient.Name.LastIndexOf(searchRequest) == 0).ToList();
                }
            }
            
            RefreshTable(searchResultList);
        }
    }
}
