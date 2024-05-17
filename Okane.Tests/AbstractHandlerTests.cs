using Microsoft.Extensions.DependencyInjection;
using Okane.Application;
using Okane.Application.Expenses;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Retrieve;
using Okane.Application.Expenses.Update;

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

        protected IEnumerable<SuccessResponse> RetrieveExpenses() => 
            Resolve<RetrieveExpensesHandler>().Handle();

        protected IExpenseResponse CreateExpense(CreateExpenseRequest createExpenseRequest) =>
            Resolve<CreateExpenseHandler>().Handle(createExpenseRequest);

        protected IExpenseResponse GetExpenseById(int id) => 
            Resolve<GetExpenseByIdHandler>().Handle(id);

        protected IExpenseResponse UpdateExpense(int id, UpdateExpenseRequest updateExpenseRequest) => 
            Resolve<UpdateExpenseHandler>().Handle(id, updateExpenseRequest);

        private T Resolve<T>() where T : notnull =>
            _provider.GetRequiredService<T>();
    }
}