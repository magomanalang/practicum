
var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin();

builder.AddProject<Projects.PracticumProject>("practicumproject").WithReference(postgres);

builder.Build().Run();
