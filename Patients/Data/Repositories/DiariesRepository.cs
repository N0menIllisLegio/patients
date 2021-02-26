using Patients.Data.Entities;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data.Repositories
{
  public class DiariesRepository: RepositoryBase<Diary>, IDiariesRepository
  {
    public DiariesRepository(AppDbContext context)
      : base(context)
    { }
  }
}
