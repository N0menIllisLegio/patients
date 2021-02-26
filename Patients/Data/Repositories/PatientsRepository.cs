using Patients.Data.Entities;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data.Repositories
{
  public class PatientsRepository: RepositoryBase<Patient>, IPatientsRepository
  {
    public PatientsRepository(AppDbContext context)
      : base(context)
    { }
  }
}
