using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public record CreateExpenseRequest(int Amount, string Category, string? Description = null)
{
    public Expense ToExpense() =>
        new()
        {
            Amount = Amount,
            Category = Category,
            Description = Description,
            CreationDate = DateTime.Now
        };
}