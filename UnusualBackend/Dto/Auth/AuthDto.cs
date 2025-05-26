namespace UnusualBackend.Dto.Auth;

public record LoginDto(string Email, string Password);

public record RegisterDto(string UserName, string Email, string Password);

public record TokenPair(string Token, string RefreshToken);

public record AuthDto(int Id, string Username, string Email, string Token, string RefreshToken):TokenPair(Token, RefreshToken);

