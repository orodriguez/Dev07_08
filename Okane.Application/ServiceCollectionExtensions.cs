// DependencyInjection for containing dependencies
using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;

namespace Okane.Application;

// My Container for ServiceCollections
public static class ServiceCollectionExtensions
{
    // Using interface IServiceCollection
    public static void AddOkane(this IServiceCollection services)
    {
        /* As a transient service it will use a new instance of Handler each time que sea requerido
          cada componente que requiera a Handler recibe una instancia indpendiente con su respectivo estado 
          cada ves que sea referenciado */
        services.AddTransient<Handler>();
        // Usamos una nueva instancia que mantiene su estado de Retrieve Handler   cada ves que sea referenciado
        services.AddTransient<Okane.Application.Expenses.Retrieve.Handler>();
        // Crea una sola instancia de IExpensesRepository And InMemoryRepository durante la vida entera de la app
        services.AddSingleton<IExpensesRepository, InMemoryRepository>();
    }
}