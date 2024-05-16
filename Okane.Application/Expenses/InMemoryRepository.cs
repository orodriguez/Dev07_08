using Okane.Application.Expenses.Update;
using Okane.Domain;

namespace Okane.Application.Expenses;

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

    public IEnumerable<Expense> All() => 
        _expenses;

    public Expense? ById(int id) => 
        _expenses.FirstOrDefault(expense => expense.Id == id);
    
    
    // for memory db Update
    public void Update(Expense expense)
    {
        var existingExpense = _expenses.FirstOrDefault(e => e.Id == expense.Id);
        if (existingExpense != null)
        {
            existingExpense.Amount = expense.Amount;
            existingExpense.Category = expense.Category;
            existingExpense.Description = expense.Description;
        }
    }
    // For Delete xD
    public void Delete(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense != null)
        {
            _expenses.Remove(expense);
        }
    }
}