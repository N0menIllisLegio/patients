using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Patients.Data.Data.Entities;

namespace Patients
{
  internal static class Program
  {
    public static IServiceProvider ServiceProvider { get; set; }

    static void ConfigureServices()
    {
      var services = new ServiceCollection();
      services.AddTransient<Patient>();

      ServiceProvider = services.BuildServiceProvider();
    }

    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      ConfigureServices();
      Application.Run(new MainForm());
    }
  }
}
