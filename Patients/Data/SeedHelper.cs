using System;
using System.Data;
using System.IO;

namespace Patients.Data
{
  internal class SeedHelper
  {
    private static readonly DataTable _patientsInfo = new DataTable("Patients");
    private static DataTable _searchingDataTable = new DataTable("SearchTable");

    public static void SetTables()
    {
      var stringType = Type.GetType("System.String");
      var intType = Type.GetType("System.Int32");

      if (stringType != null && intType != null)
      {
        var idColumn = new DataColumn("Id", intType)
        {
          Unique = true,
          AllowDBNull = false,
          AutoIncrement = true,
          AutoIncrementSeed = 1,
          AutoIncrementStep = 1
        };

        _patientsInfo.Columns.Add(idColumn);
        _patientsInfo.Columns.Add(new DataColumn("Фамилия", stringType));
        _patientsInfo.Columns.Add(new DataColumn("Имя", stringType));
        _patientsInfo.Columns.Add(new DataColumn("Отчество", stringType));
        _patientsInfo.Columns.Add(new DataColumn("Место хранения информации", stringType));
        _patientsInfo.Columns.Add(new DataColumn("Дата посещения", stringType));
        _patientsInfo.PrimaryKey = new[] { _patientsInfo.Columns["Id"] };

        _searchingDataTable = _patientsInfo.Copy();
      }
    }

    public static void SaveTable(string fileName)
    {
      using (var outputFile = new StreamWriter(fileName))
      {
        _patientsInfo.WriteXml(outputFile, XmlWriteMode.WriteSchema, false);
      }
    }

    public static void LoadTable(string fileName)
    {
      if (File.Exists(fileName))
      {
        CreateBackUp(fileName);

        using (var outputFile = new StreamReader(fileName))
        {
          _patientsInfo.ReadXml(outputFile);
        }
      }
      else
      {
        File.Create(fileName);
      }
    }

    private static void CreateBackUp(string dbFile)
    {
      if (!Directory.Exists("BackUps"))
      {
        Directory.CreateDirectory("BackUps");
      }

      string backupDir = @"BackUps";
      string newFileName = DateTime.Now + ".xml";
      newFileName = newFileName.Replace(':', '.');

      File.Copy(dbFile, Path.Combine(backupDir, newFileName));
    }

    public static void PrepareToConvertTables()
    {
      SetTables();
      LoadTable("PatientsDB.xml");
    }
  }
}
