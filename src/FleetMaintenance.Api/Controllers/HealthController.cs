using FleetMaintenance.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FleetMaintenance.Api.Controllers;

[ApiController]
[Route("health")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<HealthResponse> Get()
    {
        return Ok(new HealthResponse("Healthy"));
    }
}
