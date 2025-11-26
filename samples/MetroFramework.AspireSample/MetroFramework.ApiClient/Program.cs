using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MetroFramework.ApiClient
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            // Build configuration - allows overriding via environment variable or appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // Get API base URL from configuration, defaulting to localhost:5000
            var apiBaseUrl = configuration["ApiBaseUrl"] ?? "http://localhost:5000";

            services.AddHttpClient<ProductApiClient>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });

            services.AddSingleton<ApiClientForm>();

            var serviceProvider = services.BuildServiceProvider();

            var form = serviceProvider.GetRequiredService<ApiClientForm>();
            Application.Run(form);
        }
    }
}
