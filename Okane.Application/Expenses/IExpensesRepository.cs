using Okane.Application.Expenses.Update;
using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IExpensesRepository
{
    Expense Add(Expense expense);
    Expense Update(Expense expense);
    void Delete(int id);
    IEnumerable<Expense> All();
    Expense? ById(int id);
}