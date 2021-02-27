﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Patients.Data;
using Patients.Data.Entities;

namespace Patients
{
  public partial class MainForm: Form
  {
    private readonly AppDbContext _db;

    public MainForm()
    {
      _db = Program.ServiceProvider.GetService<AppDbContext>();

      InitializeComponent();

      RefreshTable();
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      var form = new EditForm();

      if (form.ShowDialog() == DialogResult.OK)
      {
        RefreshTable();
      }
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
      if (patientsTable.SelectedRows.Count != 0)
      {
        var forDeletion = new List<Patient>();

        foreach (DataGridViewRow selectedRow in patientsTable.SelectedRows)
        {
          var patient = _db.GetPatientById((Guid)selectedRow.Cells[0].Value);

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
          RefreshTable();
        }
      }
      else
      {
        MessageBox.Show(@"Не выбран пациент.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void PatientsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (patientsTable.SelectedRows.Count == 1)
      {
        var patient = _db.GetPatientById((Guid)patientsTable.SelectedRows[0].Cells[0].Value);
        var form = new EditForm(patient);

        if (form.ShowDialog() == DialogResult.OK)
        {
          RefreshTable();
        }
      }
      else
      {
        MessageBox.Show(@"Выбран более чем один пациент.",
            @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void RefreshTable(List<Patient> patients = null)
    {
      patientsTable.Rows.Clear();
      int rowNumber = 0;

      foreach (var patient in patients ?? _db.GetAllPatients())
      {
        patientsTable.Rows.Add(patient.ID, ++rowNumber, patient.Surname, patient.Name,
            patient.SecondName, patient.PhoneNumber,
            patient.LastVisitDate.ToString("dd MMMM yyyy"),
            patient.Storage);
      }
    }

    private void SearchField_TextChanged(object sender, EventArgs e)
    {
      string searchRequest = EditForm.Register(searchField.Text);
      List<Patient> searchResultList = null;

      if (searchRequest != " ")
      {
        searchResultList = SurnameRadioButton.Checked
          ? _db.GetAllPatients()
              .Where(patient => patient.Surname.LastIndexOf(searchRequest) == 0).ToList()
          : _db.GetAllPatients()
              .Where(patient => patient.Name.LastIndexOf(searchRequest) == 0).ToList();
      }

      RefreshTable(searchResultList);
    }
  }
}
