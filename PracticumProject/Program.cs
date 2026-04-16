using PracticumProject.Components;
using PracticumProject.Data;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.AddNpgsqlDbContext<AppDbContext>("loan-db");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/openapi/v1.json", "Loan API v1");
        options.RoutePrefix = "swagger";
    });
}

app.MapDefaultEndpoints();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/test-loan", () => "Loan System Active");

app.Run();