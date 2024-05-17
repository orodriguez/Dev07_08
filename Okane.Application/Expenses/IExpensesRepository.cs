using Okane.Application.Expenses.Update;
using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IExpensesRepository
{
    Expense Add(Expense expense);
    IEnumerable<Expense> All();
    void Delete(int id);
    Expense? ById(int id);
    object GetById(int identifier);
}