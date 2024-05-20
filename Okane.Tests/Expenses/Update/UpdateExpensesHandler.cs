using Okane.Application;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;

namespace Okane.Tests.Expenses.Update;

public class UpdateExpensesHandler : AbstractHandlerTests
{
    public UpdateExpensesHandler()
    {
        CreateCategory(new("Food"));
        CreateCategory(new("Entertainment"));
    }

    [Fact]
    public void Valid()
    {
        var createdExpense = Assert.IsType<ExpenseResponse>(CreateExpense(new ValidCreateExpenseRequest()));

        var updatedExpense = Assert.IsType<ExpenseResponse>(UpdateExpense(createdExpense.Id, 
            new UpdateExpenseRequest(50, "Entertainment", "Movies")));
        
        Assert.Equal(1, createdExpense.Id);
        Assert.Equal(50, updatedExpense.Amount);
        Assert.Equal("Entertainment", updatedExpense.CategoryName);
        Assert.Equal("Movies", updatedExpense.Description);
    }
    
    [Fact]
    public void NotFound()
    {
        var response = UpdateExpense(-42, 
            new UpdateExpenseRequest(50, "Entertainment"));
        
        Assert.IsType<NotFoundResponse>(response);
    }
}