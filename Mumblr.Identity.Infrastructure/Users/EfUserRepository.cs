using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mumblr.Abstractions.Users;
using Mumblr.Identity.Domain.Users;
using Mumblr.Identity.Infrastructure.Db;

namespace Mumblr.Identity.Infrastructure.Users;

public sealed class EfUserRepository(IdentityDbContext db) : IUserRepository
{
    public Task<User?> GetByUserNameAsync(string userName, CancellationToken ct = default) =>
        db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName, ct);

    public async Task AddAsync(User user, CancellationToken ct = default)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync(ct);
    }
}
