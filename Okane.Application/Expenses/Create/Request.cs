using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public record Request(int Amount, string Category, string? Description = null)
{
    public Expense ToExpense() =>
        new()
        {
            Amount = Amount,
            Category = Category,
            Description = Description
        };
}