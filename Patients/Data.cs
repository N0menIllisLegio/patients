using System;
using System.Data;
using System.IO;

namespace Patients
{
    class Data
    {
        public static DataTable PatientsInfo = new DataTable("Patients");
        public static DataTable SearchingDataTable = new DataTable("SearchTable");

        public static void SetTables()
        {
            Type stringType = Type.GetType("System.String");
            Type intType = Type.GetType("System.Int32");

            if (stringType != null && intType != null)
            {
                DataColumn idColumn = new DataColumn("Id", intType)
                {
                    Unique = true,
                    AllowDBNull = false,
                    AutoIncrement = true,
                    AutoIncrementSeed = 1,
                    AutoIncrementStep = 1
                };

                PatientsInfo.Columns.Add(idColumn);
                PatientsInfo.Columns.Add(new DataColumn("Фамилия", stringType));
                PatientsInfo.Columns.Add(new DataColumn("Имя", stringType));
                PatientsInfo.Columns.Add(new DataColumn("Отчество", stringType));
                PatientsInfo.Columns.Add(new DataColumn("Место хранения информации", stringType));
                PatientsInfo.Columns.Add(new DataColumn("Дата посещения", stringType));
                PatientsInfo.PrimaryKey = new[] { PatientsInfo.Columns["Id"] };

                SearchingDataTable = PatientsInfo.Copy();
            }  
        }

        public static void SaveTable(string fileName)
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                PatientsInfo.WriteXml(outputFile, XmlWriteMode.WriteSchema, false);
            }
        }

        public static void LoadTable(string fileName)
        {
            if (File.Exists(fileName))
            {
                CreateBackUp(fileName);

                using (StreamReader outputFile = new StreamReader(fileName))
                {
                    PatientsInfo.ReadXml(outputFile);
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
    }
}
