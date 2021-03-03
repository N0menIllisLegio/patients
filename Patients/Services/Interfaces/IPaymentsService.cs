using System.Collections.Generic;
using System.Threading.Tasks;
using Patients.Data.Entities;

namespace Patients.Services.Interfaces
{
  public interface IPaymentsService
  {
    Task UpdatePatientPaymentsAsync(Patient patient, IEnumerable<Payment> newPayments);
  }
}
