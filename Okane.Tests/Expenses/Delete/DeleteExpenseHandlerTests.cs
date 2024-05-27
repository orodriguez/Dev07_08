using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Delete;
using Okane.Application.Results;

namespace Okane.Tests.Expenses.Delete;

public class DeleteExpenseHandlerTests : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        await HandleAsync(new CreateCategoryRequest("Games"));
    }

    [Fact]
    public async Task Exists()
    {
        var createResponse = Assert.IsType<ExpenseResponse>(
            await HandleAsync(new CreateExpenseRequest(20, "Games")));

        var expense = (await HandleAsync(new DeleteExpenseRequest(createResponse.Id))).Value;
        Assert.Equal("Games", expense.CategoryName);
    }

    [Fact]
    public async Task NotFound()
    {
        var result = await HandleAsync(new DeleteExpenseRequest(-50));
        Assert.Single(result.Reasons.OfType<RecordNotFoundError>());
    }

    public Task DisposeAsync() => Task.CompletedTask;
}