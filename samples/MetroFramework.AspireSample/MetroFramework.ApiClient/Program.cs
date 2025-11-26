using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MetroFramework.ApiClient
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = Host.CreateApplicationBuilder(args);
            builder.AddServiceDefaults();

            builder.Services.AddHttpClient<ProductApiClient>(client =>
            {
                client.BaseAddress = new Uri("https+http://webapi");
            });

            builder.Services.AddSingleton<ApiClientForm>();

            var host = builder.Build();

            var form = host.Services.GetRequiredService<ApiClientForm>();
            Application.Run(form);
        }
    }
}
