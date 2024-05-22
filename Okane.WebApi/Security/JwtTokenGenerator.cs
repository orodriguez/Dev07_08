using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Okane.Application.Auth.SignIn;
using Okane.Domain;

namespace Okane.WebApi.Security;

public class JwtTokenGenerator : ITokenGenerator
{
    public string Generate(User user)
    {
        var token = new JwtSecurityToken(
            issuer: "http://okane.com", 
            audience: "public", 
            expires: DateTime.UtcNow.AddMinutes(20),
            claims: Claims(user),
            signingCredentials: SigningCredentials());
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static SigningCredentials SigningCredentials()
    {
        var secret = "Super secret key, it must be long enough to work";
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        return credentials;
    }

    private static Claim[] Claims(User user)
    {
        Claim[] claims =
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        return claims;
    }
}