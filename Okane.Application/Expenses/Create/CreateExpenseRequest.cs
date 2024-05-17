using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public record CreateExpenseRequest(int Amount, string Category, string? Description = null)
{
    public Expense ToExpense(DateTime createdAt) =>
        new()
        {
            Amount = Amount,
            Category = Category,
            Description = Description,
            CreatedAt = createdAt
        };
}