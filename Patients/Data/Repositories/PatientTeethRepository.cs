using Patients.Data.Entities;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data.Repositories
{
  internal class PatientTeethRepository: RepositoryBase<PatientTooth>, IPatientTeethRepository
  {
    public PatientTeethRepository(AppDbContext appDbContext)
      : base(appDbContext)
    { }
  }
}