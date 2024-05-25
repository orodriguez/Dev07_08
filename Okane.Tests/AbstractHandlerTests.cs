using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Okane.Application;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Okane.Application.Categories.ById;
using Okane.Application.Categories.Create;
using Okane.Application.Categories.Delete;
using Okane.Application.Expenses;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Delete;
using Okane.Application.Expenses.Retrieve;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;
using Okane.Tests.Mocks;

namespace Okane.Tests
{   
    public abstract class AbstractHandlerTests
    {
        private readonly ServiceProvider _provider;
        protected DateTime Now { get; set; }
        protected Mock<IPasswordHasher> PasswordHasherMock => Resolve<PasswordHasherMock>();

        protected AbstractHandlerTests()
        {
            Now = DateTime.Parse("2024-01-01", new CultureInfo("es-US"));
            
            var services = new ServiceCollection();
            
            services.AddOkane()
                .AddOkaneInMemoryStorage()
                .AddOkaneTestDoubles(() => Now);
            
            _provider = services.BuildServiceProvider();
        }

        protected int CurrentUserId
        {
            get => Resolve<FakeUserSession>().CurrentUserId;
            set => Resolve<FakeUserSession>().CurrentUserId = value;
        }

        protected IEnumerable<ExpenseResponse> RetrieveExpenses() => 
            Resolve<RetrieveExpensesHandler>().Handle();

        protected IResponse GetExpenseById(int id) => 
            Resolve<GetExpenseByIdHandler>().Handle(id);

        protected IResponse UpdateExpense(int id, UpdateExpenseRequest updateExpenseRequest) => 
            Resolve<UpdateExpenseHandler>().Handle(id, updateExpenseRequest);

        protected IResponse DeleteExpense(int id) => 
            Resolve<DeleteExpenseHandler>().Handle(id);

        protected IGetCategoryByIdResponse GetCategoryById(int id) => 
            Resolve<GetCategoryByIdHandler>().Handle(id);

        protected IDeleteCategoryResponse DeleteCategory(int id) => 
            Resolve<DeleteCategoryHandler>().Handle(id);
        protected IResponse Handle<TRequest>(TRequest request) => 
            Resolve<IRequestHandler<TRequest, IResponse>>().Handle(request);

        protected ISignInResponse SignInUser(SignInRequest request) => 
            Resolve<IRequestHandler<SignInRequest, ISignInResponse>>().Handle(request);

        private T Resolve<T>() where T : notnull =>
            _provider.GetRequiredService<T>();
    }
}