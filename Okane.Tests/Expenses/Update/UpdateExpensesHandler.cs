using Okane.Application.Results;

namespace Okane.Tests.Expenses.Update;

public class UpdateExpensesHandler : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        await App.Categories.Create(new("Food"));
        await App.Categories.Create(new("Entertainment"));
    }

    [Fact]
    public async Task Valid()
    {
        var createdExpense = await App.Expenses
            .Create(new(10, "Food", "Pizza"));

        var updatedExpense = await App.Expenses.Update(new(createdExpense.Id,
            50,
            "Entertainment",
            "Movies"));
        
        Assert.Equal(1, createdExpense.Id);
        Assert.Equal(50, updatedExpense.Amount);
        Assert.Equal("Entertainment", updatedExpense.CategoryName);
        Assert.Equal("Movies", updatedExpense.Description);
    }

    [Fact]
    public async Task NotFound()
    {
        var response = await App.Expenses.TryUpdate(
            new(-1, 50, "Entertainment"));
        
        Assert.Single(response.Errors.OfType<RecordNotFoundError>());
    }

    public Task DisposeAsync() => Task.CompletedTask;
}