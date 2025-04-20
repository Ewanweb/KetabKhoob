using System.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Shop.Api.Infrastructure.JWTUtil
{
    public static class AddJwtAuthentication
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"] ?? throw new NoNullAllowedException("signingKey cant be null"))),
                        ValidIssuer = configuration["JwtConfig:Issuer"] ?? throw new NoNullAllowedException("issuerKey cant be null"),
                        ValidAudience = configuration["JwtConfig:Audience"] ?? throw new NoNullAllowedException("audience cant be null"),
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true
                    };
                    options.SaveToken = true;
                });
        }
    }
}
