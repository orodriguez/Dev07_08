using Okane.Application.Expenses.Update;
using Okane.Domain;

namespace Okane.Application.Expenses;

public class InMemoryExpensesRepository : IExpensesRepository
{
    private int _nextId = 1;
    private readonly List<Expense> _expenses;

    public InMemoryExpensesRepository() => _expenses = new List<Expense>();

    public Expense Add(Expense expense)
    {
        expense.Id = _nextId++;
        _expenses.Add(expense);
        return expense;
    }

    public IEnumerable<Expense> All() => 
        _expenses;

    public Expense? ById(int id) => 
        _expenses.Find(expense => expense.Id == id);

    public bool Update(Expense expense) => true;

    public bool Delete(Expense expense) => 
        _expenses.Remove(expense);

    public IEnumerable<Expense> ByUserId(int userId) => 
        _expenses.Where(expense => expense.UserId == userId);

    public IEnumerable<Expense> BetweenDates(DateTime fromDate, DateTime toDate)
    {
        throw new NotImplementedException();
    }
}