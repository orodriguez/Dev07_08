using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.Configuration;
using Microsoft.IdentityModel.Tokens;
using Okane.Application.Auth;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.WebApi.Security;

namespace Okane.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkaneWebApi(this IServiceCollection services,
        IConfigurationManager configuration)
    {
        var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
        if (jwtSettings == null)
            throw new InvalidConfigurationException("Unable to read Jwt settings from config");

        // TODO: Research and implement refresh token and token rotation
        // TODO: Research a Identity
        services.AddAuthorization();
        services.AddAuthentication(Configure).AddJwtBearer(options => options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(jwtSettings.Secret))
            });
        services.AddHttpContextAccessor();
        services.AddTransient<IUserSession, HttpContextUserSession>();
        services.AddTransient<IPasswordHasher, BCryptPasswordHasher>();
        services.AddTransient<ITokenGenerator, JwtTokenGenerator>();
        return services;
    }

    private static void Configure(AuthenticationOptions options)
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
}

public record JwtSettings(string Issuer, string Audience, string Secret);