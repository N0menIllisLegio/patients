using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

    public static string ConvertDateToString(DateTime date)
    {
      string strDate;

      try
      {
        strDate = date.ToString("d");
      }
      catch (Exception)
      {
        strDate = DateTime.Today.ToString("d");
      }

      return strDate;
    }

    public static DateTime ConvertStringToDate(string strDate)
    {
      DateTime date;

      try
      {
        date = DateTime.ParseExact(strDate, "d", null);
      }
      catch (Exception)
      {
        date = DateTime.Today;
      }

      return date;
    }

    public static Color[] DeserializeColors(string strColors)
    {
      Color[] colors;

      try
      {
        colors = JsonConvert.DeserializeObject<Color[]>(strColors);
      }
      catch (Exception)
      {
        colors = new Color[52];
        for (int i = 0; i < 52; i++)
        {
          colors[i] = Color.Green;
        }
      }

      return colors;
    }

    public static string SerializeColors(Color[] colors)
    {
      string json;

      try
      {
        json = JsonConvert.SerializeObject(colors, Formatting.None);
      }
      catch (Exception)
      {
        json = String.Empty;
      }

      return json;
    }
  }
}
