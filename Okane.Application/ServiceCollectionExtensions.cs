using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Expenses;

namespace Okane.Application;

public static class ServiceCollectionExtensions
{
    public static void AddOkane(this IServiceCollection services)
    {
        services.AddHandlers();
        services.AddTransient<IValidator<Expenses.Create.CreateExpenseRequest>, Expenses.Create.Validator>();
        services.AddSingleton<IExpensesRepository, InMemoryRepository>();
    }

    private static void AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<Expenses.Create.CreateExpenseHandler>();
        services.AddTransient<Expenses.Retrieve.RetrieveExpensesHandler>();
        services.AddTransient<Expenses.ById.GetExpenseByIdHandler>();
        services.AddTransient<Expenses.Update.UpdateExpenseHandler>();
        services.AddTransient<Expenses.Delete.DeleteExpenseHandler>();
    }
}