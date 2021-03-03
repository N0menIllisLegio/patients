using System;
using System.Configuration;
using System.IO;
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

      var context = ServiceProvider.GetService<AppDbContext>();
      context.Database.Migrate();
    }
  }
}
