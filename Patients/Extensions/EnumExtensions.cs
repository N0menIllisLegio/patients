using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Patients.Enums;

namespace Patients.Extensions
{
  public static class EnumExtensions
  {
    public static Color ConvertToColor(this ToothStatus toothStatus)
    {
      return toothStatus switch
      {
        ToothStatus.Healthy => Color.Green,
        ToothStatus.Caries => Color.Peru,
        ToothStatus.Seal => Color.Blue,
        ToothStatus.Removed => Color.Black,
        ToothStatus.Root => Color.Red,
        ToothStatus.ArtificialCrown => Color.Gold,
        ToothStatus.Artificial => Color.White,
        _ => Color.Purple
      };
    }

    public static string GetDescription(this Enum value)
    {
      var enumType = value.GetType();
      string name = Enum.GetName(enumType, value);

      var descriptionAttribute = enumType.GetField(name).GetCustomAttributes(false)
        .OfType<DescriptionAttribute>().SingleOrDefault();

      return descriptionAttribute.Description;
    }

    public static IEnumerable<T> GetValues<T>()
    {
      return Enum.GetValues(typeof(T)).Cast<T>();
    }
  }
}
