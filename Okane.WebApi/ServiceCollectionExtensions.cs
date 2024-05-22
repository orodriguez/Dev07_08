using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.WebApi.Security;

namespace Okane.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkaneWebApi(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher, BCryptPasswordHasher>();
        services.AddTransient<ITokenGenerator, JwtTokenGenerator>();
        return services;
    }
}