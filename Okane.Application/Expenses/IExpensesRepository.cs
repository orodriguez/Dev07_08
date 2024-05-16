using Okane.Application.Expenses.Update;
using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IExpensesRepository
{
    Expense Add(Expense expense);
    IEnumerable<Expense> All();
    Expense? ById(int id);
    // For the Interface Update
    void Update(Expense expense);
    // For the Interface DeleteExpense
    void Delete(int id);
}