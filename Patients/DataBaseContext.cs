using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using SQLite.CodeFirst;

namespace Patients
{
    public class DataBaseContext : DbContext
    {
        private static DataBaseContext _instance;
        public static string ScreensDirectory = "Screens";
        public static string TempScreensDirectory = "Temp";

        public static DataBaseContext GetInstance()
        {
            return _instance ?? (_instance = new DataBaseContext());
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        
        private DataBaseContext() : base("DefaultConnection")
        {
            if (!Directory.Exists(ScreensDirectory))
            {
                Directory.CreateDirectory(ScreensDirectory);
            }

            TempScreensDirectory = Path.Combine(ScreensDirectory, "Temp");

            if (!Directory.Exists(TempScreensDirectory))
            {
                Directory.CreateDirectory(TempScreensDirectory);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<DataBaseContext>(modelBuilder));
        }

        //-----PATIENT------

        public List<Patient> GetAllPatients()
        {
            return Patients.ToList();
        }

        public Patient GetPatientById(int id)
        {
            return Patients.Single(o => o.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
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

        //------DIARY-----

        public List<Diary> GetPatientDiary(int id)
        {
           return Diaries.Local.Where(diary => diary.PatientId == id).ToList();
        }

        public Diary GetDiaryEventById(int patientId, int rowId)
        {
            return Diaries.Single(diary => diary.PatientId == patientId && diary.Id == rowId);
        }

        public void AddDiaryEvent(Diary diaryEvent)
        {
            Diaries.Add(diaryEvent);
        }

        public void AddDiaryEvents(List<Diary> diaryEvents)
        {
            Diaries.AddRange(diaryEvents);
        }

        public void DeleteDiaryEvent(List<Diary> diaryEvents)
        {
            Diaries.RemoveRange(diaryEvents);
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

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                File.Move(file, Path.Combine(to, fileName));
            }
        }
    }
}
