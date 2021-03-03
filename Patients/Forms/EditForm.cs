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
    private readonly IPatientsService _patientsService;
    private readonly IDiaryRecordsService _diaryRecordsService;

    private readonly PatientPicturesManager _patientPicturesManager;

    private readonly Guid? _patientID;
    private readonly List<DiaryRecord> _diary;
    private readonly List<Payment> _payments;

    public EditForm()
    {
      _patientsService = Program.ServiceProvider.GetService<IPatientsService>();
      _diaryRecordsService = Program.ServiceProvider.GetService<IDiaryRecordsService>();

      InitializeComponent();

      _patientPicturesManager = new PatientPicturesManager();
      totalImgCountLabel.Text = $"Всего снимков: {_patientPicturesManager.DisplayedPatientPicturesCount}";
      RefreshDisplayedPatientPicture();

      _diary = new List<DiaryRecord>();
      _payments = new List<Payment>();

      string[] storages = Enum.GetValues<Storage>()
        .Select(storage => storage.GetDescription()).ToArray();

      storageComboBox.Items.AddRange(storages);
      storageComboBox.SelectedIndex = 0;
    }

    public EditForm(Guid patientID)
      : this()
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

      var dentalRecord = patient.DentalRecord;

      #region Set buttons colors

      button_11.BackColor = dentalRecord.Tooth11.ConvertToColor();
      button_12.BackColor = dentalRecord.Tooth12.ConvertToColor();
      button_13.BackColor = dentalRecord.Tooth13.ConvertToColor();
      button_14.BackColor = dentalRecord.Tooth14.ConvertToColor();
      button_15.BackColor = dentalRecord.Tooth15.ConvertToColor();
      button_16.BackColor = dentalRecord.Tooth16.ConvertToColor();
      button_17.BackColor = dentalRecord.Tooth17.ConvertToColor();
      button_18.BackColor = dentalRecord.Tooth18.ConvertToColor();

      button_21.BackColor = dentalRecord.Tooth21.ConvertToColor();
      button_22.BackColor = dentalRecord.Tooth22.ConvertToColor();
      button_23.BackColor = dentalRecord.Tooth23.ConvertToColor();
      button_24.BackColor = dentalRecord.Tooth24.ConvertToColor();
      button_25.BackColor = dentalRecord.Tooth25.ConvertToColor();
      button_26.BackColor = dentalRecord.Tooth26.ConvertToColor();
      button_27.BackColor = dentalRecord.Tooth27.ConvertToColor();
      button_28.BackColor = dentalRecord.Tooth28.ConvertToColor();

      button_31.BackColor = dentalRecord.Tooth31.ConvertToColor();
      button_32.BackColor = dentalRecord.Tooth32.ConvertToColor();
      button_33.BackColor = dentalRecord.Tooth33.ConvertToColor();
      button_34.BackColor = dentalRecord.Tooth34.ConvertToColor();
      button_35.BackColor = dentalRecord.Tooth35.ConvertToColor();
      button_36.BackColor = dentalRecord.Tooth36.ConvertToColor();
      button_37.BackColor = dentalRecord.Tooth37.ConvertToColor();
      button_38.BackColor = dentalRecord.Tooth38.ConvertToColor();

      button_41.BackColor = dentalRecord.Tooth41.ConvertToColor();
      button_42.BackColor = dentalRecord.Tooth42.ConvertToColor();
      button_43.BackColor = dentalRecord.Tooth43.ConvertToColor();
      button_44.BackColor = dentalRecord.Tooth44.ConvertToColor();
      button_45.BackColor = dentalRecord.Tooth45.ConvertToColor();
      button_46.BackColor = dentalRecord.Tooth46.ConvertToColor();
      button_47.BackColor = dentalRecord.Tooth47.ConvertToColor();
      button_48.BackColor = dentalRecord.Tooth48.ConvertToColor();

      button_51.BackColor = dentalRecord.Tooth51.ConvertToColor();
      button_52.BackColor = dentalRecord.Tooth52.ConvertToColor();
      button_53.BackColor = dentalRecord.Tooth53.ConvertToColor();
      button_54.BackColor = dentalRecord.Tooth54.ConvertToColor();
      button_55.BackColor = dentalRecord.Tooth55.ConvertToColor();

      button_61.BackColor = dentalRecord.Tooth61.ConvertToColor();
      button_62.BackColor = dentalRecord.Tooth62.ConvertToColor();
      button_63.BackColor = dentalRecord.Tooth63.ConvertToColor();
      button_64.BackColor = dentalRecord.Tooth64.ConvertToColor();
      button_65.BackColor = dentalRecord.Tooth65.ConvertToColor();

      button_71.BackColor = dentalRecord.Tooth71.ConvertToColor();
      button_72.BackColor = dentalRecord.Tooth72.ConvertToColor();
      button_73.BackColor = dentalRecord.Tooth73.ConvertToColor();
      button_74.BackColor = dentalRecord.Tooth74.ConvertToColor();
      button_75.BackColor = dentalRecord.Tooth75.ConvertToColor();

      button_81.BackColor = dentalRecord.Tooth81.ConvertToColor();
      button_82.BackColor = dentalRecord.Tooth82.ConvertToColor();
      button_83.BackColor = dentalRecord.Tooth83.ConvertToColor();
      button_84.BackColor = dentalRecord.Tooth84.ConvertToColor();
      button_85.BackColor = dentalRecord.Tooth85.ConvertToColor();

      #endregion Set buttons colors

      _diary = patient.Diary.ToList();
      _payments = patient.Payments.ToList();
      RefreshDiary();
      RefreshPayments();
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
        MessageBox.Show(@"Выбрана более чем одна запись в дневнике.",
            @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void RefreshDiary()
    {
      diaryTable.Rows.Clear();

      foreach (var diaryRecord in _diary)
      {
        diaryTable.Rows.Add(diaryRecord.ID, diaryRecord.Date.ToString("D"), diaryRecord.Diagnosis);
      }
    }

    #endregion Diary

    #region Payments

    private void RefreshPayments()
    {
      paymentsTable.Rows.Clear();

      foreach (var payment in _payments)
      {
        paymentsTable.Rows.Add(payment.ID, payment.Date.ToString("D"), payment.Amount.ToCurrency());
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
          Amount = paymentForm.Amount
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

        var paymentForm = new PaymentForm(payment.Date, payment.Amount);

        if (paymentForm.ShowDialog() == DialogResult.OK)
        {
          payment.Date = paymentForm.Date;
          payment.Amount = paymentForm.Amount;

          RefreshPayments();
        }
      }
      else
      {
        MessageBox.Show(@"Выбрана более чем один платеж.",
            @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion Payments

    #region Pictures

    private void AddPictureButton_Click(object sender, EventArgs e)
    {
      using (var openFileDialog = new OpenFileDialog())
      {
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

    private void ChangeToothStatus(object sender, EventArgs e)
    {
      var toothButton = sender as Button;
      var previousStatus = toothButton.BackColor.ConvertToToothStatus();
      var teethStatusForm = new TeethStatusForm(previousStatus);

      if (teethStatusForm.ShowDialog() == DialogResult.OK && teethStatusForm.ToothStatus != previousStatus)
      {
        string diagnosis = $"Зуб №{toothButton.Name.Replace("button_", String.Empty)} " +
          $"сменил статус с: {previousStatus.GetDescription()} " +
          $"на: {teethStatusForm.ToothStatus.GetDescription()}.";

        if (!String.IsNullOrEmpty(teethStatusForm.Cause.Trim()))
        {
          diagnosis += $" Причина: {teethStatusForm.Cause}";
        }

        toothButton.BackColor = teethStatusForm.ToothStatus.ConvertToColor();

        var diaryRecordForm = new DiaryRecordForm(DateTime.Today, diagnosis);

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
    }

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
        : new Patient { DentalRecord = new DentalRecord() };

      patient.Name = nameTextBox.Text.TrimLowerCapitalizeFirstLetter();
      patient.Surname = surnameTextBox.Text.TrimLowerCapitalizeFirstLetter();
      patient.SecondName = secnameTextBox.Text.TrimLowerCapitalizeFirstLetter();

      patient.PhoneNumber = phoneNumberTextBox.Text;
      patient.Address = addressTextBox.Text;
      patient.Diagnosis = diagnosisTextBox.Text;

      patient.LastVisitDate = lastVisitDatePicker.Value;
      patient.BirthDate = dateOfBirthPicker.Value;

      patient.Gender = maleRadioButton.Checked ? Gender.Male : Gender.Female;
      patient.Storage = (Storage)storageComboBox.SelectedIndex;

      patient.Description = descriptionTextBox.Text;

      _patientPicturesManager.ApplyChanges();

      #region Get teeth statuses from buttons

      patient.DentalRecord.Tooth11 = button_11.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth12 = button_12.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth13 = button_13.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth14 = button_14.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth15 = button_15.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth16 = button_16.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth17 = button_17.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth18 = button_18.BackColor.ConvertToToothStatus();

      patient.DentalRecord.Tooth21 = button_21.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth22 = button_22.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth23 = button_23.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth24 = button_24.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth25 = button_25.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth26 = button_26.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth27 = button_27.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth28 = button_28.BackColor.ConvertToToothStatus();

      patient.DentalRecord.Tooth31 = button_31.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth32 = button_32.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth33 = button_33.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth34 = button_34.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth35 = button_35.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth36 = button_36.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth37 = button_37.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth38 = button_38.BackColor.ConvertToToothStatus();

      patient.DentalRecord.Tooth41 = button_41.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth42 = button_42.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth43 = button_43.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth44 = button_44.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth45 = button_45.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth46 = button_46.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth47 = button_47.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth48 = button_48.BackColor.ConvertToToothStatus();

      patient.DentalRecord.Tooth51 = button_51.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth52 = button_52.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth53 = button_53.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth54 = button_54.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth55 = button_55.BackColor.ConvertToToothStatus();

      patient.DentalRecord.Tooth61 = button_61.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth62 = button_62.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth63 = button_63.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth64 = button_64.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth65 = button_65.BackColor.ConvertToToothStatus();

      patient.DentalRecord.Tooth71 = button_71.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth72 = button_72.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth73 = button_73.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth74 = button_74.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth75 = button_75.BackColor.ConvertToToothStatus();

      patient.DentalRecord.Tooth81 = button_81.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth82 = button_82.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth83 = button_83.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth84 = button_84.BackColor.ConvertToToothStatus();
      patient.DentalRecord.Tooth85 = button_85.BackColor.ConvertToToothStatus();

      #endregion Get teeth statuses from buttons

      if (NewPatient)
      {
        patient.Diary = _diary;
        patient.Payments = _payments;
        patient = await _patientsService.AddPatientAsync(patient);

        _patientPicturesManager.MoveDisplayedPicturesToPatientDirectory(patient.ID);
      }
      else
      {
        await _diaryRecordsService.UpdatePatientDairyRecordsAsync(patient, _diary);
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
  }
}