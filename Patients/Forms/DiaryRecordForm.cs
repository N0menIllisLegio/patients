using System;
using System.Windows.Forms;
using Patients.Data.Entities;

namespace Patients
{
  public partial class DiaryRecordForm: Form
  {
    private readonly DiaryRecord _diaryRecord;

    public DiaryRecordForm(DiaryRecord diaryRecord)
    {
      _diaryRecord = diaryRecord;
      InitializeComponent();
      complaintTextBox.Text = diaryRecord.Diagnosis;
      dateTimePicker.Value = diaryRecord.Date;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      _diaryRecord.Date = dateTimePicker.Value;
      _diaryRecord.Diagnosis = complaintTextBox.Text;
    }
  }
}
