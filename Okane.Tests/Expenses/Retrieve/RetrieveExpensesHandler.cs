namespace Okane.Tests.Expenses.Retrieve;

public class RetrieveExpensesHandler : AbstractHandlerTests
{
    [Fact]
    public void NoExpenses() => 
        Assert.Empty(RetrieveExpenses());

    [Fact]
    public void OneExpenses()
    {
        CreateExpense(new(10, "Food", null));

        var expense = Assert.Single(RetrieveExpenses());
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Food", expense.Category);
    }

    [Fact]
    public void ManyExpenses()
    {
        CreateExpense(new(10, "Food", "Eggs"));
        CreateExpense(new(20, "Games", "GTA"));
        
        var response = RetrieveExpenses();
        
        Assert.Equal(2, response.Count());
    }
}