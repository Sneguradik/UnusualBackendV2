using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnusualBackend.Models.Auth;
using UnusualBackend.Models.UsersSettings;

namespace UnusualBackend.Services.Auth;

public class MainDbContext(DbContextOptions<MainDbContext> options) : IdentityDbContext<User, IdentityRole<int>, int>
{
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<UserFilters> UserFilters { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}