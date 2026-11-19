using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FleetMaintenance.Infrastructure.Persistence;

// Used only by the EF Core command line tools (for example to create migrations). It never opens a connection.
public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private const string DesignTimeConnectionString = "Host=localhost;Database=fleet_maintenance_design";

    public AppDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(DesignTimeConnectionString)
            .Options;

        return new AppDbContext(options);
    }
}
