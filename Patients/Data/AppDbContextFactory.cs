using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Patients.Data
{
  class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
  {
    public AppDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
      optionsBuilder.UseSqlite("Data Source=PatientsDB.db");

      return new AppDbContext(optionsBuilder.Options);
    }
  }
}
