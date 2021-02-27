using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Patients.Data;
using Patients.Data.Entities;
using Patients.Services.Interfaces;

namespace Patients.Services
{
  public class PatientsService: IPatientsService
  {
    private readonly UnitOfWork _unitOfWork;

    public PatientsService(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<Patient> GetPatientAsync(Guid patientID)
    {
      return await _unitOfWork.Patients.FindAsync(patientID);
    }

    public async Task<List<Patient>> GetPatientsAsync()
    {
      return await _unitOfWork.Patients.GetAllAsync();
    }

    public async Task<List<Patient>> SearchPatientsBySurname(string surname)
    {
      return await _unitOfWork.Patients.GetAllByWhereAsync(patient => patient.Surname.StartsWith(surname));
    }

    public async Task<List<Patient>> SearchPatientsByName(string name)
    {
      return await _unitOfWork.Patients.GetAllByWhereAsync(patient => patient.Name.StartsWith(name));
    }

    public async Task DeletePatientAsync(Guid patientID)
    {
      var patient = await _unitOfWork.Patients.FindAsync(patientID);

      if (patient is null)
      {
        // TODO add popup.
        return;
      }

      _unitOfWork.Patients.Remove(patient);
      await _unitOfWork.SaveAsync();
    }

    public async Task DeletePatients(List<Guid> patientIDs)
    {
      var patients = await _unitOfWork.Patients.GetAllByWhereAsync(patient => patientIDs.Contains(patient.ID));

      if (patients.Count == 0)
      {
        // TODO add popup.
        return;
      }

      _unitOfWork.Patients.RemoveRange(patients);
      await _unitOfWork.SaveAsync();
    }
  }
}
