using Microsoft.Extensions.DependencyInjection;
using Okane.Application;
using Okane.Application.Expenses;

namespace Okane.Tests
{
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

        protected Response CreateExpense(Application.Expenses.Create.Request request) =>
            Resolve<Application.Expenses.Create.Handler>().Handle(request);

        protected Response GetExpenseById(int id) => 
            Resolve<Application.Expenses.ById.Handler>().Handle(id);

        private T Resolve<T>() where T : notnull =>
            _provider.GetRequiredService<T>();
    }
}