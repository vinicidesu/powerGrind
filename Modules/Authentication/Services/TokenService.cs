using Microsoft.IdentityModel.Tokens;
using powerGrind.Modules.Authentication.Interfaces;
using powerGrind.Modules.Users.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace powerGrind.Modules.Authentication.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            string userSecrets = _configuration["Jwt:SecretKey"];
            byte[] toBytes = Encoding.UTF8.GetBytes(userSecrets);

            var symmetricSecurityKey = new SymmetricSecurityKey(toBytes);
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: credentials);
            var handler = new JwtSecurityTokenHandler();


            return handler.WriteToken(token);
        }
    }
}
