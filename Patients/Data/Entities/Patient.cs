using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Patients.Enums;

namespace Patients.Data.Entities
{
  [Index(nameof(Surname))]
  public class Patient
  {
    public Guid ID { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string SecondName { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public Storage Storage { get; set; }

    public string Diagnosis { get; set; }
    public DateTime LastVisitDate { get; set; }

    public virtual DentalRecord DentalRecord { get; set; }
    public virtual ICollection<DiaryRecord> Diary { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
  }
}
