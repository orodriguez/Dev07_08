using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Expenses;

namespace Okane.Application;

public static class ServiceCollectionExtensions
{
    public static void AddOkane(this IServiceCollection services)
    {
        services.AddTransient<Expenses.Create.Handler>();
        services.AddTransient<Expenses.Retrieve.Handler>();
        services.AddSingleton<IExpensesRepository, InMemoryRepository>();
        services.AddTransient<IValidator<Expenses.Create.Request>, Expenses.Create.Validator>();
    }
}