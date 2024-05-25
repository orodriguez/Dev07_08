using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;

namespace Okane.Tests.Expenses.ById;

public class GetExpenseByIdHandlerTests : AbstractHandlerTests
{
    public GetExpenseByIdHandlerTests()
    {
        Handle(new CreateCategoryRequest("Food"));
        Handle(new CreateCategoryRequest("Entertainment"));
        Handle(new CreateCategoryRequest("Games"));
    }

    [Fact]
    public void Exists()
    {
        var expense = Assert.IsType<ExpenseResponse>(Handle(new CreateExpenseRequest(20, "Games")));

        var retrievedExpense = Assert.IsType<ExpenseResponse>(GetExpenseById(expense.Id));
        
        Assert.Equal(expense.Id, retrievedExpense.Id);
        Assert.Equal(expense.Amount, retrievedExpense.Amount);
        Assert.Equal(expense.CategoryName, retrievedExpense.CategoryName);
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
        CreateExpenseRequest validCreateExpenseRequest = new ValidCreateExpenseRequest();
        var createdExpense = Assert.IsType<ExpenseResponse>(Handle(validCreateExpenseRequest));

        Assert.IsType<ExpenseResponse>(
            UpdateExpense(createdExpense.Id, new UpdateExpenseRequest(
                50, 
                "Entertainment", 
                Description: "Movies")));
        
        var expense = Assert.IsType<ExpenseResponse>(GetExpenseById(createdExpense.Id));
        
        Assert.Equal(50, expense.Amount);
        Assert.Equal("Entertainment", expense.CategoryName);
        Assert.Equal("Movies", expense.Description);
    }
}