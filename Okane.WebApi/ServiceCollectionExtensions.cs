using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Okane.Application.Auth;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.WebApi.Security;

namespace Okane.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkaneWebApi(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication(Configure).AddJwtBearer(Configure);
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

    private static void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://okane.com",
            ValidAudience = "public",
            // TODO: Extract secret to file
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes("Super secret key, it must be long enough to work"))
        };
    }
}