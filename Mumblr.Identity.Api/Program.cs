using Microsoft.EntityFrameworkCore;
using Mumblr.Abstractions.Users;
using Mumblr.Identity.Infrastructure.Db;
using Mumblr.Identity.Infrastructure.Users;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration.GetConnectionString("IdentityDb");
builder.Services.AddDbContext<IdentityDbContext>(opts => opts.UseNpgsql(cs));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, EfUserRepository>();

var app = builder.Build();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
