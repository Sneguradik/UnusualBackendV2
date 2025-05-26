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
    public class AuthController(
        UserManager<User> userManager,
        IJwtService jwtService,
        MainDbContext context,
        ILogger<AuthController> logger) : ControllerBase
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

            await userManager.UpdateAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            
            return new TokenPair(jwtService.GenerateToken(user, roles.ToArray()), user.RefreshToken.Token);

        }
        
        [HttpPost("login")]
        public async Task<ActionResult<AuthDto>> Login([FromBody] LoginDto dto, CancellationToken token)
        {
            if (!ModelState.IsValid) return Problem(title: "Authorization error",
                detail: ModelState.ToString(), statusCode: StatusCodes.Status400BadRequest);
            
            logger.LogInformation($"{dto.Email} requested login");

            var user = await userManager.FindByEmailAsync(dto.Email);

            if (user == null) return Problem(
                "No user found",
                statusCode: StatusCodes.Status404NotFound,
                title: "Authorization error");

            if (!await userManager.CheckPasswordAsync(user, dto.Password)) return Problem(
                "Wrong password",
                statusCode: StatusCodes.Status401Unauthorized,
                title: "Authorization error");
            
            var tokenPair = await AuthenticateUser(user, token);
            return new AuthDto(user.Id, user.UserName!, user.Email!, tokenPair.Token, tokenPair.RefreshToken);
        }


        [HttpPost("register")]
        public async Task<ActionResult<AuthDto>> Register([FromBody] RegisterDto dto, CancellationToken token)
        {
            if (!ModelState.IsValid) return Problem(title: "Authorization error",
                detail: ModelState.ToString(), statusCode: StatusCodes.Status400BadRequest);

            var problemUser = await userManager.FindByEmailAsync(dto.Email);

            if (problemUser != null) return Problem(
                "User already exists",
                statusCode: StatusCodes.Status409Conflict,
                title: "Authorization error");
            
            var user = new User() {Email = dto.Email, UserName = dto.UserName};
            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded) return Problem(
                string.Join("\n", result.Errors.Select(e => e.Description)),
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Authorization error");
            
            user = await userManager.FindByEmailAsync(dto.Email);

            if (user is null) throw new Exception("User not found");
                
            await userManager.AddToRoleAsync(user, RolesConst.User);
            
            var tokenPair = await AuthenticateUser(user, token);
            
            return new AuthDto(user.Id, user.UserName!, user.Email!, tokenPair.Token, tokenPair.RefreshToken);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<TokenPair>> RefreshToken([FromBody] TokenPair tokenPair, CancellationToken token)
        {
            var user = await context.Users
                .Include(user => user.RefreshToken!)
                .FirstOrDefaultAsync(u => u.RefreshToken != null && u.RefreshToken.Token == tokenPair.Token,
                    cancellationToken: token);
            
            if (user == null) return Problem(
                "No user found",
                statusCode: StatusCodes.Status404NotFound,
                title: "Authorization error");

            if (user.RefreshToken!.Expires <= DateTime.UtcNow) return Problem(
                "Refresh token is expired",
                statusCode: StatusCodes.Status401Unauthorized,
                title: "Authorization error");
            
            var claims = jwtService.GetPrincipalFromExpiredToken(tokenPair.Token);
            var jwtToken = jwtService.GenerateToken(claims!.Claims);
            return new TokenPair(jwtToken, user.RefreshToken.Token);
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke([FromBody] TokenPair tokenPair, CancellationToken token)
        {
            var user = await context.Users
                .Include(user => user.RefreshToken!)
                .FirstOrDefaultAsync(u => u.RefreshToken != null && u.RefreshToken.Token == tokenPair.Token,
                    cancellationToken: token);
            
            if (user == null) return Problem(
                "No user found",
                statusCode: StatusCodes.Status404NotFound,
                title: "Authorization error");
            
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
            return Ok("Token revoked");
        }
        
        
    }
}
