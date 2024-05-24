using Okane.Application.Auth;

namespace Okane.Tests.Expenses.Retrieve;

public class RetrieveExpensesHandlerTests : AbstractHandlerTests
{
    public RetrieveExpensesHandlerTests()
    {
        CurrentUserId = Assert.IsType<UserResponse>(
            SignUpUser(new("user1@mail.com", "1234"))).Id;
        
        CreateCategory(new("Food"));
        CreateCategory(new("Games"));
    }

    [Fact]
    public void NoExpenses() => 
        Assert.Empty(RetrieveExpenses());

    [Fact]
    public void OneExpenses()
    {
        CreateExpense(new(10, "Food"));

        var expense = Assert.Single(RetrieveExpenses());
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Food", expense.CategoryName);
    }

    [Fact]
    public void ManyExpenses()
    {
        CreateExpense(new(10, "Food"));
        CreateExpense(new(20, "Games"));
        
        var response = RetrieveExpenses();
        
        Assert.Equal(2, response.Count());
    }
    
    [Fact]
    public void ExpensesFromAnotherUser()
    {
        CreateExpense(new(10, "Food"));
        
        
        CurrentUserId = Assert.IsType<UserResponse>(
            SignUpUser(new("user2@mail.com", "1234"))).Id;

        CreateExpense(new(20, "Games"));
        
        var response = RetrieveExpenses();
        
        var expense = Assert.Single(response);
        Assert.Equal("Games", expense.CategoryName);
    }
}