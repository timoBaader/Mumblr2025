using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumblr.Identity.Application.Users.Commands;

public interface IRegisterUser
{
    Task<Guid> Execute(string userName, string email, string password, CancellationToken ct);
}
