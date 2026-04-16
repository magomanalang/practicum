using PracticumProject.Components;
using PracticumProject.Data;
using Projects;
using System.Net.Sockets;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Session);
var db = postgres.AddDatabase("db", "loan-web");

var migrations = builder
    .AddProject<Projects.PracticumProject>("migrations")
    .WithReference(db)
    .WaitFor(db);


var api = builder
    .AddProject<Projects.PracticumProject>("api")
    .WithReference(db)
    .WaitFor(migrations);

builder.Build().Run();