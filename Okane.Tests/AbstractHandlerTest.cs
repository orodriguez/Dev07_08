using Microsoft.Extensions.DependencyInjection;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;

namespace Okane.Tests;

public class AbstractHandlerTest
{
    private readonly ServiceProvider _provider;

    protected AbstractHandlerTest()
    {
        var services = new ServiceCollection();
        
        services.AddTransient<Handler>();
        services.AddTransient<Okane.Application.Expenses.Retrieve.Handler>();
        services.AddSingleton<IExpensesRepository, InMemoryRepository>();

        _provider = services.BuildServiceProvider();
    }

    protected IEnumerable<Response> RetrieveExpenses() => 
        Resolve<Application.Expenses.Retrieve.Handler>().Handle();

    protected Response CreateExpense(Request request) =>
        Resolve<Application.Expenses.Create.Handler>().Handle(request);

    private T Resolve<T>() where T : notnull =>
        _provider.GetRequiredService<T>();
}