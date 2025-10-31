using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumblr.Identity.Domain.Users;

public class User
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
}
