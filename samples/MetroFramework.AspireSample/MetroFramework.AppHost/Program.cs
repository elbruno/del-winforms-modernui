var builder = DistributedApplication.CreateBuilder(args);

// Add the Web API backend
var api = builder.AddProject<Projects.MetroFramework_WebApi>("webapi");

// Add the WinForms client - requires Windows and uses explicit start from Aspire dashboard
if (OperatingSystem.IsWindows())
{
    builder.AddProject<Projects.MetroFramework_ApiClient>("apiclient")
        .WithReference(api)
        .WaitFor(api)
        .WithExplicitStart()
        .ExcludeFromManifest();
}

builder.Build().Run();
