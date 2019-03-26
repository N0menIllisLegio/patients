using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patients
{
    public class Diary : ICloneable
    {
        [Key] public int? Id { get; set; }
        public int? PatientId { get; set; }

        public string Diagnosis { get; set; }
        [Column("Date")] private string _date;

        [NotMapped]
        public DateTime Date
        {
            get => Patient.ConvertStringToDate(_date);
            set => _date = Patient.ConvertDateToString(value);
        }

        public object Clone()
        {
            return new Diary
            {
                Id = this.Id,
                PatientId = this.PatientId,
                Diagnosis = this.Diagnosis,
                _date = this._date
            };
        }
    }
}
