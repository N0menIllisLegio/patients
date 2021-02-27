using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Patients.Data.Entities;

namespace Patients.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
      : base(contextOptions)
    { }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<DiaryRecord> DiaryRecords { get; set; }

    public DbSet<DentalRecord> DentalRecords { get; set; }

    public void AddDiaryEvent(DiaryRecord diaryEvent)
    {
      DiaryRecords.Add(diaryEvent);
    }

    public void AddDiaryEvents(List<DiaryRecord> diaryEvents)
    {
      DiaryRecords.AddRange(diaryEvents);
    }

    public void AddPatient(Patient patient)
    {
      Patients.Add(patient);
    }

    public void DeleteDiaryEvent(List<DiaryRecord> diaryEvents)
    {
      DiaryRecords.RemoveRange(diaryEvents);
    }

    public void DeletePatient(List<Patient> patients)
    {
      foreach (var patient in patients)
      {
        //if (Directory.Exists(patient.ScreensDirectory))
        //{
        //  Directory.Delete(patient.ScreensDirectory, true);
        //}
      }

      Patients.RemoveRange(patients);
    }

    public List<Patient> GetAllPatients()
    {
      return Patients.ToList();
    }

    public DiaryRecord GetDiaryEventById(int patientId, int rowId)
    {
      return null; // DiaryRecords.Single(diary => diary.PatientId == patientId && diary.Id == rowId);
    }

    public Patient GetPatientById(Guid id)
    {
      return Patients.Single(o => o.ID == id);
    }

    public List<DiaryRecord> GetPatientDiary(int id)
    {
      return null; // DiaryRecords.Local.Where(diary => diary.PatientId == id).ToList();
    }

    public void MoveDiary(int fromId, int toId)
    {
      //foreach (var diary in DiaryRecords.Where(diaryEvent => diaryEvent.PatientId == fromId))
      //{
      //  diary.PatientId = toId;
      //}
    }

    public void MoveScreens(string from, string to)
    {
      var files = Directory.GetFiles(from)
        .Where(str => str.EndsWith(".jpg") || str.EndsWith(".jpeg") || str.EndsWith(".png"));

      foreach (string file in files)
      {
        string fileName = Path.GetFileName(file);
        File.Move(file, Path.Combine(to, fileName));
      }
    }
  }
}
