using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patients.Data;
using Patients.Data.Entities;
using Patients.Services.Interfaces;

namespace Patients.Services
{
  internal class PatientTeethService : IPatientTeethService
  {
    private readonly UnitOfWork _unitOfWork;

    public PatientTeethService(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<List<PatientTooth>> CreateNewPatientTeethAsync(Patient patient = null)
    {
      var teeth = await _unitOfWork.Teeth.GetAllAsync(disableTracking: false);

      return new List<PatientTooth>(teeth.Select(tooth => new PatientTooth
      {
        Patient = patient,
        Status = Enums.ToothStatus.Healthy,
        Tooth = tooth,
        ToothNumber = tooth.Number
      }));
    }

    public async Task AddPatientTeethAsync(List<PatientTooth> newPatientTeeth)
    {
      _unitOfWork.PatientTeeth.AddRange(newPatientTeeth);
      await _unitOfWork.SaveAsync();
    }

    public async Task UpdatePatientTeethAsync(Patient patient, List<PatientTooth> newPatientTeeth)
    {
      var oldPatientTeeth = await _unitOfWork.PatientTeeth.GetAllByWhereAsync(tooth => tooth.PatientID == patient.ID);

      foreach (var oldTooth in oldPatientTeeth)
      {
        var newTooth = newPatientTeeth.FirstOrDefault(tooth => tooth.ToothNumber == oldTooth.ToothNumber);

        if (newTooth.Status != oldTooth.Status)
        {
          oldTooth.Status = newTooth.Status;
        }
      }

      await _unitOfWork.SaveAsync();
    }
  }
}
