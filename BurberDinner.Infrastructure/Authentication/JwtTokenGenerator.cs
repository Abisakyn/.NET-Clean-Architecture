using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BurberDinner.Application.Common.Interfaces.Authentication;
using BurberDinner.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BurberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IjwtTokenGenerator
{
    private readonly JwtSettings _jwtsettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtSettings> jwtSOptions){
        _dateTimeProvider = dateTimeProvider;
        _jwtsettings= jwtSOptions.Value;
    }
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {   
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Secret!)),
            SecurityAlgorithms.HmacSha256,
            SecurityAlgorithms.HmacSha256Signature
        );
        var claims= new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,firstName ),
            new Claim(JwtRegisteredClaimNames.FamilyName,lastName ),
            new Claim(JwtRegisteredClaimNames.Jti, userId.ToString())
        };
        var securityToken = new JwtSecurityToken(
            issuer: _jwtsettings.Issuer,
            audience: _jwtsettings.Audience,
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtsettings.ExpiryInMinutes),
            signingCredentials:signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
        
    }
}
