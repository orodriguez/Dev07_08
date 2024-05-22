using Microsoft.Extensions.DependencyInjection;
using Moq;
using Okane.Application;
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

namespace Okane.Tests
{
    public abstract class AbstractHandlerTests
    {
        private readonly ServiceProvider _provider;
        protected DateTime Now { get; set; }
        protected Mock<IPasswordHasher> PasswordHasherMock { get; }

        protected AbstractHandlerTests()
        {
            Now = DateTime.Parse("2024-01-01");
            
            var services = new ServiceCollection();
        
            services.AddOkane().AddOkaneInMemoryStorage();
            
            services.AddTransient<Func<DateTime>>(_ => () => Now);
            
            PasswordHasherMock = new Mock<IPasswordHasher>(MockBehavior.Strict);
            
            services.AddTransient<IPasswordHasher>(_ => PasswordHasherMock.Object);

            _provider = services.BuildServiceProvider();
        }

        protected IEnumerable<ExpenseResponse> RetrieveExpenses() => 
            Resolve<RetrieveExpensesHandler>().Handle();

        protected ICreateExpenseResponse CreateExpense(CreateExpenseRequest createExpenseRequest) =>
            Resolve<CreateExpenseHandler>().Handle(createExpenseRequest);

        protected IResponse GetExpenseById(int id) => 
            Resolve<GetExpenseByIdHandler>().Handle(id);

        protected IResponse UpdateExpense(int id, UpdateExpenseRequest updateExpenseRequest) => 
            Resolve<UpdateExpenseHandler>().Handle(id, updateExpenseRequest);

        protected IResponse DeleteExpense(int id) => 
            Resolve<DeleteExpenseHandler>().Handle(id);

        protected ICreateCategoryResponse CreateCategory(CreateCategoryRequest request) => 
            Resolve<CreateCategoryHandler>().Handle(request);

        protected IGetCategoryByIdResponse GetCategoryById(int id) => 
            Resolve<GetCategoryByIdHandler>().Handle(id);

        protected IDeleteCategoryResponse DeleteCategory(int id) => 
            Resolve<DeleteCategoryHandler>().Handle(id);

        protected ISignUpResponse SignUp(SignUpRequest request) => 
            Resolve<IRequestHandler<SignUpRequest, ISignUpResponse>>().Handle(request);

        private T Resolve<T>() where T : notnull =>
            _provider.GetRequiredService<T>();
    }
}