var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin();

var web = builder.AddExternalService("web", "http://localhost:3000");

builder.AddProject<Projects.Api>("api");

builder.Build().Run();