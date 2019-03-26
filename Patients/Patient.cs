using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Patients
{
    public class Patient
    {
        [Key] public int? Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public string ScreensDirectory { get; set; }
        public string Diagnosis { get; set; }

        [Column("Sex")] public string _sex { get; set; }
        [Column("BirthDate")] public string _birthDate { get; set; }
        [Column("LastVisitDate")] public string _lastVisitDate { get; set; }
        [Column("Teeth")] public string _teeth { get; set; }

        [NotMapped]
        public Sex sex
        {
            get => _sex == "Female" ? Sex.Female : Sex.Male;
            set => _sex = value == Sex.Female ? "Female" : "Male";
        }

        [NotMapped]
        public DateTime BirthDate
        {
            get => ConvertStringToDate(_birthDate);
            set => _birthDate = ConvertDateToString(value);
        }

        [NotMapped]
        public DateTime LastVisitDate
        {
            get => ConvertStringToDate(_lastVisitDate);
            set => _lastVisitDate = ConvertDateToString(value);
        }

        [NotMapped]
        public Color[] Teeth
        {
            get => DeserializeColors(_teeth);
            set => _teeth = SerializeColors(value);
        }

        public static string ConvertDateToString(DateTime date)
        {
            string strDate;

            try
            {
                strDate = date.ToString("d");
            }
            catch (Exception)
            {
                strDate = DateTime.Today.ToString("d");
            }

            return strDate;
        }

        public static DateTime ConvertStringToDate(string strDate)
        {
            DateTime date;

            try
            {
                date = DateTime.ParseExact(strDate, "d", null);
            }
            catch (Exception)
            {
                date = DateTime.Today;
            }

            return date;
        }

        public static string SerializeColors(Color[] colors)
        {
            string json;

            try
            {
                json = JsonConvert.SerializeObject(colors, Formatting.None);
            }
            catch (Exception)
            {
                json = "";
            }

            return json;
        }

        public static Color[] DeserializeColors(string strColors)
        {
            Color[] colors;

            try
            {
                colors = JsonConvert.DeserializeObject<Color[]>(strColors);
            }
            catch (Exception)
            {
                colors = new Color[52];
                for (int i = 0; i < 52; i++)
                {
                    colors[i] = Color.Green;
                }
            }

            return colors;
        }
    }

    public enum Sex
    {
        Male,
        Female
    }
}
