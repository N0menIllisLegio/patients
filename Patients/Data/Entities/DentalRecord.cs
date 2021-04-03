using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Patients.Enums;

namespace Patients.Data.Entities
{
  public class DentalRecord
  {
    [Key]
    public int ToothNumber { get; set; }

    [ForeignKey("ToothNumber")]
    public virtual Tooth Tooth { get; set; }

    public ToothStatus FromStatus { get; set; }
    public ToothStatus ToStatus { get; set; }
    public string Cause { get; set; }
  }
}
