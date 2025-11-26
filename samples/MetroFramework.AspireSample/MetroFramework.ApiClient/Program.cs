using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MetroFramework.ApiClient
{
    static class Program
    {
        internal static IServiceProvider Services { get; private set; } = default!;
        internal static IHostEnvironment HostEnvironment { get; private set; } = default!;

        [STAThread]
        static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            // Add Aspire service defaults (service discovery, resilience, telemetry)
            builder.AddAppDefaults();

            // Configure HttpClient with service discovery URL
            builder.Services.AddHttpClient<ProductApiClient>(client =>
            {
                client.BaseAddress = new Uri("https+http://webapi");
            });

            HostEnvironment = builder.Environment;

            var app = builder.Build();
            Services = app.Services;
            app.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(ActivatorUtilities.CreateInstance<ApiClientForm>(app.Services));

            app.StopAsync().GetAwaiter().GetResult();
        }
    }
}
