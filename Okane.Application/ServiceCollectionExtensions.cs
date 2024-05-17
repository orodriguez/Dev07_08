using System.Security.AccessControl;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Categories;
using Okane.Application.Expenses;

namespace Okane.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkane(this IServiceCollection services)
    {
        services.AddHandlers();
        services.AddTransient<IValidator<Expenses.Create.CreateExpenseRequest>, Expenses.Create.Validator>();
        services.AddTransient<Func<DateTime>>(_ => () => DateTime.Now);

        return services;
    }

    public static void AddOkaneInMemoryStorage(this IServiceCollection services)
    {
        services.AddSingleton<IExpensesRepository, InMemoryExpensesRepository>();
        services.AddSingleton<ICategoriesRepository, InMemoryCategoriesRepository>();
    }

    private static void AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<Expenses.Create.CreateExpenseHandler>();
        services.AddTransient<Expenses.Retrieve.RetrieveExpensesHandler>();
        services.AddTransient<Expenses.ById.GetExpenseByIdHandler>();
        services.AddTransient<Expenses.Update.UpdateExpenseHandler>();
    }
}