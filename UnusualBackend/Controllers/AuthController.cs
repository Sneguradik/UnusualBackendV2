using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using UnusualBackend.Dto.Auth;
using UnusualBackend.Models.Auth;
using UnusualBackend.Services.Auth;

namespace UnusualBackend.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, IJwtService jwtService) : ControllerBase
    {
        private async Task<TokenPair> AuthenticateUser(User user, CancellationToken token)
        {
            if (user.RefreshToken is null || user.RefreshToken.Expires <= DateTime.UtcNow)
            {
                user.RefreshToken = new RefreshToken
                {
                    Token = jwtService.GenerateRefreshToken(),
                    Expires = DateTime.UtcNow
                };
            }
            userManager.
            
            
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<AuthDto>> Login([FromBody] LoginDto dto, CancellationToken token)
        {
            if (!ModelState.IsValid) return Problem(title: "Authorization error",
                detail: ModelState.ToString(), statusCode: StatusCodes.Status400BadRequest);

            var user = await userManager.FindByEmailAsync(dto.Email);

            if (user == null) return Problem(
                "No user found",
                statusCode: StatusCodes.Status404NotFound,
                title: "Authorization error");

            if (!await userManager.CheckPasswordAsync(user, dto.Password)) return Problem(
                "Wrong password",
                statusCode: StatusCodes.Status401Unauthorized,
                title: "Authorization error"
                );
            
            
            
        }

    }
}
