using System;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patients.Data;
using Patients.Forms;
using Patients.Services;
using Patients.Services.Interfaces;

namespace Patients
{
  internal static class Program
  {
    public static IServiceProvider ServiceProvider { get; set; }

    static void ConfigureServices()
    {
      var services = new ServiceCollection();
      services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString));

      services.AddScoped<UnitOfWork>();
      services.AddScoped<IPatientsService, PatientsService>();
      services.AddScoped<IDiaryRecordsService, DiaryRecordsService>();
      services.AddScoped<IPaymentsService, PaymentsService>();
      services.AddScoped<IPatientTeethService, PatientTeethService>();
      services.AddScoped<IDentalRecordsService, DentalRecordsService>();

      ServiceProvider = services.BuildServiceProvider();
    }

    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      ConfigureServices();
      InitApp();

      Application.Run(new MainForm());
    }

    private static void InitApp()
    {
      if (!Directory.Exists(PatientPicturesManager.ScreensDirectory))
      {
        Directory.CreateDirectory(PatientPicturesManager.ScreensDirectory);
      }

      if (!Directory.Exists(PatientPicturesManager.TempScreensDirectory))
      {
        Directory.CreateDirectory(PatientPicturesManager.TempScreensDirectory);
      }

      string backupsDirectoryPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "PatientsBackUps");

      string thisMonthBackupDirectory = Path.Combine(backupsDirectoryPath, $"{DateTime.Today:yyyy.MM}");

      if (!Directory.Exists(thisMonthBackupDirectory))
      {
        Directory.CreateDirectory(thisMonthBackupDirectory);
      }

      var match = new Regex(@"Data Source=(.+);?")
        .Match(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);

      if (!match.Success)
      {
        throw new ArgumentException("Неверная строка соединения с БД.");
      }

      string databasePath = match.Groups[1].Value;
      string databaseFileName = Path.GetFileNameWithoutExtension(databasePath);
      string databaseExtension = Path.GetExtension(databasePath);

      string migrationBackupFilePath = Path.Combine(backupsDirectoryPath,
        GenerateDBBackupFileName(databaseFileName, databaseExtension, migrationBackup: true));

      var context = ServiceProvider.GetService<AppDbContext>();

      bool firstMigration = context.Database.GetAppliedMigrations().Count() == 0;

      if (!firstMigration && !File.Exists(migrationBackupFilePath))
      {
        File.Copy(databasePath, migrationBackupFilePath);
      }

      context.Database.Migrate();

      if (!firstMigration)
      {
        File.Delete(migrationBackupFilePath);
      }

      string standardBackupFilePath = Path.Combine(thisMonthBackupDirectory,
        GenerateDBBackupFileName(databaseFileName, databaseExtension, migrationBackup: false));

      File.Copy(databasePath, standardBackupFilePath);

      string prevMonthBackupDirectory = Path.Combine(backupsDirectoryPath, $"{DateTime.Today.AddMonths(-1):yyyy.MM}");

      if (Directory.Exists(prevMonthBackupDirectory))
      {
        string archiveFilePath = Path.Combine(backupsDirectoryPath, $"{Path.GetFileName(prevMonthBackupDirectory)}.zip");

        if (!File.Exists(archiveFilePath))
        {
          ZipFile.CreateFromDirectory(prevMonthBackupDirectory, archiveFilePath);
          Directory.Delete(prevMonthBackupDirectory, recursive: true);
        }
      }
    }

    private static string GenerateDBBackupFileName(string oldFileName, string extension, bool migrationBackup)
    {
      string backupNamePostfix = migrationBackup ? "_MigrationBackUp" : $"_{DateTime.Now:ddMMyyyyHHmmss}";

      return oldFileName + backupNamePostfix + extension;
    }
  }
}
