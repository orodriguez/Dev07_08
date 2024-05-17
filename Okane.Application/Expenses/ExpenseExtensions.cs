using Okane.Domain;

namespace Okane.Application.Expenses;

public static class ExpenseExtensions
{
    public static SuccessResponse ToExpenseResponse(this Expense expense) => 
        new(expense.Id, expense.Amount, expense.Category, expense.CreationDate, expense.Description);
}