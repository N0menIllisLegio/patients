using System.ComponentModel.DataAnnotations;

namespace Patients.Data.Entities
{
  public class Tooth
  {
    [Key]
    public int Number { get; set; }
  }
}
