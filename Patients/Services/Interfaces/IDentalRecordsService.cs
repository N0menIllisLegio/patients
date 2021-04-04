using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Patients.Data.Entities;

namespace Patients.Services.Interfaces
{
  public interface IDentalRecordsService
  {
    Task<List<DentalRecord>> GetPatientDentalRecordsAsync(Guid patientID);
    Task AddPatientDentalRecordsAsync(List<DentalRecord> newDentalRecords);
    Task UpdatePatientDentalRecordsAsync(Patient patient, List<DentalRecord> newDentalRecords);
  }
}
