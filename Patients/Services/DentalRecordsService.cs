using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patients.Data;
using Patients.Data.Entities;
using Patients.Services.Interfaces;

namespace Patients.Services
{
  internal class DentalRecordsService: IDentalRecordsService
  {
    readonly UnitOfWork _unitOfWork;

    public DentalRecordsService(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<List<DentalRecord>> GetPatientDentalRecordsAsync(Guid patientID)
    {
      return await _unitOfWork.DentalRecords.GetAllByWhereAsync(dentalRecord => dentalRecord.PatientID == patientID,
        disableTracking: true);
    }

    public async Task UpdatePatientDentalRecordsAsync(Patient patient, List<DentalRecord> newDentalRecords)
    {
      var oldDentalRecords = await _unitOfWork.DentalRecords
        .GetAllByWhereAsync(dentalRecord => dentalRecord.PatientID == patient.ID);

      foreach (var oldDentalRecord in oldDentalRecords)
      {
        var newDentalRecord = newDentalRecords.FirstOrDefault(dentalRecord => dentalRecord.ID == oldDentalRecord.ID);

        if (newDentalRecord is null)
        {
          _unitOfWork.DentalRecords.Remove(oldDentalRecord);
        }
        else
        {
          if (oldDentalRecord.ToStatus != newDentalRecord.ToStatus
            || oldDentalRecord.FromStatus != newDentalRecord.FromStatus
            || oldDentalRecord.Cause != newDentalRecord.Cause || oldDentalRecord.Date != newDentalRecord.Date)
          {
            oldDentalRecord.FromStatus = newDentalRecord.FromStatus;
            oldDentalRecord.ToStatus = newDentalRecord.ToStatus;
            oldDentalRecord.Cause = newDentalRecord.Cause;
            oldDentalRecord.Date = newDentalRecord.Date;
          }

          newDentalRecords.Remove(newDentalRecord);
        }
      }

      _unitOfWork.DentalRecords.AddRange(newDentalRecords);

      await _unitOfWork.SaveAsync();
    }

    public async Task AddPatientDentalRecordsAsync(List<DentalRecord> newDentalRecords)
    {
      _unitOfWork.DentalRecords.AddRange(newDentalRecords);
      await _unitOfWork.SaveAsync();
    }
  }
}