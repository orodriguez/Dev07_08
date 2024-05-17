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
        _expenses.FirstOrDefault(expense => expense.Id == id);

    public bool Update(int id, Expense request) => true;

    public bool Delete(Expense expenseToDelete) => 
        _expenses.Remove(expenseToDelete);
}