using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patients.Data;
using Patients.Data.Entities;
using Patients.Services.Interfaces;

namespace Patients.Services
{
  public class PaymentsService: IPaymentsService
  {
    private readonly UnitOfWork _unitOfWork;

    public PaymentsService(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task UpdatePatientPaymentsAsync(Patient patient, IEnumerable<Payment> newPayments)
    {
      var oldPayments = patient.Payments.ToList();

      foreach (var oldPayment in oldPayments)
      {
        var newPayment = newPayments.FirstOrDefault(payment => payment.ID == oldPayment.ID);

        if (newPayment is null)
        {
          _unitOfWork.Payments.Remove(oldPayment);
        }
        else if (oldPayment.Amount != newPayment.Amount || oldPayment.Date != newPayment.Date
          || oldPayment.Diagnosis != newPayment.Diagnosis)
        {
          oldPayment.Amount = newPayment.Amount;
          oldPayment.Date = newPayment.Date;
          oldPayment.Diagnosis = newPayment.Diagnosis;
        }
      }

      foreach (var newPayment in newPayments.Except(oldPayments))
      {
        newPayment.PatientID = patient.ID;
        _unitOfWork.Payments.Add(newPayment);
      }

      await _unitOfWork.SaveAsync();
    }
  }
}
