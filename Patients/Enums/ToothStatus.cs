using System.ComponentModel;

namespace Patients.Enums
{
  public enum ToothStatus
  {
    [Description("Здоровый зуб")]
    Healthy,
    [Description("Кариес, осложнения кариеса")]
    Caries,
    [Description("Пломба")]
    Seal,
    [Description("Зуб отсутствует")]
    Removed,
    [Description("Корень")]
    Root,
    [Description("Искусственная коронка")]
    ArtificialCrown,
    [Description("Искусственный зуб")]
    Artificial
  }
}
