using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patients.Data;
using Patients.Data.Entities;
using Patients.Services.Interfaces;

namespace Patients.Services
{
  public class DiaryRecordsService: IDiaryRecordsService
  {
    private readonly UnitOfWork _unitOfWork;

    public DiaryRecordsService(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task UpdatePatientDairyRecordsAsync(Patient patient, List<DiaryRecord> newDiaryRecords)
    {
      var oldDiaryRecords = patient.Diary.ToList();

      foreach (var oldDiaryRecord in oldDiaryRecords)
      {
        var newDiaryRecord = newDiaryRecords.FirstOrDefault(diaryRecord => diaryRecord.ID == oldDiaryRecord.ID);

        if (newDiaryRecord is null)
        {
          _unitOfWork.DiaryRecords.Remove(oldDiaryRecord);
        }
        else
        {
          if (oldDiaryRecord.Diagnosis != newDiaryRecord.Diagnosis || oldDiaryRecord.Date != newDiaryRecord.Date)
          {
            oldDiaryRecord.Diagnosis = newDiaryRecord.Diagnosis;
            oldDiaryRecord.Date = newDiaryRecord.Date;
          }

          newDiaryRecords.Remove(newDiaryRecord);
        }
      }

      foreach (var newDiaryRecord in newDiaryRecords)
      {
        newDiaryRecord.Patient = patient;
        _unitOfWork.DiaryRecords.Add(newDiaryRecord);
      }

      await _unitOfWork.SaveAsync();
    }
  }
}
