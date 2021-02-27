using System;
using System.Linq;
using System.Windows.Forms;
using Patients.Data.Entities;

namespace Patients
{
  public partial class TeethStatusForm: Form
  {
    private readonly Button _button;
    private readonly string _changedFrom;
    private readonly DiaryRecord _diaryRecord;

    public TeethStatusForm(Button button, DiaryRecord diaryEvent)
    {
      _button = button;
      _diaryRecord = diaryEvent;
      InitializeComponent();

      var radioBtn = teethStatusesPanel.Controls.OfType<RadioButton>()
        .FirstOrDefault(x => x.Checked);

      _changedFrom = radioBtn.Text;
    }

    public bool IsOK { get; set; }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      var toothRadioButton = teethStatusesPanel.Controls
        .OfType<RadioButton>().FirstOrDefault(x => x.Checked);

      _button.BackColor = toothRadioButton.ForeColor;

      string changedTo = toothRadioButton.Text;

      if (!changedTo.Equals(_changedFrom))
      {
        _diaryRecord.Diagnosis = $"Зуб №{_button.Name.Replace("button_", String.Empty)} " +
                               $"сменил статус с: {_changedFrom} на: {changedTo}. " +
                               $"Причина: {dataTextBox.Text}";

        _diaryRecord.Date = DateTime.Today;

        var eventForm = new DiaryRecordForm(_diaryRecord);
        if (eventForm.ShowDialog() == DialogResult.OK)
        {
          IsOK = true;
        }
      }
    }
  }
}
