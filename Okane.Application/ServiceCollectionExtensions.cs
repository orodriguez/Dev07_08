using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Category;
using Okane.Application.Category.Create;
using Okane.Application.Expenses;

namespace Okane.Application;

public static class ServiceCollectionExtensions
{
    public static void AddOkane(this IServiceCollection services)
    {
        services.AddHandlers();
        services.AddTransient<IValidator<Expenses.Create.CreateExpenseRequest>, Expenses.Create.Validator>();
        services.AddSingleton<IExpensesRepository, InMemoryRepository>();
        // Category 
        services.AddTransient<IValidator<CreateCategoryRequest>, CreateCategoryRequestValidator>();
        services.AddSingleton<ICategoryRepository, InMemoryCategoryRepository>();
    }

    private static void AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<Expenses.Create.CreateExpenseHandler>();
        services.AddTransient<Expenses.Retrieve.RetrieveExpensesHandler>();
        services.AddTransient<Expenses.ById.GetExpenseByIdHandler>();
        services.AddTransient<Expenses.Update.UpdateExpenseHandler>();
        // Check
        services.AddTransient<CreateCategoryHandler>();
        // GetByID
        services.AddTransient<Category.ById.GetCategoryByIdHandler>();
    }
}