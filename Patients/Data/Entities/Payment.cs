using System;

namespace Patients.Data.Entities
{
  public class Payment
  {
    public Guid ID { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Diagnosis { get; set; }

    public virtual Patient Patient { get; set; }
    public Guid PatientID { get; set; }
  }
}
