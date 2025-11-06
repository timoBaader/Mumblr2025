using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Mumblr.Abstractions.Security;

namespace Mumblr.Identity.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DebugController : ControllerBase
{
    [HttpPost("hash")]
    public IActionResult Hash([FromServices] IPasswordHasher hasher, [FromBody] HashRequest body)
    {
        if (string.IsNullOrWhiteSpace(body.Password))
            return BadRequest(new { error = "Password is required." });

        var hash = hasher.Hash(body.Password);
        var ok = hasher.Verify(body.Password, hash);

        return Ok(new { hash, ok });
    }

    public sealed class HashRequest
    {
        public string Password { get; init; } = string.Empty;
    }
}
