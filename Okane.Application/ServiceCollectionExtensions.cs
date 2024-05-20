using System.Security.AccessControl;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Categories;
using Okane.Application.Categories.ById;
using Okane.Application.Categories.Create;
using Okane.Application.Categories.Delete;
using Okane.Application.Categories.Retrieve;
using Okane.Application.Categories.Update;
using Okane.Application.Expenses;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Delete;
using Okane.Application.Expenses.Retrieve;
using Okane.Application.Expenses.Update;

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
        services.AddTransient<CreateExpenseHandler>();
        services.AddTransient<RetrieveExpensesHandler>();
        services.AddTransient<GetExpenseByIdHandler>();
        services.AddTransient<UpdateExpenseHandler>();
        services.AddTransient<DeleteExpenseHandler>();
        
        services.AddTransient<CreateCategoryHandler>();
        services.AddTransient<RetrieveCategoriesHandler>();
        services.AddTransient<GetCategoryByIdHandler>();
        services.AddTransient<UpdateCategoryHandler>();
        services.AddTransient<DeleteCategoryHandler>();
    }
}