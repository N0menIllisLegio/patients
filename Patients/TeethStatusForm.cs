using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Patients
{
    public partial class TeethStatusForm : Form
    {
        public bool isOK;

        private Button button;
        private Diary diaryEvent;
        private string changedFrom;

        private Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>
        {
            { "radioButton1", Color.Green },
            { "radioButton2", Color.Orange },
            { "radioButton3", Color.Blue },
            { "radioButton4", Color.Black },
            { "radioButton5", Color.Red },
            { "radioButton6", Color.Gold },
            { "radioButton7", Color.White }
        };

        public TeethStatusForm(ref Button button, ref Diary diaryEvent)
        {
            this.button = button;
            this.diaryEvent = diaryEvent;
            InitializeComponent();

            RadioButton radioBtn = Controls
                .OfType<RadioButton>().FirstOrDefault(x => x.Checked);
            changedFrom = radioBtn?.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            RadioButton radioBtn = Controls
                .OfType<RadioButton>().FirstOrDefault(x => x.Checked);
            button.BackColor = colorDictionary[radioBtn?.Name ?? "radioButton1"];

            string changedTo = radioBtn?.Text;

            if (!changedTo.Equals(changedFrom))
            {
                diaryEvent.Diagnosis = $"Зуб №{ button.Name.Replace("button_", "") } " +
                                       $"сменил статус с: {changedFrom} на: {changedTo}. " +
                                       $"Причина: {dataTextBox.Text}";
                diaryEvent.Date = DateTime.Today;
                
                DiaryEventForm eventForm = new DiaryEventForm(ref diaryEvent);
                if (eventForm.ShowDialog() == DialogResult.OK)
                {
                    isOK = true;
                }
            }
        }
    }
}
