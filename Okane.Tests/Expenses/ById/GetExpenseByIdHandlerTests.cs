using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;

namespace Okane.Tests.Expenses.ById;

public class GetExpenseByIdHandlerTests : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        await Handle(new CreateCategoryRequest("Food"));
        await Handle(new CreateCategoryRequest("Entertainment"));
        await Handle(new CreateCategoryRequest("Games"));
    }

    [Fact]
    public async Task Exists()
    {
        var expense = Assert.IsType<ExpenseResponse>(await Handle(new CreateExpenseRequest(20, "Games")));

        var retrievedExpense = Assert.IsType<ExpenseResponse>(await Handle(new GetExpenseByIdRequest(expense.Id)));
        
        Assert.Equal(expense.Id, retrievedExpense.Id);
        Assert.Equal(expense.Amount, retrievedExpense.Amount);
        Assert.Equal(expense.CategoryName, retrievedExpense.CategoryName);
        Assert.Equal(expense.Description, retrievedExpense.Description);
    }

    [Fact]
    public async Task NotFound()
    {
        const int unknownId = 42;
        Assert.IsType<NotFoundResponse>(await Handle(new GetExpenseByIdRequest(unknownId)));
    }

    [Fact]
    public async Task AfterUpdate()
    {
        var createdExpense = Assert.IsType<ExpenseResponse>(
            await Handle(new CreateExpenseRequest(10, "Food", "Pizza")));

        Assert.IsType<ExpenseResponse>(
            await Handle(new UpdateExpenseRequest(
                createdExpense.Id,
                50, 
                "Entertainment", 
                Description: "Movies")));
        
        var expense = Assert.IsType<ExpenseResponse>(await Handle(new GetExpenseByIdRequest(createdExpense.Id)));
        
        Assert.Equal(50, expense.Amount);
        Assert.Equal("Entertainment", expense.CategoryName);
        Assert.Equal("Movies", expense.Description);
    }

    public Task DisposeAsync() => 
        Task.CompletedTask;
}