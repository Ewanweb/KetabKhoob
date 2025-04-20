using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Infrastructure.JWTUtil
{
    public class JwtTokenBuilder
    {
        public static string BuildToken(UserDto user, IConfiguration configuration)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var signInKey = configuration["JwtConfig:SignInKey"]
                            ?? throw new ArgumentNullException(nameof(configuration), "JwtConfig:SignInKey is missing from configuration.");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInKey));

            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credential
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
