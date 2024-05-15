using Okane.Application.Expenses;

namespace Okane.Tests.Expenses.Retrieve;

public class HandlerTestses : AbstractHandlerTests
{
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
        Assert.Equal("Food", expense.Category);
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
    public void ReturnCorrect()
    {
        CreateExpense(new(10, "Food"));
        CreateExpense(new(20, "Games"));
        CreateExpense(new(50, "Other"));
        var expense = RetrieveOneExpense("2");

        Assert.Equal(2, expense.Id);
        Assert.Equal(20, expense.Amount);
        Assert.Equal("Games", expense.Category);
    }
}