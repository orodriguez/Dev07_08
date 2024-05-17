using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Expenses;

namespace Okane.Storage.EF;

public static class ServiceCollectionExtensions
{
    public static void AddOkaneEFStorage(this IServiceCollection services)
    {
        services.AddDbContext<OkaneDbContext>(options => 
            options.UseNpgsql("Host=localhost;Port=5432;Database=OkaneDev;Username=postgres;Password=1234;"));
        
        services.AddTransient<IExpensesRepository, ExpensesRepository>();
    }
}