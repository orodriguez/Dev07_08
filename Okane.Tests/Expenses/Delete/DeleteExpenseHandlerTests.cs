using Okane.Application;
using Okane.Application.Expenses;

namespace Okane.Tests.Expenses.Delete;

public class DeleteExpenseHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Exists()
    {
        var createResponse = Assert.IsType<SuccessExpenseResponse>(
            CreateExpense(new(20, "Games")));

        var deleteResponse = DeleteExpense(createResponse.Id);
        Assert.IsType<SuccessExpenseResponse>(deleteResponse);
    }
    
    [Fact]
    public void NotFound()
    {
        var response = DeleteExpense(-50);
        Assert.IsType<NotFoundResponse>(response);
    }
}