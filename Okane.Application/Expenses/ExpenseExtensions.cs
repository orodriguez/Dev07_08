using Okane.Domain;

namespace Okane.Application.Expenses;

public static class ExpenseExtensions
{
    public static ExpensesSuccessResponse ToExpenseResponse(this Expense expense) => 
        new(expense.Id, expense.Amount, expense.Category, expense.Description);
}