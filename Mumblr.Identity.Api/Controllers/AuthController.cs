using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Mumblr.Identity.Application.Users.Commands;

namespace Mumblr.Identity.Api.Controllers;

[ApiController]
[Route("auth")]
public sealed class AuthController : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUser service,
        [FromBody] RegisterRequest body,
        CancellationToken ct
    )
    {
        // If your service is already implemented, use it:
        // var id = await service.Execute(body.Email, body.UserName, body.Password, ct);
        // return StatusCode(StatusCodes.Status201Created, new RegisterResponse(id));

        // Until the service logic is wired, keep the stub:
        return StatusCode(501, new { message = "Registration not implemented yet." });
    }
}

public sealed record RegisterRequest(string Email, string UserName, string Password);

public sealed record RegisterResponse(Guid Id);
