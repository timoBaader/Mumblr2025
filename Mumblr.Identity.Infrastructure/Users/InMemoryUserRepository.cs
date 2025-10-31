using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumblr.Abstractions.Users;
using Mumblr.Identity.Domain.Users;

namespace Mumblr.Identity.Infrastructure.Users;

public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly ConcurrentDictionary<string, User> _byName =
        new(StringComparer.OrdinalIgnoreCase);

    public Task<User?> GetByUserNameAsync(string userName, CancellationToken ct = default) =>
        Task.FromResult(_byName.TryGetValue(userName, out var u) ? u : null);

    public Task AddAsync(User user, CancellationToken ct = default)
    {
        _byName[user.UserName] = user;
        return Task.CompletedTask;
    }
}
