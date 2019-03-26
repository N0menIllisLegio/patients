using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Patients
{
    public partial class Patient : Form
    {
        private static int _change = -1;

        public Patient()
        {
            _change = -1;
            InitializeComponent();
        }

        public Patient(int id) : this()
        {
            _change = id;
            DataRow pkRow = Data.PatientsInfo.Rows.Find(id);

            sur_textBox.Text = pkRow["Фамилия"].ToString();
            name_textBox.Text = pkRow["Имя"].ToString();
            sec_textBox.Text = pkRow["Отчество"].ToString();
            string place = pkRow["Место хранения информации"].ToString();

            comp_radioButton_dental.Checked = false;
            paper_radioButton.Checked = false;
            patient_radioButton.Checked = false;

            switch (place)
            {
                case "Компьютер (Dental)":
                    comp_radioButton_dental.Checked = true;
                    break;
                case "Компьютер (KartaWpf)":
                    comp_radioButton_kartaWpf.Checked = true;
                    break;
                case "Бумажный носитель":
                    paper_radioButton.Checked = true;
                    break;
                case "Пациент":
                    patient_radioButton.Checked = true;
                    break;
                default:
                    comp_radioButton_dental.Checked = true;
                    break;
            }
        }

        private bool Verification()
        {
            string rowPattern = @"^\w+$";
            Regex valueParser = new Regex(rowPattern);

            if (!valueParser.IsMatch(sec_textBox.Text.Trim()) && sec_textBox.Text.Trim() != "")
            {
                return false;
            }

            return valueParser.IsMatch(name_textBox.Text.Trim()) && valueParser.IsMatch(sur_textBox.Text.Trim());
        }

        private string Register(string line)
        {
           
            line = line.Trim();
            line = line.ToLower();

            if (line == "")
            {
                return " ";
            }

            StringBuilder result = new StringBuilder(line);
            result[0] = char.ToUpper(result[0]);

            return result.ToString();
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            if (Verification())
            {
                string surname = Register(sur_textBox.Text);
                string name = Register(name_textBox.Text);
                string secName = Register(sec_textBox.Text);
                string date = calendar.SelectionStart.ToString("dd.MM.yyyy");
                string place = "Компьютер (Dental)";

                RadioButton radioBtn = groupBox1.Controls
                    .OfType<RadioButton>().FirstOrDefault(x => x.Checked);
                
                if (radioBtn != null)
                {
                    switch (radioBtn.Name)
                    {
                        case "paper_radioButton":
                            place = "Бумажный носитель";
                            break;
                        case "patient_radioButton":
                            place = "Пациент";
                            break;
                        case "comp_radioButton_kartaWpf":
                            place = "Компьютер (KartaWpf)";
                            break;
                        case "comp_radioButton_dental":
                            place = "Компьютер (Dental)";
                            break;
                    }
                }

                if (_change == -1)
                {
                    Data.PatientsInfo.Rows.Add(new object[] { null, surname, name, secName, place, date });
                }
                else
                {
                    object[] row = { null, surname, name, secName, place, date };
                    DataRow pkRow = Data.PatientsInfo.Rows.Find(_change);
                    int pkIndex = Data.PatientsInfo.Rows.IndexOf(pkRow);

                    Data.PatientsInfo.Rows[pkIndex].ItemArray = row;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(@"Имя и фамилия должны быть указаны. Использование символов невозможно!", @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
