using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnusualBackend.Models.Auth;
using UnusualBackend.Models.UsersSettings;

namespace UnusualBackend.Services.Auth;

public class MainDbContext(DbContextOptions<MainDbContext> options) : IdentityDbContext<User, IdentityRole<int>, int>
{
    public DbSet<UserFilters> UserFilters { get; set; }
}