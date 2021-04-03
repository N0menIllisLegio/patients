using System;
using System.Linq;
using System.Windows.Forms;
using Patients.Enums;
using Patients.Extensions;

namespace Patients.Forms
{
  public partial class EditDentalRecordForm: Form
  {
    private static readonly string[] _toothStatuses;

    static EditDentalRecordForm()
    {
      _toothStatuses = Enum.GetValues<ToothStatus>()
        .Select(toothStatuses => toothStatuses.GetDescription()).ToArray();
    }

    public EditDentalRecordForm(int toothNumber)
    {
      InitializeComponent();

      headerLabel.Text = String.Format(headerLabel.Text, toothNumber);
      fromToothStatusComboBox.Items.AddRange(_toothStatuses);
      toToothStatusComboBox.Items.AddRange(_toothStatuses);

      fromToothStatusComboBox.SelectedIndex = 0;
      toToothStatusComboBox.SelectedIndex = 0;
    }

    public EditDentalRecordForm(int toothNumber, DateTime date, string diagnosis,
      ToothStatus fromToothStatus, ToothStatus toToothStatus)
      : this(toothNumber)
    {
      dateTimePicker.Value = date;
      complaintTextBox.Text = diagnosis;
      fromToothStatusComboBox.SelectedIndex = (int)fromToothStatus;
      toToothStatusComboBox.SelectedIndex = (int)toToothStatus;
    }

    public DateTime Date { get; private set; }
    public ToothStatus FromToothStatus { get; private set; }
    public ToothStatus ToToothStatus { get; private set; }
    public string Diagnosis { get; private set; }

    private void AddButton_Click(object sender, EventArgs e)
    {
      Date = dateTimePicker.Value;
      Diagnosis = complaintTextBox.Text;
      FromToothStatus = (ToothStatus)fromToothStatusComboBox.SelectedIndex;
      ToToothStatus = (ToothStatus)toToothStatusComboBox.SelectedIndex;
    }
  }
}
