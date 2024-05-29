using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Delete;
using Okane.Application.Results;
using Request = Okane.Application.Expenses.Create.Request;

namespace Okane.Tests.Expenses.Delete;

public class DeleteExpenseHandlerTests : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        await Handle(new Application.Categories.Create.Request("Games"));
    }

    [Fact]
    public async Task Exists()
    {
        var createResponse = Assert.IsType<Response>(
            await Handle(new Request(20, "Games")));

        var expense = (await Handle(new DeleteExpenseRequest(createResponse.Id))).Value;
        Assert.Equal("Games", expense.CategoryName);
    }

    [Fact]
    public async Task NotFound()
    {
        var result = await Handle(new DeleteExpenseRequest(-50));
        Assert.Single(result.Reasons.OfType<RecordNotFoundError>());
    }

    public Task DisposeAsync() => Task.CompletedTask;
}