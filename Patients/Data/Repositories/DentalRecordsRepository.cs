using Patients.Data.Entities;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data.Repositories
{
  public class DentalRecordsRepository: RepositoryBase<DentalRecord>, IDentalRecordsRepository
  {
    public DentalRecordsRepository(AppDbContext context)
      : base(context)
    { }
  }
}
