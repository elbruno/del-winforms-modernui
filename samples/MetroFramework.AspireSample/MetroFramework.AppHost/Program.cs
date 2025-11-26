var builder = DistributedApplication.CreateBuilder(args);

// Add the Web API backend
var api = builder.AddProject<Projects.MetroFramework_WebApi>("webapi");

// Note: The WinForms client (MetroFramework.ApiClient) should be run separately
// after the Aspire host starts. It will connect to the API using the configured URL.
// See README.md for instructions on running the complete sample.

builder.Build().Run();
