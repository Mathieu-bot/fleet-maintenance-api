using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FleetMaintenance.IntegrationTests;

// No test talks to the database yet, so the connection string only has to exist.
public sealed class ApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("ConnectionStrings:Default", "Host=localhost;Database=fleet_maintenance_tests");
    }
}
