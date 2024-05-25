using Okane.Application.Auth;
using Okane.Application.Auth.Signup;
using Okane.Application.Categories.Create;
using Okane.Application.Expenses.Create;

namespace Okane.Tests.Expenses.Retrieve;

public class RetrieveExpensesHandlerTests : AbstractHandlerTests
{
    public RetrieveExpensesHandlerTests()
    {
        CurrentUserId = Assert.IsType<UserResponse>(
            Handle(new SignUpRequest("user1@mail.com", "1234"))).Id;
        
        Handle(new CreateCategoryRequest("Food"));
        Handle(new CreateCategoryRequest("Games"));
    }

    [Fact]
    public void NoExpenses() => 
        Assert.Empty(RetrieveExpenses());

    [Fact]
    public void OneExpenses()
    {
        Handle(new CreateExpenseRequest(10, "Food"));

        var expense = Assert.Single(RetrieveExpenses());
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Food", expense.CategoryName);
    }

    [Fact]
    public void ManyExpenses()
    {
        Handle(new CreateExpenseRequest(10, "Food"));
        Handle(new CreateExpenseRequest(20, "Games"));
        
        var response = RetrieveExpenses();
        
        Assert.Equal(2, response.Count());
    }
    
    [Fact]
    public void ExpensesFromAnotherUser()
    {
        Handle(new CreateExpenseRequest(10, "Food"));
        
        
        CurrentUserId = Assert.IsType<UserResponse>(
            Handle(new SignUpRequest("user2@mail.com", "1234"))).Id;

        Handle(new CreateExpenseRequest(20, "Games"));
        
        var response = RetrieveExpenses();
        
        var expense = Assert.Single(response);
        Assert.Equal("Games", expense.CategoryName);
    }
}