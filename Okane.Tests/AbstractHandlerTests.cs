using Microsoft.Extensions.DependencyInjection;
using Okane.Application;
using Okane.Application.Common.Responses;
using Okane.Application.Expenses;

namespace Okane.Tests;

public abstract class AbstractHandlerTests
{
    private readonly ServiceProvider _provider;

    protected AbstractHandlerTests()
    {
        var services = new ServiceCollection();
        
        services.AddOkane();

        _provider = services.BuildServiceProvider();
    }

    protected IEnumerable<Response> RetrieveExpenses() => 
        Resolve<Application.Expenses.Retrieve.Handler>().Handle();

    protected IResponse CreateExpense(Application.Expenses.Create.Request request) =>
        Resolve<Application.Expenses.Create.Handler>().Handle(request);

    private T Resolve<T>() where T : notnull =>
        _provider.GetRequiredService<T>();
}