using Microsoft.EntityFrameworkCore;
using Patients.Data.Entities;

namespace Patients.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
      : base(contextOptions)
    { }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Diary> Diaries { get; set; }
  }
}
