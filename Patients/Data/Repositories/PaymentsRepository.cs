using Patients.Data.Entities;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data.Repositories
{
  public class PaymentsRepository: RepositoryBase<Payment>, IPaymentsRepository
  {
    public PaymentsRepository(AppDbContext context)
      : base(context)
    { }
  }
}
