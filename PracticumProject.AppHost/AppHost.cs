var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PracticumProject>("practicumproject");

builder.Build().Run();
