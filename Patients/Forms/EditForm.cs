using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Patients.Data.Entities;
using Patients.Enums;
using Patients.Extensions;
using Patients.Services;
using Patients.Services.Interfaces;

namespace Patients.Forms
{
  public partial class EditForm: Form
  {
    private static readonly string[] _storages;

    private readonly IPatientsService _patientsService;
    private readonly IDiaryRecordsService _diaryRecordsService;
    private readonly IDentalRecordsService _dentalRecordsService;
    private readonly IPatientTeethService _patientTeethService;
    private readonly IPaymentsService _paymentsService;

    private readonly PatientPicturesManager _patientPicturesManager;

    private readonly Guid? _patientID;
    private readonly List<PatientTooth> _patientTeeth;
    private readonly List<Payment> _payments;
    private readonly List<DiaryRecord> _diary;
    private List<DentalRecord> _dentalRecords;

    static EditForm()
    {
      _storages = Enum.GetValues<Storage>()
        .Select(storage => storage.GetDescription()).ToArray();
    }

    public EditForm(bool newPatient = true)
    {
      _patientsService = Program.ServiceProvider.GetService<IPatientsService>();
      _diaryRecordsService = Program.ServiceProvider.GetService<IDiaryRecordsService>();
      _paymentsService = Program.ServiceProvider.GetService<IPaymentsService>();
      _dentalRecordsService = Program.ServiceProvider.GetService<IDentalRecordsService>();
      _patientTeethService = Program.ServiceProvider.GetService<IPatientTeethService>();

      _patientPicturesManager = new PatientPicturesManager();

      InitializeComponent();

      storageComboBox.Items.AddRange(_storages);

      if (newPatient)
      {
        _payments = new List<Payment>();
        _dentalRecords = new List<DentalRecord>();
        _diary = new List<DiaryRecord>();
        _patientTeeth = _patientTeethService.CreateNewPatientTeethAsync().Result;

        #region Set buttons tooltips

        string healthyToothStatusDescription = ToothStatus.Healthy.GetDescription();

        toothStatusToolTip.SetToolTip(button_11, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_12, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_13, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_14, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_15, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_16, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_17, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_18, healthyToothStatusDescription);

        toothStatusToolTip.SetToolTip(button_21, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_22, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_23, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_24, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_25, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_26, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_27, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_28, healthyToothStatusDescription);

        toothStatusToolTip.SetToolTip(button_31, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_32, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_33, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_34, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_35, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_36, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_37, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_38, healthyToothStatusDescription);

        toothStatusToolTip.SetToolTip(button_41, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_42, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_43, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_44, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_45, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_46, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_47, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_48, healthyToothStatusDescription);

        toothStatusToolTip.SetToolTip(button_51, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_52, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_53, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_54, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_55, healthyToothStatusDescription);

        toothStatusToolTip.SetToolTip(button_61, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_62, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_63, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_64, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_65, healthyToothStatusDescription);

        toothStatusToolTip.SetToolTip(button_71, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_72, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_73, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_74, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_75, healthyToothStatusDescription);

        toothStatusToolTip.SetToolTip(button_81, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_82, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_83, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_84, healthyToothStatusDescription);
        toothStatusToolTip.SetToolTip(button_85, healthyToothStatusDescription);

        #endregion Set buttons tooltips

        storageComboBox.SelectedIndex = 0;
        totalImgCountLabel.Text = $"Всего снимков: {_patientPicturesManager.DisplayedPatientPicturesCount}";
        dateOfBirthPicker.Value = dateOfBirthPicker.MinDate;

        RefreshDisplayedPatientPicture();
        RefreshAge();
      }
    }

