using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mumblr.Abstractions.Security;
using Mumblr.Abstractions.Users;
using Mumblr.Identity.Domain.Users;
using Mumblr.SharedKernel.Primitives;

namespace Mumblr.Identity.Application.Users.Commands;

internal sealed partial class RegisterUser : IRegisterUser
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _hasher;

    public RegisterUser(IUserRepository users, IPasswordHasher hasher)
    {
        _users = users;
        _hasher = hasher;
    }

    public sealed class RegisterValidationException : Exception
    {
        public RegisterValidationException(string message)
            : base(message) { }
    }

    public Task<Guid> Execute(string userName, string email, string password, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(email) || !EmailRx().IsMatch(email))
            throw new RegisterValidationException("Invalid email format.");

        if (string.IsNullOrWhiteSpace(userName) || userName.Length < 3 || userName.Length > 32)
            throw new RegisterValidationException("Username must be 3–32 characters.");

        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new RegisterValidationException("Password must be at least 8 characters.");

        return Task.FromResult(Guid.NewGuid());
    }

    [GeneratedRegex(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant
    )]
    private static partial Regex EmailRx();
}
