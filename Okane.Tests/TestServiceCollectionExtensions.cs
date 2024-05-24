using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Auth;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.Tests.Mocks;

namespace Okane.Tests;

public static class TestServiceCollectionExtensions
{
    public static IServiceCollection AddOkaneTestDoubles(this IServiceCollection services, Func<DateTime> getCurrentTime)
    {
        services.AddTransient<Func<DateTime>>(_ => getCurrentTime);
        services.AddScoped<PasswordHasherMock>();
        services.AddTransient<IPasswordHasher>(provider => provider.GetRequiredService<PasswordHasherMock>().Object);
        services.AddScoped<TokenGeneratorMock>();
        services.AddTransient<ITokenGenerator>(provider => provider.GetRequiredService<TokenGeneratorMock>().Object);
        services.AddSingleton<FakeUserSession>();
        services.AddTransient<IUserSession, FakeUserSession>(provider => provider.GetRequiredService<FakeUserSession>());
        return services;
    }
}