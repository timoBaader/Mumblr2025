using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Mumblr.Messaging.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get() => Ok(new { status = "ok", service = "messaging" });

    [HttpGet("version")]
    public IActionResult Version()
    {
        var ver = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0";
        return Ok(new { service = "messaging", version = ver });
    }
}
