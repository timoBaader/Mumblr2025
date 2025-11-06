using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumblr.Abstractions.Security;
using Mumblr.Abstractions.Users;
using Mumblr.Identity.Domain.Users;
using Mumblr.SharedKernel.Primitives;

namespace Mumblr.Identity.Application.Users.Commands;

internal sealed class RegisterUser : IRegisterUser
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _hasher;

    public RegisterUser(IUserRepository users, IPasswordHasher hasher)
    {
        _users = users;
        _hasher = hasher;
    }

    public Task<Guid> Execute(string userName, string email, string password, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
