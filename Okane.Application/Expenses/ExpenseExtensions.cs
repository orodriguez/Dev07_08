using Okane.Domain;

namespace Okane.Application.Expenses;

public static class ExpenseExtensions
{
    public static SuccessExpenseResponse ToExpenseResponse(this Expense expense) => 
        new(expense.Id, expense.Amount, expense.Category, expense.Description, expense.CreatedAt);
}