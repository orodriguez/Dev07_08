using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Auth;
using Okane.Application.Categories;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;

namespace Okane.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkane(this IServiceCollection services)
    {
        services.AddTransient<App>();
        services.AddHandlers();
        services.AddTransient<AuthService>();
        services.AddTransient<ExpensesService>();
        services.AddTransient<ExpenseFactory>();
        services.AddTransient<IValidator<CreateExpenseRequest>, Validator>();
        services.AddTransient<Func<DateTime>>(_ => () => DateTime.Now);

        return services;
    }

    public static IServiceCollection AddOkaneInMemoryStorage(this IServiceCollection services)
    {
        services.AddSingleton<IExpensesRepository, InMemoryExpensesRepository>();
        services.AddTransient<IReadOnlyExpensesRepository>(provider => provider.GetRequiredService<IExpensesRepository>());
        services.AddSingleton<ICategoriesRepository, InMemoryCategoriesRepository>();
        services.AddSingleton<IUsersRepository, InMemoryUsersRepository>();
        return services;
    }

    private static void AddHandlers(this IServiceCollection services) =>
        services.AddMediatR(
            configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
}