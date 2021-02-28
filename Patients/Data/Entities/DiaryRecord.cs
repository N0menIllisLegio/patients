using System;

namespace Patients.Data.Entities
{
  public class DiaryRecord
  {
    public Guid ID { get; set; }
    public string Diagnosis { get; set; }
    public DateTime Date { get; set; }

    public virtual Patient Patient { get; set; }
    public Guid PatientID { get; set; }
  }
}
