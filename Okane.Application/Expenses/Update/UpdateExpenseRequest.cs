using Okane.Domain;

namespace Okane.Application.Expenses.Update;

public record UpdateExpenseRequest(int Id, int Amount, string Category, string Description, DateTime CreationDate)
{
    public Expense ToExpense() =>
        new()
        {
            Id = Id,
            Amount = Amount,
            Category = Category,
            Description = Description,
            CreationDate = CreationDate
        };
}