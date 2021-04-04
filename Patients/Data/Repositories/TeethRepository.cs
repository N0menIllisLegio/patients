using Patients.Data.Entities;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data.Repositories
{
  internal class TeethRepository : RepositoryBase<Tooth>, ITeethRepository
  {
    public TeethRepository(AppDbContext appDbContext)
      : base(appDbContext)
    { }
  }
}