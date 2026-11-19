using System.Net;
using System.Net.Http.Json;
using FleetMaintenance.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FleetMaintenance.IntegrationTests.Api.Controllers;

public sealed class HealthControllerTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task Get_ReturnsHealthyStatus()
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        using var client = factory.CreateClient();

        using var response = await client.GetAsync("/health", cancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadFromJsonAsync<HealthResponse>(cancellationToken);
        Assert.Equal(new HealthResponse("Healthy"), body);
    }
}
