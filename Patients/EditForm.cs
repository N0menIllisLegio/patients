using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Patients
{
    public partial class EditForm : Form
    {
        private readonly List<Diary> _backUpDiaries;

        private readonly Patient _patient;
        private readonly DataBaseContext _db = DataBaseContext.GetInstance();
        private readonly bool _newPatient;

        private readonly List<string> _screensPaths = new List<string>();
        private readonly string _screensDir;
        private int _currentScreenDisplayed;

        private readonly Dictionary<string, string> _storingPlace = new Dictionary<string, string>
        {
            { "paper_radioButton", "Бумажный носитель" },
            { "patient_radioButton", "Пациент" },
            { "comp_radioButton_kartaWpf", "Компьютер (KartaWpf)" },
            { "comp_radioButton", "Компьютер" },
            { "comp_radioButton_dental", "Компьютер (Dental)" }
        };

        private readonly Dictionary<string, string> _revStoringPlace = new Dictionary<string, string>
        {
            { "Бумажный носитель", "paper_radioButton" },
            { "Пациент", "patient_radioButton" },
            { "Компьютер (KartaWpf)", "comp_radioButton_kartaWpf" },
            { "Компьютер", "comp_radioButton" },
            { "Компьютер (Dental)", "comp_radioButton_dental" }
        };
        
        public EditForm()
        {
            _screensDir = DataBaseContext.TempScreensDirectory;

            InitializeComponent();            
            _newPatient = true;
            _patient = new Patient();
            _backUpDiaries = new List<Diary>();
            ReadScreens();
            phoneNumberTextBox.Text = @"+375";
        }

        public EditForm(ref Patient patient)
        {
            if (patient.ScreensDirectory == null || !Directory.Exists(patient.ScreensDirectory))
            {
                patient.ScreensDirectory = Path.Combine(DataBaseContext.ScreensDirectory, patient.Id.ToString());
                Directory.CreateDirectory(patient.ScreensDirectory);
            }

            _screensDir = patient.ScreensDirectory;

            InitializeComponent();
            _patient = patient;
            _newPatient = false;
            _backUpDiaries = _db.GetPatientDiary(patient.Id ?? 0).ConvertAll(item => (Diary)item.Clone());
            
            nameTextBox.Text = patient.Name;
            surnameTextBox.Text = patient.Surname;
            secnameTextBox.Text = patient.SecondName;
            lastVisitDatePicker.Value = patient.LastVisitDate;
            dateOfBirthPicker.Value = patient.BirthDate;
            
            if (patient.PhoneNumber == null || patient.PhoneNumber.Trim() == "")
            {
                phoneNumberTextBox.Text = @"+375";
            }
            else
            {
                phoneNumberTextBox.Text = patient.PhoneNumber;
            }

            adressTextBox.Text = patient.Address;
            diagnosisTextBox.Text = patient.Diagnosis;
            SexSelect(patient.sex);
            PlaceOfStoring(patient.Place);

            RefreshButtons(patient.Teeth);
            RefreshDiary();
            ReadScreens();
        }

        private void RefreshButtons(Color[] teeth)
        {
            foreach (var element in teethGroupBox.Controls)
            {
                if (element is Button button)
                {
                    int buttonNum = int.Parse(button.AccessibleDescription);
                    button.BackColor = teeth[buttonNum - 1];
                }
            }
        }

        private Color[] GetColors()
        {
            Color[] teeth = new Color[52];

            foreach (var element in teethGroupBox.Controls)
            {
                if (element is Button button)
                {
                    int buttonNum = int.Parse(button.AccessibleDescription);
                    teeth[buttonNum - 1] = button.BackColor;
                }
            }

            return teeth;
        }

        private void ChangeToothStatus(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Diary diaryEvent = new Diary { PatientId = _patient.Id ?? 0 };
            TeethStatusForm teethStatusForm = new TeethStatusForm(ref button, ref diaryEvent);

            if (teethStatusForm.ShowDialog() == DialogResult.OK && teethStatusForm.isOK)
            {
                _db.AddDiaryEvent(diaryEvent);
                _db.SaveChanges();
                RefreshDiary();
            }
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            _patient.Name = Register(nameTextBox.Text);
            _patient.Surname = Register(surnameTextBox.Text);
            _patient.SecondName = Register(secnameTextBox.Text);

            _patient.PhoneNumber = phoneNumberTextBox.Text;
            _patient.Address = adressTextBox.Text;
            _patient.Diagnosis = diagnosisTextBox.Text;

            _patient.LastVisitDate = lastVisitDatePicker.Value;
            _patient.BirthDate = dateOfBirthPicker.Value;
            
            _patient.sex = SexSelect();
            _patient.Teeth = GetColors();
            PlaceOfStoring();
            
            if (_newPatient)
            {
                _db.AddPatient(_patient);
                _db.SaveChanges();
                _patient.ScreensDirectory = Path.Combine(DataBaseContext.ScreensDirectory, _patient.Id.ToString());
                Directory.CreateDirectory(_patient.ScreensDirectory);
                _db.MoveScreens(_screensDir, _patient.ScreensDirectory);
                _db.MoveDiary(0, _patient.Id ?? 0);
            }

            _db.SaveChanges();
        }

        public static string Register(string line)
        {

            line = line.Trim();
            line = line.ToLower();
            line = line == "" ? " " : line;

            StringBuilder result = new StringBuilder(line);
            result[0] = char.ToUpper(result[0]);

            return result.ToString();
        }

        private Sex SexSelect()
        {
            RadioButton radioBtn = groupBox1.Controls
                .OfType<RadioButton>().FirstOrDefault(x => x.Checked);

            return radioBtn?.Name == "maleRadioButton" ? Sex.Male : Sex.Female;
        }

        private void SexSelect(Sex sex)
        {
            if (sex != Sex.Male)
            {
                maleRadioButton.Checked = false;
                femaleRadioButton.Checked = true;
            }
        }

        private void PlaceOfStoring()
        {
            var radioBtn = groupBox5.Controls
                .OfType<RadioButton>().FirstOrDefault(x => x.Checked);

            _patient.Place = _storingPlace.TryGetValue(radioBtn.Name, out var value) ? value : "Бумажный носитель";
        }

        private void PlaceOfStoring(string place)
        {
            if (_revStoringPlace.TryGetValue(place, out var value))
            {
                var radioBtn = groupBox5.Controls
                    .OfType<RadioButton>().FirstOrDefault(x => x.Name == value);

                paper_radioButton.Checked = false;
                radioBtn.Checked = true;
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            Diary diaryEvent = new Diary { PatientId = _patient.Id ?? 0 };
            DiaryEventForm eventForm = new DiaryEventForm(ref diaryEvent);

            if (eventForm.ShowDialog() == DialogResult.OK)
            {
                _db.AddDiaryEvent(diaryEvent);
                _db.SaveChanges();
                RefreshDiary();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (diaryTable.SelectedRows.Count > 0)
            {
                List<Diary> forDeletion = new List<Diary>();

                foreach (DataGridViewRow selectedRow in diaryTable.SelectedRows)
                {
                    int rowId = (int)selectedRow.Cells[0].Value;
                    Diary diaryEvent = _db.GetDiaryEventById(_patient.Id ?? 0, rowId);

                    switch (MessageBox.Show($@"Вы действительно хотите удалить запись {diaryEvent.Diagnosis}?",
                        @"Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            forDeletion.Add(diaryEvent);
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.Cancel:
                            return;
                        default:
                            MessageBox.Show(@"Для выхода нажмите отмена");
                            break;
                    }
                }

                if (forDeletion.Count > 0)
                {
                    _db.DeleteDiaryEvent(forDeletion);
                    _db.SaveChanges();
                    RefreshDiary();
                }
            }
            else
            {
                MessageBox.Show(@"Не выбрана строка.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void diaryTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (diaryTable.SelectedRows.Count == 1)
            {
                int rowId = (int)diaryTable.SelectedRows[0].Cells[0].Value;
                Diary diaryEvent = _db.GetDiaryEventById(_patient.Id ?? 0, rowId);
                DiaryEventForm form = new DiaryEventForm(ref diaryEvent);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _db.SaveChanges();
                    RefreshDiary();
                }
            }
            else
            {
                MessageBox.Show(@"Выбрано неверное количество строк.",
                    @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDiary()
        {
            if (_patient != null)
            {
                diaryTable.Rows.Clear();

                foreach (var diagnosis in _db.GetPatientDiary(_patient.Id ?? 0))
                {
                    diaryTable.Rows.Add(diagnosis.Id, diagnosis.Date.ToString("D"), diagnosis.Diagnosis);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            RejectChanges();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {           
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
                return;
            if (e.CloseReason == CloseReason.UserClosing)
                RejectChanges();
        }

        private void RejectChanges()
        {
            _db.DeleteDiaryEvent(_db.GetPatientDiary(_patient.Id ?? 0));

            if (!_newPatient)
            {
                _db.AddDiaryEvents(_backUpDiaries);
            }
            else
            {
                foreach (var screensPath in _screensPaths)
                {
                    File.Delete(screensPath);
                }
            }

            _db.SaveChanges();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            _currentScreenDisplayed++;
            if (_currentScreenDisplayed > _screensPaths.Count - 1)
            {
                _currentScreenDisplayed = _screensPaths.Count - 1;
            }

            DisplayScreen();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            _currentScreenDisplayed--;
            if (_currentScreenDisplayed < 0)
            {
                _currentScreenDisplayed = 0;
            }

            DisplayScreen();
        }

        private void addScreenButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = @"Image Files(*.jpeg;*.jpg;*.png)|*.jpeg;*.jpg;*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePaths = openFileDialog.FileNames;
                    int i = 0;
                    foreach (var filePath in filePaths)
                    {
                        string newFileName = DateTime.Now.ToString("dd.MM.yyyy hh.mm.ss_") + i + Path.GetExtension(filePath);
                        var newFilePath = Path.Combine(_screensDir, newFileName);
                        _screensPaths.Add(newFilePath);
                        File.Move(filePath, newFilePath);
                        totalImgCountLabel.Text = @"Всего снимков: " + _screensPaths.Count;
                        i++;
                    }
                }
            }
        }

        private void ReadScreens()
        {
            _screensPaths.Clear();
            var files = Directory.GetFiles(_screensDir).
                Where(str => str.EndsWith(".jpg") || str.EndsWith(".jpeg") || str.EndsWith(".png"));
            _screensPaths.AddRange(files);
            totalImgCountLabel.Text = @"Всего снимков: " + _screensPaths.Count;
            _currentScreenDisplayed = 0;
            DisplayScreen();
        }

        private void DisplayScreen()
        {
            if (_screensPaths.Count > 0 )
            {
                screenBox.ImageLocation = _screensPaths[_currentScreenDisplayed];
                currImgLabel.Text = @"Текущий снимок: " + (_currentScreenDisplayed + 1);
            }
            else
            {
                screenBox.Image = screenBox.InitialImage;
                currImgLabel.Text = @"Текущий снимок: 0";
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (_screensPaths.Count > 0)
            {
                File.Delete(_screensPaths[_currentScreenDisplayed]);
                _screensPaths.RemoveAt(_currentScreenDisplayed);
                _currentScreenDisplayed = 0;
                DisplayScreen();
                totalImgCountLabel.Text = @"Всего снимков: " + _screensPaths.Count;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ReadScreens();
        }
    }
}
