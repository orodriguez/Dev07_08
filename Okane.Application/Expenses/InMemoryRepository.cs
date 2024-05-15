using Okane.Domain;

namespace Okane.Application.Expenses;

// Implementamos IExpensesRepository interface
public class InMemoryRepository : IExpensesRepository
{
    private int _nextId = 1;
    private readonly List<Expense> _expenses;
    public InMemoryRepository() => _expenses = new List<Expense>();
    
    public Expense Add(Expense expense)
    {
        expense.Id = _nextId++;
        _expenses.Add(expense);
        return expense;
    }
    // Retrive All
    public IEnumerable<Expense> All() =>
        _expenses;
    public Expense GetById(int id) => _expenses.FirstOrDefault(expense => expense.Id == id);
}