using System.Security.AccessControl;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Auth;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.Application.Categories;
using Okane.Application.Categories.ById;
using Okane.Application.Categories.Create;
using Okane.Application.Categories.Delete;
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
        var l = new List<int>();
        services.AddHandlers();
        services.AddTransient<ExpenseFactory>();
        services.AddTransient<IValidator<Expenses.Create.CreateExpenseRequest>, Expenses.Create.Validator>();
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

    private static void AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<CreateExpenseHandler>();
        services.AddTransient<RetrieveExpensesHandler>();
        services.AddTransient<GetExpenseByIdHandler>();
        services.AddTransient<UpdateExpenseHandler>();
        services.AddTransient<DeleteExpenseHandler>();
        services.AddTransient<CreateCategoryHandler>();
        services.AddTransient<GetCategoryByIdHandler>();
        services.AddTransient<DeleteCategoryHandler>();
        services.AddTransient<IRequestHandler<SignUpRequest, ISignUpResponse>, SignUpHandler>();
        services.AddTransient<IRequestHandler<SignInRequest, ISignInResponse>, SignInHandler>();
    }
}