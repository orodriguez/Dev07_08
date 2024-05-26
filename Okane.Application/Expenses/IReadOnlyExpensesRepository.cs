using Okane.Domain;

namespace Okane.Application.Expenses;

public interface IReadOnlyExpensesRepository
{
    IEnumerable<Expense> All();
    Expense? ById(int id);
    IEnumerable<Expense> ByUserId(int userId);
    IEnumerable<Expense> BetweenDates(DateTime fromDate, DateTime toDate);
}