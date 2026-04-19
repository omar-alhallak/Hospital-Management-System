using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Hospital_Management_System_WinForm.FormUI;
using Hospital_Management_System_WinForm.Infrastructure;

namespace Hospital_Management_System_WinForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<MainForm>();
                }).Build();

            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.Run(host.Services.GetRequiredService<MainForm>());
        }
    }
}