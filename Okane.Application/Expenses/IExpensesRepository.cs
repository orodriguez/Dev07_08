using Okane.Application.Expenses.Create;
using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IExpensesRepository
{
    Expense Add(Expense expense);
    IEnumerable<Expense> All();
    object GetById(int expenseId);
}