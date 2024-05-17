using Okane.Application;
using Okane.Application.Expenses;
using Okane.Application.Responses;

namespace Okane.Tests.Expenses.Delete;

public class DeleteExpenseHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Exists()
    {
        var createResponse = Assert.IsType<ExpenseResponse>(
            CreateExpense(new(20, "Games")));

        var deleteResponse = DeleteExpense(createResponse.Id);
        Assert.IsType<ExpenseResponse>(deleteResponse);
    }
    
    [Fact]
    public void NotFound()
    {
        var response = DeleteExpense(-50);
        Assert.IsType<NotFoundResponse>(response);
    }
}