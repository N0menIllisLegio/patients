using System;

namespace Patients.Data.Entities
{
  public class DiaryRecord: ICloneable
  {
    public Guid ID { get; set; }
    public string Diagnosis { get; set; }
    public DateTime Date { get; set; }

    public virtual Patient Patient { get; set; }
    public Guid PatientID { get; set; }

    public object Clone()
    {
      return new DiaryRecord
      {
        ID = ID,
        PatientID = PatientID,
        Diagnosis = Diagnosis,
        Date = Date
      };
    }
  }
}
