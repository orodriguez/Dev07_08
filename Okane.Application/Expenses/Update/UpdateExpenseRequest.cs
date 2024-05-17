using Okane.Domain;

namespace Okane.Application.Expenses.Update;

public record UpdateExpenseRequest(int Id, int Amount, string Category, string? Description = null)
{
    public void ToExpense(Expense expense)
    {
        expense.Amount = Amount;
        expense.Description = Description;
        expense.Category = Category;
    }
}