using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Mumblr.Abstractions.Security;
using Mumblr.Abstractions.Users;
using Mumblr.Identity.Infrastructure.Db;
using Mumblr.Identity.Infrastructure.Security;
using Mumblr.Identity.Infrastructure.Users;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration.GetConnectionString("IdentityDb");
builder.Services.AddDbContext<IdentityDbContext>(opts => opts.UseNpgsql(cs));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddHealthChecks().AddDbContextCheck<IdentityDbContext>("postgres-db");
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/health/live", () => Results.Ok(new { status = "ok" }));

app.MapHealthChecks(
    "/health/ready",
    new HealthCheckOptions
    {
        ResponseWriter = async (ctx, report) =>
        {
            var payload = new
            {
                status = report.Status.ToString(),
                checks = report.Entries.Select(e => new
                {
                    name = e.Key,
                    status = e.Value.Status.ToString(),
                    error = e.Value.Exception?.Message
                })
            };
            ctx.Response.ContentType = "application/json";
            await ctx.Response.WriteAsync(JsonSerializer.Serialize(payload));
        }
    }
);

app.Run();
