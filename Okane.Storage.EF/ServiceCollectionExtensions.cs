using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Auth;
using Okane.Application.Categories;
using Okane.Application.Expenses;

namespace Okane.Storage.EF;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOkaneEFStorage(this IServiceCollection services)
    {
        services.AddDbContext<OkaneDbContext>(options => 
            // TODO: Move this to config file
            options.UseNpgsql("Host=localhost;Port=5432;Database=OkaneDev;Username=postgres;Password=1234;"));
        
        services.AddTransient<IExpensesRepository, ExpensesRepository>();
        services.AddTransient<ICategoriesRepository, CategoriesRepository>();
        services.AddTransient<IUsersRepository, UsersRepository>();
        return services;
    }
}