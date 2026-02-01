using DesafioSpedy.Domain.Authorization;
using DesafioSpedy.Infrastructure.Poco;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioSpedy.Infrastructure.Crypto;

public class JwtGenerator : IJwtGenerator
{
    private readonly JwtSettings _jwtSecrets;
    public JwtGenerator(IOptions<JwtSettings> jwtSecrets)
    {
        _jwtSecrets = jwtSecrets.Value;
    }

    public string GenerateToken(Guid userId, string userName, string userEmail)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecrets.Secret));
        var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("idUsuario", userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userEmail),
            new Claim(JwtRegisteredClaimNames.Name, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSecrets.ExpiresInMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
