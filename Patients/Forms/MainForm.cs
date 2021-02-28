using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Patients.Extensions;
using Patients.Services.Interfaces;

namespace Patients
{
  public partial class MainForm: Form
  {
    private readonly IPatientsService _patientsService;

    public MainForm()
    {
      _patientsService = Program.ServiceProvider.GetService<IPatientsService>();

      InitializeComponent();

      _ = RefreshTable();
    }

    private async void AddButton_Click(object sender, EventArgs e)
    {
      if (new EditForm().ShowDialog() == DialogResult.OK)
      {
        await RefreshTable();
      }
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
      if (patientsTable.SelectedRows.Count != 0)
      {
        var forDeletion = new List<Guid>();

        foreach (DataGridViewRow selectedRow in patientsTable.SelectedRows)
        {
          string surname = selectedRow.Cells[2].Value as string;
          string name = selectedRow.Cells[3].Value as string;
          string secondName = selectedRow.Cells[4].Value as string;

          switch (MessageBox.Show($@"Вы действительно хотите удалить {surname} {name} {secondName}?",
              @"Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
          {
            case DialogResult.Yes:
              forDeletion.Add((Guid)selectedRow.Cells[0].Value);
              break;

            case DialogResult.Cancel:
              return;

            default:
              break;
          }
        }

        if (forDeletion.Count > 0)
        {
          await _patientsService.DeletePatients(forDeletion);
          await RefreshTable();
        }
      }
      else
      {
        MessageBox.Show(@"Не выбран пациент.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async void PatientsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (patientsTable.SelectedRows.Count == 1)
      {
        var patientID = (Guid)patientsTable.SelectedRows[0].Cells[0].Value;
        var patient = await _patientsService.GetPatientAsync(patientID);

        if (new EditForm(patient).ShowDialog() == DialogResult.OK)
        {
          await RefreshTable();
        }
      }
      else
      {
        MessageBox.Show(@"Выбран более чем один пациент.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async Task RefreshTable(string searchRequest = null)
    {
      patientsTable.Rows.Clear();
      int rowNumber = 0;

      var patients = String.IsNullOrEmpty(searchRequest)
        ? await _patientsService.GetPatientsAsync()
        : SurnameRadioButton.Checked
          ? await _patientsService.SearchPatientsBySurname(searchRequest)
          : await _patientsService.SearchPatientsByName(searchRequest);

      foreach (var patient in patients)
      {
        patientsTable.Rows.Add(patient.ID, ++rowNumber,
          patient.Surname, patient.Name, patient.SecondName, patient.PhoneNumber,
          patient.LastVisitDate.ToString("dd MMMM yyyy"), patient.Storage.GetDescription());
      }
    }

    private async void SearchField_TextChanged(object sender, EventArgs e)
    {
      string searchRequest = searchField.Text.TrimLowerCapitalizeFirstLetter();
      await RefreshTable(searchRequest);
    }
  }
}
