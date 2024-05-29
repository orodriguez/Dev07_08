using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;
using Request = Okane.Application.Expenses.Create.Request;

namespace Okane.Tests.Expenses.Update;

public class UpdateExpensesHandler : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        await Handle(new Application.Categories.Create.Request("Food"));
        await Handle(new Application.Categories.Create.Request("Entertainment"));
    }

    [Fact]
    public async Task Valid()
    {
        var createdExpense = Assert.IsType<Response>(
            await Handle(new Request(10, "Food", "Pizza")));

        var updatedExpense = Assert.IsType<Response>(await Handle(new UpdateExpenseRequest(
            createdExpense.Id, 
            50, 
            "Entertainment", 
            "Movies")));
        
        Assert.Equal(1, createdExpense.Id);
        Assert.Equal(50, updatedExpense.Amount);
        Assert.Equal("Entertainment", updatedExpense.CategoryName);
        Assert.Equal("Movies", updatedExpense.Description);
    }

    [Fact]
    public async Task NotFound()
    {
        var response = await Handle(new UpdateExpenseRequest(-1, 50, "Entertainment"));
        
        Assert.IsType<NotFoundResponse>(response);
    }

    public Task DisposeAsync() => Task.CompletedTask;
}