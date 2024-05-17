using Okane.Application;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Delete;

namespace Okane.Tests.Expenses.Delete;

public class DeleteExpenseHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        var createdExpense = Assert.IsType<SuccessResponse>(CreateExpense(new ValidCreateExpenseRequest()));

        var deletedExpense = Assert.IsType<SuccessResponse>(DeleteExpense(createdExpense.Id));
        
        Assert.Equal(1, createdExpense.Id);
        Assert.Equal(10, deletedExpense.Amount);
        Assert.Equal("Food", deletedExpense.Category);
        Assert.Equal("Pizza", deletedExpense.Description);

    }
    
    [Fact]
    public void Expense_NotExists()
    {
        const int unknownId = 42;

        Assert.IsType<NotFoundResponse>(DeleteExpense(unknownId));
    }
}