using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mumblr.Identity.Domain.Users;

namespace Mumblr.Identity.Infrastructure.Db;

public sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.UserName).HasMaxLength(64).IsRequired();
            b.Property(x => x.Email).HasMaxLength(256).IsRequired();

            b.HasIndex(x => x.UserName).IsUnique();
            b.HasIndex(x => x.Email).IsUnique();
        });
    }
}
