using Microsoft.AspNetCore.Identity;

namespace UnusualBackend.Models.Auth;

public class User : IdentityUser<int>
{
    public List<RefreshToken> RefreshTokens { get; set; } = [];
}