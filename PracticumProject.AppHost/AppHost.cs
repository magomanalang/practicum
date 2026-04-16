
var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin();

var loanDb = postgres.AddDatabase("loan-db");


builder.AddProject<Projects.PracticumProject>("practicumproject");
builder.AddProject<Projects.PracticumProject>("loan-app").WithReference(loanDb);


builder.Build().Run();
