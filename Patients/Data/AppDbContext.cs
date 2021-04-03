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
    public DbSet<DiaryRecord> DiaryRecords { get; set; }
    public DbSet<DentalRecord> DentalRecords { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PatientTooth> PatientsTeeth { get; set; }
    public DbSet<Tooth> Teeth { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<PatientTooth>()
        .HasKey(table => new { table.PatientID, table.ToothNumber });

      modelBuilder.Entity<Tooth>()
        .HasData(DatabaseSeeder.GetHumanTeeth());
    }
  }
}
