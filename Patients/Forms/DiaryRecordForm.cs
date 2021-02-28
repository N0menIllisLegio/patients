using System;
using System.Windows.Forms;

namespace Patients
{
  public partial class DiaryRecordForm: Form
  {
    public DiaryRecordForm()
    {
      InitializeComponent();
    }

    public DiaryRecordForm(DateTime date, string diagnosis)
      : this()
    {
      complaintTextBox.Text = diagnosis;
      dateTimePicker.Value = date;
    }

    public string Diagnosis { get; set; }

    public DateTime Date { get; set; }

    private void AddButton_Click(object sender, EventArgs e)
    {
      Date = dateTimePicker.Value;
      Diagnosis = complaintTextBox.Text;
    }
  }
}
