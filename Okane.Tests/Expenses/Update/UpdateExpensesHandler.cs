using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;

namespace Okane.Tests.Expenses.Update;

public class UpdateExpensesHandler : AbstractHandlerTests
{
    public UpdateExpensesHandler()
    {
        Handle(new CreateCategoryRequest("Food"));
        Handle(new CreateCategoryRequest("Entertainment"));
    }

    [Fact]
    public void Valid()
    {
        CreateExpenseRequest request = new ValidCreateExpenseRequest();
        var createdExpense = Assert.IsType<ExpenseResponse>(Handle(request));

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