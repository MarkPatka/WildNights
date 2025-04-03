
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WildNights.IdentityService.Application.Common.Interfaces.Authentication;
using WildNights.IdentityService.Domain.Entites;

namespace WildNights.IdentityService.Infrastructure.Authentication;

public class JwtTokenGenerator(IOptions<JwtSettings> settings) 
    : IJwtTokenGenerator
{
    private readonly JwtSettings _settings = settings.Value;

    public string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var signingCredentials = new SigningCredentials(
            key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret)), 
            algorithm: SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
            issuer: _settings.Issuer,
            expires: DateTime.UtcNow.AddMinutes(_settings.Expires),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
