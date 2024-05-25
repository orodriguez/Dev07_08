using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;

namespace Okane.Tests.Expenses.Delete;

public class DeleteExpenseHandlerTests : AbstractHandlerTests
{
    public DeleteExpenseHandlerTests()
    {
        Handle(new CreateCategoryRequest("Games"));
    }

    [Fact]
    public void Exists()
    {
        var createResponse = Assert.IsType<ExpenseResponse>(
            Handle(new CreateExpenseRequest(20, "Games")));

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