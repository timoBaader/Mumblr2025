using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Mumblr.Friendship.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get() => Ok(new { status = "ok", service = "friendship" });

    [HttpGet("version")]
    public IActionResult Version()
    {
        var ver = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0";
        return Ok(new { service = "friendship", version = ver });
    }
