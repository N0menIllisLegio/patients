using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patients.Data.Entities
{
  public class Diary: ICloneable
  {
    [Key]
    public int? Id { get; set; }

    public int? PatientId { get; set; }

    public string Diagnosis { get; set; }

    [Column("Date")]
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable SA1300 // Element should begin with upper-case letter
    public string _date { get; set; }
#pragma warning restore SA1300 // Element should begin with upper-case letter
#pragma warning restore IDE1006 // Naming Styles

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
        Id = Id,
        PatientId = PatientId,
        Diagnosis = Diagnosis,
        _date = _date
      };
    }
  }
}
