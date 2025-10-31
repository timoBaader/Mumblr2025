using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumblr.Abstractions.Users;
using Mumblr.Identity.Domain.Users;
using Mumblr.SharedKernel.Primitives;

namespace Mumblr.Identity.Application.Users.Commands;

public sealed class RegisterUser
{
    public string UserName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}

public sealed class RegisterUserHandler
{
    private readonly IUserRepository _users;

    public RegisterUserHandler(IUserRepository users) => _users = users;

    public async Task<Result> Handle(RegisterUser cmd, CancellationToken ct = default)
    {
        // Just a placeholder for now (no validation/hash yet)
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = cmd.UserName,
            Email = cmd.Email
        };
        await _users.AddAsync(user, ct);
        return Result.Ok();
    }
}
