using System;
using Microsoft.EntityFrameworkCore;
using Patients.Enums;

namespace Patients.Data.Entities
{
  [Index(nameof(PatientID), nameof(ToothNumber))]
  public class PatientTooth
  {
    public Guid PatientID { get; set; }
    public virtual Patient Patient { get; set; }

    public int ToothNumber { get; set; }
    public virtual Tooth Tooth { get; set; }

    public ToothStatus Status { get; set; }
  }
}
