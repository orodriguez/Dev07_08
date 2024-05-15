using Okane.Application.Expenses;
using Okane.Application.Expenses.Update;

namespace Okane.Tests.Expenses.Update;

public class HandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        var createdExpense = Assert.IsType<SuccessResponse>(CreateExpense(new ValidRequest()));

        var updatedExpense = Assert.IsType<SuccessResponse>(UpdateExpense(
            new Request(createdExpense.Id, 50, "Entertainment", "Movies")));
        
        Assert.Equal(1, createdExpense.Id);
        Assert.Equal(50, updatedExpense.Amount);
        Assert.Equal("Entertainment", updatedExpense.Category);
        Assert.Equal("Movies", updatedExpense.Description);
    }
}