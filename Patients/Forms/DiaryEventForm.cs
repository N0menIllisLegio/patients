using System;
using System.Windows.Forms;
using Patients.Data.Entities;

namespace Patients
{
  public partial class DiaryEventForm: Form
  {
    private readonly Diary _diaryEvent;

    public DiaryEventForm()
    {
      InitializeComponent();
    }

    public DiaryEventForm(ref Diary diaryEvent)
    {
      _diaryEvent = diaryEvent;
      InitializeComponent();
      complaintTextBox.Text = diaryEvent.Diagnosis;
      dateTimePicker.Value = diaryEvent.Date;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      _diaryEvent.Date = dateTimePicker.Value;
      _diaryEvent.Diagnosis = complaintTextBox.Text;
    }
  }
}
