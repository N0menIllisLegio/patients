using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Patients.Data.Entities;
using SQLite.CodeFirst;

namespace Patients.Data.Data
{
  public class DataBaseContext: DbContext
  {
    public const string ScreensDirectory = "Screens";
    public const string TempScreensDirectory = @"Screens\Temp";
    private static DataBaseContext _instance;

    private DataBaseContext()
      : base("DefaultConnection")
    {
      if (!Directory.Exists(ScreensDirectory))
      {
        Directory.CreateDirectory(ScreensDirectory);
      }

      if (!Directory.Exists(TempScreensDirectory))
      {
        Directory.CreateDirectory(TempScreensDirectory);
      }
    }

    public DbSet<Diary> Diaries { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public static DataBaseContext GetInstance()
    {
      return _instance ?? (_instance = new DataBaseContext());
    }

    public void AddDiaryEvent(Diary diaryEvent)
    {
      Diaries.Add(diaryEvent);
    }

    public void AddDiaryEvents(List<Diary> diaryEvents)
    {
      Diaries.AddRange(diaryEvents);
    }

    public void AddPatient(Patient patient)
    {
      Patients.Add(patient);
    }

    public void DeleteDiaryEvent(List<Diary> diaryEvents)
    {
      Diaries.RemoveRange(diaryEvents);
    }

    public void DeletePatient(List<Patient> patients)
    {
      foreach (var patient in patients)
      {
        if (Directory.Exists(patient.ScreensDirectory))
        {
          Directory.Delete(patient.ScreensDirectory, true);
        }
      }

      Patients.RemoveRange(patients);
    }

    public List<Patient> GetAllPatients()
    {
      return Patients.ToList();
    }

    public Diary GetDiaryEventById(int patientId, int rowId)
    {
      return Diaries.Single(diary => diary.PatientId == patientId && diary.Id == rowId);
    }

    public Patient GetPatientById(int id)
    {
      return Patients.Single(o => o.Id == id);
    }

    public List<Diary> GetPatientDiary(int id)
    {
      return Diaries.Local.Where(diary => diary.PatientId == id).ToList();
    }

    public void MoveDiary(int fromId, int toId)
    {
      foreach (var diary in Diaries.Where(diaryEvent => diaryEvent.PatientId == fromId))
      {
        diary.PatientId = toId;
      }
    }

    public void MoveScreens(string from, string to)
    {
      var files = Directory.GetFiles(from).
          Where(str => str.EndsWith(".jpg") || str.EndsWith(".jpeg") || str.EndsWith(".png"));

      foreach (string file in files)
      {
        string fileName = Path.GetFileName(file);
        File.Move(file, Path.Combine(to, fileName));
      }
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<DataBaseContext>(modelBuilder));
    }
  }
}
