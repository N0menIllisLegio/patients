using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Patients.Data.Entities;

namespace Patients.Services.Interfaces
{
  public interface IPatientsService
  {
    Task<Patient> GetPatientAsync(Guid patientID);
    Task<List<Patient>> GetPatientsAsync();
    Task<List<Patient>> SearchPatientsBySurname(string surname);
    Task<List<Patient>> SearchPatientsByName(string name);
    Task DeletePatients(List<Guid> patientIDs);
  }
}
