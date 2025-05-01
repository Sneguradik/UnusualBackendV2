using System.Security.Claims;
using System.Security.Cryptography;
using UnusualBackend.Models.Auth;

namespace UnusualBackend.Services.Auth;

public class JwtService
{
    public IEnumerable<Claim> GetClaims(User user)
    {

    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}