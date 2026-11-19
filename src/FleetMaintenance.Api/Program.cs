using FleetMaintenance.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Connection string 'Default' is not configured.");

builder.Services.AddControllers();
builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();

app.MapControllers();

app.Run();

// Makes the entry point visible to WebApplicationFactory in the integration tests.
public partial class Program;
