using System.Collections.Generic;
using System.Threading.Tasks;
using Patients.Data.Entities;

namespace Patients.Services.Interfaces
{
  public interface IPatientTeethService
  {
    Task<List<PatientTooth>> CreateNewPatientTeethAsync();
    Task UpdatePatientTeethAsync(Patient patient, List<PatientTooth> newPatientTeeth);
  }
}
