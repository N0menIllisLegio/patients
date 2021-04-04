using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Patients.Data.Entities;
using Patients.Enums;
using Patients.Extensions;

namespace Patients.Forms
{
  public partial class DentalRecordsForm: Form
  {
    private static readonly Dictionary<ToothStatus, string> _toothStatusDescriptions;
    private readonly PatientTooth _patientTooth;

    static DentalRecordsForm()
    {
      _toothStatusDescriptions = new Dictionary<ToothStatus, string>();

      foreach (var toothStatus in Enum.GetValues<ToothStatus>())
      {
        _toothStatusDescriptions.Add(toothStatus, toothStatus.GetDescription());
      }
    }

    public DentalRecordsForm(PatientTooth patientTooth, List<DentalRecord> dentalRecords)
    {
      if (dentalRecords is null)
      {
        throw new ArgumentNullException(nameof(dentalRecords));
      }

      DentalRecords = dentalRecords;

      InitializeComponent();

      _patientTooth = patientTooth;
      Text = String.Format(Text, patientTooth.ToothNumber);

      RefreshDiary();
    }

    public List<DentalRecord> DentalRecords { get; private set; }

    private void AddDentalRecordButton_Click(object sender, EventArgs e)
    {
      var diaryRecordForm = new EditDentalRecordForm(_patientTooth.ToothNumber);

      if (diaryRecordForm.ShowDialog() == DialogResult.OK)
      {
        DentalRecords.Add(new DentalRecord
        {
          ID = Guid.NewGuid(),
          Cause = diaryRecordForm.Diagnosis,
          Date = diaryRecordForm.Date,
          FromStatus = diaryRecordForm.FromToothStatus,
          ToStatus = diaryRecordForm.ToToothStatus,
          Tooth = _patientTooth,
          ToothNumber = _patientTooth.ToothNumber
        });

        RefreshDiary();
      }
    }

    private void DeleteDiaryRecordButton_Click(object sender, EventArgs e)
    {
      if (dentalRecordsGridView.SelectedRows.Count > 0)
      {
        foreach (DataGridViewRow selectedRow in dentalRecordsGridView.SelectedRows)
        {
          switch (MessageBox.Show($@"Вы действительно хотите удалить запись {selectedRow.Cells[2].Value}?",
              @"Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
          {
            case DialogResult.Yes:
              var dentalRecordID = (Guid)selectedRow.Cells[0].Value;
              DentalRecords.Remove(DentalRecords.First(dentalRecord => dentalRecord.ID == dentalRecordID));
              break;

            default:
              break;
          }
        }

        RefreshDiary();
      }
      else
      {
        MessageBox.Show(@"Не выбрана ни одна запись в дневнике.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void DentalRecordsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (dentalRecordsGridView.SelectedRows.Count == 1)
      {
        var dentalRecordID = (Guid)dentalRecordsGridView.SelectedRows[0].Cells[0].Value;
        var dentalRecord = DentalRecords.FirstOrDefault(record => record.ID == dentalRecordID);

        var dentalRecordForm = new EditDentalRecordForm(dentalRecord.ToothNumber, dentalRecord.Date, dentalRecord.Cause,
          dentalRecord.FromStatus, dentalRecord.ToStatus);

        if (dentalRecordForm.ShowDialog() == DialogResult.OK)
        {
          dentalRecord.Cause = dentalRecordForm.Diagnosis;
          dentalRecord.Date = dentalRecordForm.Date;
          dentalRecord.FromStatus = dentalRecordForm.FromToothStatus;
          dentalRecord.ToStatus = dentalRecordForm.ToToothStatus;

          RefreshDiary();
        }
      }
      else
      {
        MessageBox.Show(@"Выбрана не одна запись в дневнике.",
            @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void RefreshDiary()
    {
      dentalRecordsGridView.Rows.Clear();

      foreach (var dentalRecord in DentalRecords)
      {
        dentalRecordsGridView.Rows.Add(dentalRecord.ID, dentalRecord.Date, dentalRecord.ToothNumber,
          _toothStatusDescriptions[dentalRecord.FromStatus], _toothStatusDescriptions[dentalRecord.ToStatus],
          dentalRecord.Cause);
      }
    }

    private void DentalRecordsGridViewSelectionChanged(object sender, EventArgs e)
    {
      if (dentalRecordsGridView.SelectedRows.Count > 0)
      {
        var selectedRowsEnumerator = dentalRecordsGridView.SelectedRows.GetEnumerator();
        selectedRowsEnumerator.MoveNext();
        var selectedRow = selectedRowsEnumerator.Current as DataGridViewRow;

        toolStripLabel.Text = $"[{selectedRow.Cells["Date"].Value}] Зуб №{_patientTooth.ToothNumber} " +
          $"сменил статус с: {selectedRow.Cells["FromStatus"].Value} " +
          $"на: {selectedRow.Cells["ToStatus"].Value}.";
      }
      else
      {
        toolStripLabel.Text = String.Empty;
      }
    }
  }
}
