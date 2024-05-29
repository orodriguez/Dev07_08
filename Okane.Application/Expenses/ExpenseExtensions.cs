using Okane.Application.Expenses.Update;
using Okane.Domain;

namespace Okane.Application.Expenses;

public static class ExpenseExtensions
{
    public static Response ToExpenseResponse(this Expense expense) => 
        new(expense.Id, expense.Amount, expense.Category.Name, expense.Description, expense.CreatedAt);
    
    public static void Update(this Expense expense, UpdateExpenseRequest request, Category category)
    {
        expense.Amount = request.Amount;
        expense.Category = category;
        expense.Description = request.Description;
    }
}