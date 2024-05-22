using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.WebApi.Security;

namespace Okane.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkaneWebApi(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<IPasswordHasher, BCryptPasswordHasher>();
        services.AddTransient<ITokenGenerator, JwtTokenGenerator>();
        return services;
    }
}