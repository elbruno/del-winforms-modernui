var builder = DistributedApplication.CreateBuilder(args);

// Add the Web API backend
var api = builder.AddProject<Projects.MetroFramework_WebApi>("webapi");

// Add the WinForms client that consumes the API
builder.AddProject<Projects.MetroFramework_ApiClient>("apiclient")
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();
