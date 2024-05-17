using Okane.Application;
using Okane.Application.Expenses;

namespace Okane.Tests.Expenses.ById;

public class GetExpenseByIdHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Exists()
    {
        var expense = Assert.IsType<SuccessResponse>(CreateExpense(new(20, "Games")));

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
    
    [Fact]
    public void AfterUpdate()
    {
        var createdExpense = Assert.IsType<SuccessResponse>(CreateExpense(new ValidCreateExpenseRequest()));

        Assert.IsType<SuccessResponse>(
            UpdateExpense(new Application.Expenses.Update.UpdateExpenseRequest(
                createdExpense.Id,
                50, 
                "Entertainment", 
                Description: "Movies")));
        
        var expense = Assert.IsType<SuccessResponse>(GetExpenseById(createdExpense.Id));
        
        Assert.Equal(50, expense.Amount);
        Assert.Equal("Entertainment", expense.Category);
        Assert.Equal("Movies", expense.Description);
    }
}