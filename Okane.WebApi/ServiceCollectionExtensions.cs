using Okane.Application.Auth.Signup;
using Okane.WebApi.Security;

namespace Okane.WebApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkaneWebApi(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher, BCryptPasswordHasher>();
        return services;
    }
}