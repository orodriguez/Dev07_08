
using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IExpensesRepository
{
    // Will use Expense class Variables on Okane.Domain 
    // Search By ID 
    Expense GetById(int id);
    Expense Add(Expense expense);
    IEnumerable<Expense> All();
}