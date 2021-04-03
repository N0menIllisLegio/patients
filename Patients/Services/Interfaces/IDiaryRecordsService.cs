using System.Collections.Generic;
using System.Threading.Tasks;
using Patients.Data.Entities;

namespace Patients.Services.Interfaces
{
  interface IDiaryRecordsService
  {
    Task UpdatePatientDairyRecordsAsync(Patient patient, List<DiaryRecord> newDiaryRecords);
  }
}
