using System;
using System.Globalization;

namespace Patients.Extensions
{
  public static class DecimalExtensions
  {
    private static readonly NumberFormatInfo _numberFormatInfo;

    static DecimalExtensions()
    {
      _numberFormatInfo = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
      _numberFormatInfo.CurrencySymbol = String.Empty;
    }

    public static string ToCurrency(this decimal value)
    {
      return String.Format(_numberFormatInfo, "{0:c}", value);
    }
  }
}
