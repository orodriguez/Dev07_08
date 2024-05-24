using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Delete;
using Okane.Application.Responses;

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

        var deleteResponse = await HandleAsync(new DeleteExpenseRequest(createResponse.Id));
        Assert.IsType<ExpenseResponse>(deleteResponse);
    }

    [Fact]
    public async Task NotFound()
    {
        var response = await HandleAsync(new DeleteExpenseRequest(-50));
        Assert.IsType<NotFoundResponse>(response);
    }

    public Task DisposeAsync() => Task.CompletedTask;
}