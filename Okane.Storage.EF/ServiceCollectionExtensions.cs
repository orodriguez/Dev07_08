using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Auth;
using Okane.Application.Budget;
using Okane.Application.Budget.Create;
using Okane.Application.Categories;
using Okane.Application.Expenses;

namespace Okane.Storage.EF;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkaneEFStorage(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<OkaneDbContext>(options => options.UseNpgsql(connectionString));
        services.AddTransient<IExpensesRepository, ExpensesRepository>();
        services.AddTransient<IReadOnlyExpensesRepository, ExpensesRepository>();
        services.AddTransient<ICategoriesRepository, CategoriesRepository>();
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<IBudgetRepository, BudgetsRepository>();
        services.AddTransient<IValidator<CreateBudgetRequest>, BudgetValidator>();
        return services;
    }
}