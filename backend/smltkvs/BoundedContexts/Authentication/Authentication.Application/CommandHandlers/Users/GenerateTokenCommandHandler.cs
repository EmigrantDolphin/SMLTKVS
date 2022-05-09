using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Application.Commands.Users;
using Authentication.Application.Commands.Users.ResponseDtos;
using Authentication.Application.Options;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Application.CommandHandlers.Users;

public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, GeneratedTokenDto>
{
    private readonly JwtTokenConfiguration _jwtTokenConfig;
    private readonly byte[] _secret;

    public GenerateTokenCommandHandler(JwtTokenConfiguration jwtTokenConfig)
    {
        _jwtTokenConfig = jwtTokenConfig;
        _secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);
    }

    public Task<GeneratedTokenDto> Handle(GenerateTokenCommand command, CancellationToken cancellationToken)
    {
        var claims = new []
        {
            new Claim(ClaimTypes.Name, command.Username),
            new Claim(ClaimTypes.Role, command.Role.ToString()),
            new Claim("UserId", value: command.UserId.ToString())
        };

        var newToken = GenerateAccessToken(claims, DateTime.Now);
        return Task.FromResult(new GeneratedTokenDto(newToken));
    }

    private string GenerateAccessToken(Claim[] claims, DateTime now)
    {
        var jwtToken = new JwtSecurityToken(
            _jwtTokenConfig.Issuer,
            _jwtTokenConfig.Audience,
            claims,
            expires: now.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return accessToken;
    }
}