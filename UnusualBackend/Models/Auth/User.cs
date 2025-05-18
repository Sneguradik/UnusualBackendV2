using Microsoft.AspNetCore.Identity;

namespace UnusualBackend.Models.Auth;

public class User : IdentityUser<int>
{
    public RefreshToken? RefreshToken { get; set; } = new();
}