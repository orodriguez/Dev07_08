using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;

namespace Okane.Application;

public static class ServiceCollectionExtensions
{
    public static void AddOkane(this IServiceCollection services)
    {
        services.AddTransient<Handler>();
        services.AddTransient<Okane.Application.Expenses.Retrieve.Handler>();
        services.AddSingleton<IExpensesRepository, InMemoryRepository>();
    }
}