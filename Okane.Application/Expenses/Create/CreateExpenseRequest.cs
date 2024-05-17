using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public record CreateExpenseRequest(int Amount, string CategoryName, string? Description = null)
{
    public Expense ToExpense(Category category, DateTime createdAt) =>
        new()
        {
            Amount = Amount,
            Category = category,
            Description = Description,
            CreatedAt = createdAt
        };
}