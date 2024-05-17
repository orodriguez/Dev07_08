using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IExpensesRepository
{
    Expense Add(Expense expense);
    IEnumerable<Expense> All();
    Expense? ById(int id);
    Expense? Update(int id, Expense expense);
    bool Delete(Expense expense);
}