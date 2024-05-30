using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;
using Okane.Application.Results;
using Request = Okane.Application.Expenses.Create.Request;

namespace Okane.Tests.Expenses.ById;

public class GetExpenseByIdHandlerTests : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        await App.Categories.Create("Food");
        await App.Categories.Create("Entertainment");
        await App.Categories.Create("Games");
    }

    [Fact]
    public async Task Exists()
    {
        var expense = await App.Expenses.Create(new (20, "Games"));
        
        var retrievedExpense = await App.Expenses.GetById(expense.Id);
        
        Assert.Equal(expense.Id, retrievedExpense.Id);
        Assert.Equal(expense.Amount, retrievedExpense.Amount);
        Assert.Equal(expense.CategoryName, retrievedExpense.CategoryName);
        Assert.Equal(expense.Description, retrievedExpense.Description);
    }

    [Fact]
    public async Task NotFound()
    {
        var result = await App.Expenses.TryGetById(-1);

        Assert.Single(result.Errors.OfType<RecordNotFoundError>());
    }

    [Fact]
    public async Task AfterUpdate()
    {
        var createdExpense = await App.Expenses.TryCreate(10, "Food", "Pizza").AssertSuccess();

        await App.Expenses.TryUpdate(new(
            Id: createdExpense.Id, 
            Amount: 50, 
            CategoryName: "Entertainment", 
            Description: "Movies"));
        
        var expense = (await App.Expenses.TryGetById(createdExpense.Id)).Value;
        
        Assert.Equal(50, expense.Amount);
        Assert.Equal("Entertainment", expense.CategoryName);
        Assert.Equal("Movies", expense.Description);
    }

    public Task DisposeAsync() => 
        Task.CompletedTask;
}