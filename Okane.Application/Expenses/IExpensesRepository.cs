using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IExpensesRepository : IReadOnlyExpensesRepository
{
    Expense Add(Expense expense);
    bool Update(Expense expense);
    bool Delete(Expense expense);
}