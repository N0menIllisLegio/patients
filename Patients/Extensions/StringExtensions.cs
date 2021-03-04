using System;
using System.Text;

namespace Patients.Extensions
{
  public static class StringExtensions
  {
    public static string TrimLowerCapitalizeFirstLetter(this string line)
    {
      if (String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
      {
        return String.Empty;
      }

      line = line.Trim().ToLower();

      var result = new StringBuilder(line);
      result[0] = Char.ToUpper(result[0]);

      return result.ToString();
    }
  }
}
