using Microsoft.AspNetCore.Mvc.Testing;

namespace FleetMaintenance.IntegrationTests.Api;

public sealed class ProgramTests
{
    [Fact]
    public void Startup_FailsWhenConnectionStringIsMissing()
    {
        using var factory = new WebApplicationFactory<Program>();

        var exception = Assert.ThrowsAny<Exception>(() => factory.Server);

        Assert.Contains("Connection string 'Default' is not configured.", exception.ToString(), StringComparison.Ordinal);
    }
}
