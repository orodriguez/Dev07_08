namespace Okane.Tests.Expenses.ById;

public class HandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Exists()
    {
        var createdExpense = CreateExpense(new(20, "Games"));

        var retrievedExpense = GetExpenseById(createdExpense.Id);
        
        Assert.Equal(createdExpense.Id, retrievedExpense.Id);
        Assert.Equal(createdExpense.Amount, retrievedExpense.Amount);
        Assert.Equal(createdExpense.Category, retrievedExpense.Category);
        Assert.Equal(createdExpense.Description, retrievedExpense.Description);
    }
}