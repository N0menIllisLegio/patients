using System;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patients.Data;
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
      var context = ServiceProvider.GetService<AppDbContext>();
      context.Database.Migrate();
    }
  }
}
