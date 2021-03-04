using Patients.Data.Entities;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data.Repositories
{
  public class DiaryRecordsRepository: RepositoryBase<DiaryRecord>, IDiaryRecordsRepository
  {
    public DiaryRecordsRepository(AppDbContext context)
      : base(context)
    { }
  }
}
