using System;
using System.ComponentModel.DataAnnotations;
using Patients.Enums;

namespace Patients.Data.Entities
{
  public class DentalRecord
  {
    [Key]
    public Guid PatientID { get; set; }
    public virtual Patient Patient { get; set; }

    public ToothStatus Tooth11 { get; set; }
    public ToothStatus Tooth12 { get; set; }
    public ToothStatus Tooth13 { get; set; }
    public ToothStatus Tooth14 { get; set; }
    public ToothStatus Tooth15 { get; set; }
    public ToothStatus Tooth16 { get; set; }
    public ToothStatus Tooth17 { get; set; }
    public ToothStatus Tooth18 { get; set; }

    public ToothStatus Tooth21 { get; set; }
    public ToothStatus Tooth22 { get; set; }
    public ToothStatus Tooth23 { get; set; }
    public ToothStatus Tooth24 { get; set; }
    public ToothStatus Tooth25 { get; set; }
    public ToothStatus Tooth26 { get; set; }
    public ToothStatus Tooth27 { get; set; }
    public ToothStatus Tooth28 { get; set; }

    public ToothStatus Tooth31 { get; set; }
    public ToothStatus Tooth32 { get; set; }
    public ToothStatus Tooth33 { get; set; }
    public ToothStatus Tooth34 { get; set; }
    public ToothStatus Tooth35 { get; set; }
    public ToothStatus Tooth36 { get; set; }
    public ToothStatus Tooth37 { get; set; }
    public ToothStatus Tooth38 { get; set; }

    public ToothStatus Tooth41 { get; set; }
    public ToothStatus Tooth42 { get; set; }
    public ToothStatus Tooth43 { get; set; }
    public ToothStatus Tooth44 { get; set; }
    public ToothStatus Tooth45 { get; set; }
    public ToothStatus Tooth46 { get; set; }
    public ToothStatus Tooth47 { get; set; }
    public ToothStatus Tooth48 { get; set; }

    public ToothStatus Tooth51 { get; set; }
    public ToothStatus Tooth52 { get; set; }
    public ToothStatus Tooth53 { get; set; }
    public ToothStatus Tooth54 { get; set; }
    public ToothStatus Tooth55 { get; set; }

    public ToothStatus Tooth61 { get; set; }
    public ToothStatus Tooth62 { get; set; }
    public ToothStatus Tooth63 { get; set; }
    public ToothStatus Tooth64 { get; set; }
    public ToothStatus Tooth65 { get; set; }

    public ToothStatus Tooth71 { get; set; }
    public ToothStatus Tooth72 { get; set; }
    public ToothStatus Tooth73 { get; set; }
    public ToothStatus Tooth74 { get; set; }
    public ToothStatus Tooth75 { get; set; }

    public ToothStatus Tooth81 { get; set; }
    public ToothStatus Tooth82 { get; set; }
    public ToothStatus Tooth83 { get; set; }
    public ToothStatus Tooth84 { get; set; }
    public ToothStatus Tooth85 { get; set; }
  }
}
