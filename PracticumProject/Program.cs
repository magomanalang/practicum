using Aspire.Npgsql.EntityFrameworkCore.PostgreSQL;
using PracticumProject.Components;
using PracticumProject.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.AddNpgsqlDbContext<AppDbContext>("loan-db");

builder.Services.AddOpenApi();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Generates the spec at /openapi/v1.json

    // If you still want the Swagger UI look, this maps to the new spec
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Loan API v1");
    });
}

app.MapDefaultEndpoints();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();