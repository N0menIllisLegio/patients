using System;
using System.Drawing;
using Patients.Enums;

namespace Patients.Extensions
{
  public static class StructExtensions
  {
    public static ToothStatus ConvertToToothStatus(this Color color)
    {
      return color.Name switch
      {
        "Green" => ToothStatus.Healthy,
        "Peru" => ToothStatus.Caries,
        "Blue" => ToothStatus.Seal,
        "Black" => ToothStatus.Removed,
        "Red" => ToothStatus.Root,
        "Gold" => ToothStatus.ArtificialCrown,
        "White" => ToothStatus.Artificial,
        _ => ToothStatus.Healthy
      };
    }

    public static int Years(this DateTime start, DateTime end)
    {
      return end.Year - start.Year - 1 +
          (((end.Month > start.Month) ||
          ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
    }
  }
}
