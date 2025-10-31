using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumblr.Identity.Domain.Users;

namespace Mumblr.Abstractions.Users;

public interface IUserRepository
{
    Task<User?> GetByUserNameAsync(string userName, CancellationToken ct = default);
    Task AddAsync(User user, CancellationToken ct = default);
}
