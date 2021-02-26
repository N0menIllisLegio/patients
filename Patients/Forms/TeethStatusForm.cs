using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Patients.Data.Data.Entities;

namespace Patients
{
  public partial class TeethStatusForm: Form
  {
    private readonly Button _button;
    private readonly string _changedFrom;

    private readonly Dictionary<string, Color> _colorDictionary = new Dictionary<string, Color>
    {
      { "radioButton1", Color.Green },
      { "radioButton2", Color.Orange },
      { "radioButton3", Color.Blue },
      { "radioButton4", Color.Black },
      { "radioButton5", Color.Red },
      { "radioButton6", Color.Gold },
      { "radioButton7", Color.White }
    };

    private Diary _diaryEvent;

    public TeethStatusForm(ref Button button, ref Diary diaryEvent)
    {
      _button = button;
      _diaryEvent = diaryEvent;
      InitializeComponent();

      var radioBtn = Controls
          .OfType<RadioButton>().FirstOrDefault(x => x.Checked);
      _changedFrom = radioBtn?.Text;
    }

    public bool IsOK { get; set; }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      var radioBtn = Controls
          .OfType<RadioButton>().FirstOrDefault(x => x.Checked);
      _button.BackColor = _colorDictionary[radioBtn?.Name ?? "radioButton1"];

      string changedTo = radioBtn?.Text;

      if (!changedTo.Equals(_changedFrom))
      {
        _diaryEvent.Diagnosis = $"Зуб №{_button.Name.Replace("button_", String.Empty)} " +
                               $"сменил статус с: {_changedFrom} на: {changedTo}. " +
                               $"Причина: {dataTextBox.Text}";

        _diaryEvent.Date = DateTime.Today;

        var eventForm = new DiaryEventForm(ref _diaryEvent);
        if (eventForm.ShowDialog() == DialogResult.OK)
        {
          IsOK = true;
        }
      }
    }
  }
}
