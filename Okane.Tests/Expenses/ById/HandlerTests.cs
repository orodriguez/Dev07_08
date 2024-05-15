using Okane.Application;
using Okane.Application.Expenses;

namespace Okane.Tests.Expenses.ById;

public class HandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Exists()
    {
        var expense = CreateExpense(new(20, "Games"));

        var retrievedExpense = Assert.IsType<SuccessResponse>(GetExpenseById(expense.Id));
        
        Assert.Equal(expense.Id, retrievedExpense.Id);
        Assert.Equal(expense.Amount, retrievedExpense.Amount);
        Assert.Equal(expense.Category, retrievedExpense.Category);
        Assert.Equal(expense.Description, retrievedExpense.Description);
    }
    
    [Fact]
    public void NotFound()
    {
        const int unknownId = 42;
        Assert.IsType<NotFoundResponse>(GetExpenseById(unknownId));
    }
}