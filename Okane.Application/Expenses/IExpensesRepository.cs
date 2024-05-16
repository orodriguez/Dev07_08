using Okane.Application.Expenses.Update;
using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IExpensesRepository
{
    Expense Add(Expense expense);
    IEnumerable<Expense> All();
    Expense? ById(int id);
    // For the Interface
    void Update(Expense expense);
}