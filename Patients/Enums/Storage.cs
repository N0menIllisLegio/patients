using System.ComponentModel;

namespace Patients.Enums
{
  public enum Storage
  {
    [Description("Бумажный носитель")]
    Paper,
    [Description("Пациент")]
    Patient,
    [Description("Компьютер (KartaWpf)")]
    KartaWpf,
    [Description("Компьютер (Dental)")]
    Dental,
    [Description("Компьютер")]
    Computer
  }
}
