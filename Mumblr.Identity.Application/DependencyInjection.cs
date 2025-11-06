using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Mumblr.Identity.Application;

public static class DependencyInjection
{
    // ⬇️ 'this' makes it an *extension method* on IServiceCollection
    public static IServiceCollection AddIdentityApplication(this IServiceCollection services)
    {
        // Register Application-layer services (internal implementations allowed here)
        services.AddScoped<Users.Commands.IRegisterUser, Users.Commands.RegisterUser>();

        // Return the same IServiceCollection so calls can be chained in Program.cs
        return services;
    }
}