    public EditForm(Guid patientID)
      : this(newPatient: false)
    {
      _patientID = patientID;
      var patient = _patientsService.GetPatientAsync(patientID).Result;

      _patientPicturesManager = new PatientPicturesManager(patientID);
      totalImgCountLabel.Text = $"Всего снимков: {_patientPicturesManager.DisplayedPatientPicturesCount}";
      RefreshDisplayedPatientPicture();

      nameTextBox.Text = patient.Name;
      surnameTextBox.Text = patient.Surname;
      secnameTextBox.Text = patient.SecondName;
      lastVisitDatePicker.Value = patient.LastVisitDate;
      dateOfBirthPicker.Value = patient.BirthDate;
      addressTextBox.Text = patient.Address;
      diagnosisTextBox.Text = patient.Diagnosis;
      descriptionTextBox.Text = patient.Description;

      phoneNumberTextBox.Text = String.IsNullOrEmpty(patient.PhoneNumber?.Trim())
        ? phoneNumberTextBox.Text
        : patient.PhoneNumber;

      switch (patient.Gender)
      {
        case Gender.Male:
          maleRadioButton.Checked = true;
          break;

        case Gender.Female:
          femaleRadioButton.Checked = true;
          break;
      }

      storageComboBox.SelectedIndex = (int)patient.Storage;

      _patientTeeth = patient.Teeth.OrderBy(tooth => tooth.ToothNumber).ToList();
      _dentalRecords = _dentalRecordsService.GetPatientDentalRecordsAsync(patient.ID).Result;
      _payments = patient.Payments.ToList();
      _diary = patient.Diary.ToList();

      if (_patientTeeth.Count == 0)
      {
        _patientTeeth = _patientTeethService.CreateNewPatientTeethAsync(patient).Result;
        _patientTeethService.AddPatientTeethAsync(_patientTeeth);
      }

      #region Set buttons colors

      button_11.BackColor = _patientTeeth[0].Status.ConvertToColor();
      button_12.BackColor = _patientTeeth[1].Status.ConvertToColor();
      button_13.BackColor = _patientTeeth[2].Status.ConvertToColor();
      button_14.BackColor = _patientTeeth[3].Status.ConvertToColor();
      button_15.BackColor = _patientTeeth[4].Status.ConvertToColor();
      button_16.BackColor = _patientTeeth[5].Status.ConvertToColor();
      button_17.BackColor = _patientTeeth[6].Status.ConvertToColor();
      button_18.BackColor = _patientTeeth[7].Status.ConvertToColor();

      button_21.BackColor = _patientTeeth[8].Status.ConvertToColor();
      button_22.BackColor = _patientTeeth[9].Status.ConvertToColor();
      button_23.BackColor = _patientTeeth[10].Status.ConvertToColor();
      button_24.BackColor = _patientTeeth[11].Status.ConvertToColor();
      button_25.BackColor = _patientTeeth[12].Status.ConvertToColor();
      button_26.BackColor = _patientTeeth[13].Status.ConvertToColor();
      button_27.BackColor = _patientTeeth[14].Status.ConvertToColor();
      button_28.BackColor = _patientTeeth[15].Status.ConvertToColor();

      button_31.BackColor = _patientTeeth[16].Status.ConvertToColor();
      button_32.BackColor = _patientTeeth[17].Status.ConvertToColor();
      button_33.BackColor = _patientTeeth[18].Status.ConvertToColor();
      button_34.BackColor = _patientTeeth[19].Status.ConvertToColor();
      button_35.BackColor = _patientTeeth[20].Status.ConvertToColor();
      button_36.BackColor = _patientTeeth[21].Status.ConvertToColor();
      button_37.BackColor = _patientTeeth[22].Status.ConvertToColor();
      button_38.BackColor = _patientTeeth[23].Status.ConvertToColor();

      button_41.BackColor = _patientTeeth[24].Status.ConvertToColor();
      button_42.BackColor = _patientTeeth[25].Status.ConvertToColor();
      button_43.BackColor = _patientTeeth[26].Status.ConvertToColor();
      button_44.BackColor = _patientTeeth[27].Status.ConvertToColor();
      button_45.BackColor = _patientTeeth[28].Status.ConvertToColor();
      button_46.BackColor = _patientTeeth[29].Status.ConvertToColor();
      button_47.BackColor = _patientTeeth[30].Status.ConvertToColor();
      button_48.BackColor = _patientTeeth[31].Status.ConvertToColor();

      button_51.BackColor = _patientTeeth[32].Status.ConvertToColor();
      button_52.BackColor = _patientTeeth[33].Status.ConvertToColor();
      button_53.BackColor = _patientTeeth[34].Status.ConvertToColor();
      button_54.BackColor = _patientTeeth[35].Status.ConvertToColor();
      button_55.BackColor = _patientTeeth[36].Status.ConvertToColor();

      button_61.BackColor = _patientTeeth[37].Status.ConvertToColor();
      button_62.BackColor = _patientTeeth[38].Status.ConvertToColor();
      button_63.BackColor = _patientTeeth[39].Status.ConvertToColor();
      button_64.BackColor = _patientTeeth[40].Status.ConvertToColor();
      button_65.BackColor = _patientTeeth[41].Status.ConvertToColor();

      button_71.BackColor = _patientTeeth[42].Status.ConvertToColor();
      button_72.BackColor = _patientTeeth[43].Status.ConvertToColor();
      button_73.BackColor = _patientTeeth[44].Status.ConvertToColor();
      button_74.BackColor = _patientTeeth[45].Status.ConvertToColor();
      button_75.BackColor = _patientTeeth[46].Status.ConvertToColor();

      button_81.BackColor = _patientTeeth[47].Status.ConvertToColor();
      button_82.BackColor = _patientTeeth[48].Status.ConvertToColor();
      button_83.BackColor = _patientTeeth[49].Status.ConvertToColor();
      button_84.BackColor = _patientTeeth[50].Status.ConvertToColor();
      button_85.BackColor = _patientTeeth[51].Status.ConvertToColor();

      #endregion Set buttons colors

      #region Set buttons tooltips

      toothStatusToolTip.SetToolTip(button_11, _patientTeeth[0].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_12, _patientTeeth[1].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_13, _patientTeeth[2].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_14, _patientTeeth[3].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_15, _patientTeeth[4].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_16, _patientTeeth[5].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_17, _patientTeeth[6].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_18, _patientTeeth[7].Status.GetDescription());

      toothStatusToolTip.SetToolTip(button_21, _patientTeeth[8].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_22, _patientTeeth[9].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_23, _patientTeeth[10].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_24, _patientTeeth[11].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_25, _patientTeeth[12].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_26, _patientTeeth[13].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_27, _patientTeeth[14].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_28, _patientTeeth[15].Status.GetDescription());

      toothStatusToolTip.SetToolTip(button_31, _patientTeeth[16].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_32, _patientTeeth[17].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_33, _patientTeeth[18].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_34, _patientTeeth[19].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_35, _patientTeeth[20].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_36, _patientTeeth[21].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_37, _patientTeeth[22].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_38, _patientTeeth[23].Status.GetDescription());

      toothStatusToolTip.SetToolTip(button_41, _patientTeeth[24].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_42, _patientTeeth[25].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_43, _patientTeeth[26].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_44, _patientTeeth[27].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_45, _patientTeeth[28].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_46, _patientTeeth[29].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_47, _patientTeeth[30].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_48, _patientTeeth[31].Status.GetDescription());

      toothStatusToolTip.SetToolTip(button_51, _patientTeeth[32].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_52, _patientTeeth[33].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_53, _patientTeeth[34].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_54, _patientTeeth[35].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_55, _patientTeeth[36].Status.GetDescription());

      toothStatusToolTip.SetToolTip(button_61, _patientTeeth[37].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_62, _patientTeeth[38].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_63, _patientTeeth[39].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_64, _patientTeeth[40].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_65, _patientTeeth[41].Status.GetDescription());

      toothStatusToolTip.SetToolTip(button_71, _patientTeeth[42].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_72, _patientTeeth[43].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_73, _patientTeeth[44].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_74, _patientTeeth[45].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_75, _patientTeeth[46].Status.GetDescription());

      toothStatusToolTip.SetToolTip(button_81, _patientTeeth[47].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_82, _patientTeeth[48].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_83, _patientTeeth[49].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_84, _patientTeeth[50].Status.GetDescription());
      toothStatusToolTip.SetToolTip(button_85, _patientTeeth[51].Status.GetDescription());

      #endregion Set buttons tooltips

      RefreshPayments();
      RefreshAge();
      RefreshDiary();
    }

