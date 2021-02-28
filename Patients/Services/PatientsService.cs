using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
      return await _unitOfWork.Patients.GetFirstWhereAsync(patient => patient.ID == patientID,
        patient => patient.Include(p => p.DentalRecord).Include(p => p.Diary));
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

    public async Task<Patient> AddPatientAsync(Patient patient)
    {
      if (patient.ID == Guid.Empty)
      {
        patient.ID = Guid.NewGuid();
      }

      patient = _unitOfWork.Patients.Add(patient);
      await _unitOfWork.SaveAsync();

      return patient;
    }

    public async Task<Patient> UpdatePatientAsync(Patient patient)
    {
      patient = _unitOfWork.Patients.Update(patient);
      await _unitOfWork.SaveAsync();

      return patient;
    }

    public async Task DeletePatientAsync(Guid patientID)
    {
      var patient = await _unitOfWork.Patients.FindAsync(patientID);

      if (patient is null)
      {
        return;
      }

      _unitOfWork.Patients.Remove(patient);
      await _unitOfWork.SaveAsync();

      string patientPicturesDirctory = Path.Combine(PatientPicturesManager.ScreensDirectory, patient.ID.ToString());

      if (Directory.Exists(patientPicturesDirctory))
      {
        Directory.Delete(patientPicturesDirctory, true);
      }
    }

    public async Task DeletePatients(List<Guid> patientIDs)
    {
      var patients = await _unitOfWork.Patients.GetAllByWhereAsync(patient => patientIDs.Contains(patient.ID));

      if (patients.Count == 0)
      {
        return;
      }

      _unitOfWork.Patients.RemoveRange(patients);
      await _unitOfWork.SaveAsync();

      foreach (var patient in patients)
      {
        string patientPicturesDirctory = Path.Combine(PatientPicturesManager.ScreensDirectory, patient.ID.ToString());

        if (Directory.Exists(patientPicturesDirctory))
        {
          Directory.Delete(patientPicturesDirctory, true);
        }
      }
    }
  }
}
