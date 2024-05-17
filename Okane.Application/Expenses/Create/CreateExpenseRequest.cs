using Okane.Domain;

namespace Okane.Application.Expenses.Create
{
    public record CreateExpenseRequest(int Amount, string Category, DateTime CreationDate, string? Description = null)
    {
        public Expense ToExpense() =>
            new Expense
            {
                Amount = Amount,
                Category = Category,
                Description = Description,
                CreationDate = CreationDate
            };
    }
}
