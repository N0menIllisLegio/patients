using System;
using Patients.Enums;

namespace Patients.Data.Entities
{
  public class DentalRecord
  {
    public Guid ID { get; set; }
    public Guid PatientID { get; set; }
    public int ToothNumber { get; set; }
    public virtual PatientTooth Tooth { get; set; }

    public ToothStatus FromStatus { get; set; }
    public ToothStatus ToStatus { get; set; }
    public string Cause { get; set; }
    public DateTime Date { get; set; }
  }
}