    private bool NewPatient => !_patientID.HasValue;

    protected override async void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);

      if (e.CloseReason == CloseReason.WindowsShutDown)
      {
        await SavePatient();
      }
      else if (e.CloseReason == CloseReason.UserClosing)
      {
        _patientPicturesManager.RejectChanges();
      }
    }

    #region Diary

    private void AddDiaryRecordButton_Click(object sender, EventArgs e)
    {
      var diaryRecordForm = new DiaryRecordForm();

      if (diaryRecordForm.ShowDialog() == DialogResult.OK)
      {
        _diary.Add(new DiaryRecord
        {
          ID = Guid.NewGuid(),
          Date = diaryRecordForm.Date,
          Diagnosis = diaryRecordForm.Diagnosis
        });

        RefreshDiary();
      }
    }

    private void DeleteDiaryRecordButton_Click(object sender, EventArgs e)
    {
      if (diaryTable.SelectedRows.Count > 0)
      {
        foreach (DataGridViewRow selectedRow in diaryTable.SelectedRows)
        {
          switch (MessageBox.Show($@"Вы действительно хотите удалить запись {selectedRow.Cells[2].Value}?",
              @"Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
          {
            case DialogResult.Yes:
              var diaryRecordID = (Guid)selectedRow.Cells[0].Value;
              _diary.Remove(_diary.First(diaryRecord => diaryRecord.ID == diaryRecordID));
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

    private void DiaryTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (diaryTable.SelectedRows.Count == 1)
      {
        var diaryRecordID = (Guid)diaryTable.SelectedRows[0].Cells[0].Value;
        var diaryRecord = _diary.FirstOrDefault(record => record.ID == diaryRecordID);

        var diaryRecordForm = new DiaryRecordForm(diaryRecord.Date, diaryRecord.Diagnosis);

        if (diaryRecordForm.ShowDialog() == DialogResult.OK)
        {
          diaryRecord.Diagnosis = diaryRecordForm.Diagnosis;
          diaryRecord.Date = diaryRecordForm.Date;

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
      diaryTable.Rows.Clear();

      foreach (var diaryRecord in _diary)
      {
        diaryTable.Rows.Add(diaryRecord.ID, diaryRecord.Date, diaryRecord.Diagnosis);
      }
    }

    #endregion Diary

    #region Payments

    private void RefreshPayments()
    {
      paymentsTable.Rows.Clear();

      foreach (var payment in _payments)
      {
        paymentsTable.Rows.Add(payment.ID, payment.Date, payment.Amount.ToCurrency(), payment.Diagnosis);
      }
    }

    private void AddPaymentButton_Click(object sender, EventArgs e)
    {
      var paymentForm = new PaymentForm();

      if (paymentForm.ShowDialog() == DialogResult.OK)
      {
        _payments.Add(new Payment
        {
          ID = Guid.NewGuid(),
          Date = paymentForm.Date,
          Amount = paymentForm.Amount,
          Diagnosis = paymentForm.Diagnosis
        });

        RefreshPayments();
      }
    }

    private void DeletePaymentButton_Click(object sender, EventArgs e)
    {
      if (paymentsTable.SelectedRows.Count > 0)
      {
        foreach (DataGridViewRow selectedRow in paymentsTable.SelectedRows)
        {
          switch (MessageBox.Show($"Вы действительно хотите удалить платеж:\n" +
            $"{selectedRow.Cells[1].Value} — {selectedRow.Cells[2].Value} у.е.?",
              @"Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
          {
            case DialogResult.Yes:
              var paymentID = (Guid)selectedRow.Cells[0].Value;
              _payments.Remove(_payments.First(payment => payment.ID == paymentID));
              break;

            default:
              break;
          }
        }

        RefreshPayments();
      }
      else
      {
        MessageBox.Show(@"Не выбран ни один платеж.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void PaymentsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (paymentsTable.SelectedRows.Count == 1)
      {
        var paymentID = (Guid)paymentsTable.SelectedRows[0].Cells[0].Value;
        var payment = _payments.FirstOrDefault(p => p.ID == paymentID);

        var paymentForm = new PaymentForm(payment.Date, payment.Amount, payment.Diagnosis);

        if (paymentForm.ShowDialog() == DialogResult.OK)
        {
          payment.Date = paymentForm.Date;
          payment.Amount = paymentForm.Amount;
          payment.Diagnosis = paymentForm.Diagnosis;

          RefreshPayments();
        }
      }
      else
      {
        MessageBox.Show(@"Выбран не один платеж.",
            @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion Payments

    #region Pictures

    private void AddPictureButton_Click(object sender, EventArgs e)
    {
      using var openFileDialog = new OpenFileDialog();

      openFileDialog.InitialDirectory = "c:\\";
      openFileDialog.Filter = @"Image Files(*.jpeg;*.jpg;*.png)|*.jpeg;*.jpg;*.png|All files (*.*)|*.*";
      openFileDialog.FilterIndex = 2;
      openFileDialog.RestoreDirectory = true;
      openFileDialog.Multiselect = true;

      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        _patientPicturesManager.AddPatientPictures(openFileDialog.FileNames);
        totalImgCountLabel.Text = $"Всего снимков: {_patientPicturesManager.DisplayedPatientPicturesCount}";

        if (_patientPicturesManager.DisplayedPatientPicturesCount == 1)
        {
          _patientPicturesManager.NextPatientPicture();
          RefreshDisplayedPatientPicture();
        }
      }
    }

    private void DelButton_Click(object sender, EventArgs e)
    {
      _patientPicturesManager.DeleteDisplayedPatientPicture();
      RefreshDisplayedPatientPicture();
      totalImgCountLabel.Text = $"Всего снимков: {_patientPicturesManager.DisplayedPatientPicturesCount}";
    }

    private void RefreshDisplayedPatientPicture()
    {
      string displayedPatientPicture = _patientPicturesManager.CurrentlyDisplayedPatientPicture;

      if (displayedPatientPicture is not null)
      {
        screenBox.ImageLocation = displayedPatientPicture;
        currImgLabel.Text = $"Текущий снимок: {_patientPicturesManager.DisplayedPatientPictureNumber}";
      }
      else
      {
        screenBox.Image = screenBox.InitialImage;
        currImgLabel.Text = @"Текущий снимок: 0";
      }
    }

    private void NextButton_Click(object sender, EventArgs e)
    {
      _patientPicturesManager.NextPatientPicture();
      RefreshDisplayedPatientPicture();
    }

    private void PrevButton_Click(object sender, EventArgs e)
    {
      _patientPicturesManager.PreviousPatientPicture();
      RefreshDisplayedPatientPicture();
    }

    #endregion Pictures

    private void CancelButton_Click(object sender, EventArgs e)
    {
      string cancelWarning = NewPatient
        ? @"Вы действительно хотите удалить создаваемого пациента?"
        : @"Вы действительно хотите отменить все внесенные изменения?";

      if (MessageBox.Show(cancelWarning, @"Внимание!",
        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
      {
        _patientPicturesManager.RejectChanges();
        Close();
      }
    }

    private async void SaveButton_Click(object sender, EventArgs e)
    {
      await SavePatient();
    }

    private async Task SavePatient()
    {
      var patient = !NewPatient
        ? await _patientsService.GetPatientAsync(_patientID.Value)
        : new Patient();

      patient.Name = nameTextBox.Text.TrimLowerCapitalizeFirstLetter();
      patient.Surname = surnameTextBox.Text.TrimLowerCapitalizeFirstLetter();
      patient.SecondName = secnameTextBox.Text.TrimLowerCapitalizeFirstLetter();

      patient.PhoneNumber = phoneNumberTextBox.Text != @"+375 (  )    -"
        ? phoneNumberTextBox.Text
        : null;

      patient.Address = addressTextBox.Text;
      patient.Diagnosis = diagnosisTextBox.Text;

      patient.LastVisitDate = lastVisitDatePicker.Value;
      patient.BirthDate = dateOfBirthPicker.Value;

      patient.Gender = maleRadioButton.Checked ? Gender.Male : Gender.Female;
      patient.Storage = (Storage)storageComboBox.SelectedIndex;

      patient.Description = descriptionTextBox.Text;

      _patientPicturesManager.ApplyChanges();

      if (NewPatient)
      {
        patient.Diary = _diary;
        patient.Teeth = _patientTeeth;
        patient.Payments = _payments;
        patient = await _patientsService.AddPatientAsync(patient);

        await _dentalRecordsService.AddPatientDentalRecordsAsync(_dentalRecords);
        _patientPicturesManager.MoveDisplayedPicturesToPatientDirectory(patient.ID);
      }
      else
      {
        await _diaryRecordsService.UpdatePatientDairyRecordsAsync(patient, _diary);
        await _dentalRecordsService.UpdatePatientDentalRecordsAsync(patient, _dentalRecords);
        await _patientTeethService.UpdatePatientTeethAsync(patient, _patientTeeth);
        await _paymentsService.UpdatePatientPaymentsAsync(patient, _payments);
        await _patientsService.UpdatePatientAsync(patient);
      }
    }

    private void MaskedTextBox_Enter(object sender, EventArgs e)
    {
      if (sender is MaskedTextBox maskedTextBox)
      {
        BeginInvoke((MethodInvoker)(() => maskedTextBox.Select(6, 0)));
      }
    }

    private void RefreshAge()
    {
      var birthDate = dateOfBirthPicker.Value;
      var currentDate = DateTime.Today;

      ageLabel.Text = birthDate < currentDate && birthDate.Year > 1900
        ? $"Возраст: {birthDate.Years(currentDate)}"
        : @"Возраст: —";
    }

    private void DateOfBirthPicker_Leave(object sender, EventArgs e)
    {
      RefreshAge();
    }

    private void ToothButtonMouseUp(object sender, MouseEventArgs e)
    {
      var toothButton = sender as Button;
      int toothNumber = Int32.Parse(toothButton.Name.Replace("button_", String.Empty));
      var tooth = _patientTeeth.First(t => t.ToothNumber == toothNumber);

      if (e.Button == MouseButtons.Left)
      {
        var fromToothStatus = tooth.Status;

        var teethStatusForm = new TeethStatusForm(fromToothStatus);

        if (teethStatusForm.ShowDialog() == DialogResult.OK && teethStatusForm.ToothStatus != fromToothStatus)
        {
          var toToothStatus = teethStatusForm.ToothStatus;
          string toothStatusDescription = toToothStatus.GetDescription();

          toothStatusToolTip.SetToolTip(toothButton, toothStatusDescription);
          toothButton.BackColor = toToothStatus.ConvertToColor();

          tooth.Status = toToothStatus;

          var diaryRecordForm = new EditDentalRecordForm(toothNumber, DateTime.Now, teethStatusForm.Cause,
            fromToothStatus, toToothStatus);

          if (diaryRecordForm.ShowDialog() == DialogResult.OK)
          {
            _dentalRecords.Add(new DentalRecord
            {
              ID = Guid.NewGuid(),
              Cause = diaryRecordForm.Diagnosis,
              Date = diaryRecordForm.Date,
              FromStatus = diaryRecordForm.FromToothStatus,
              ToStatus = diaryRecordForm.ToToothStatus,
              Tooth = tooth,
              ToothNumber = tooth.ToothNumber
            });
          }
        }
      }
      else if (e.Button == MouseButtons.Right)
      {
        var toothDentalRecords = _dentalRecords.Where(dentalRecord => dentalRecord.ToothNumber == toothNumber).ToList();
        var dentalRecordsForm = new DentalRecordsForm(tooth, toothDentalRecords);
        dentalRecordsForm.ShowDialog();

        _dentalRecords = _dentalRecords.Where(dentalRecord => dentalRecord.ToothNumber != toothNumber).ToList();
        _dentalRecords.AddRange(dentalRecordsForm.DentalRecords);
      }
    }
  }
}