using Microsoft.EntityFrameworkCore;
using Okane.Application.Expenses;
using Okane.Domain;

namespace Okane.Storage.EF;

public class ExpensesRepository : IExpensesRepository
{
    private readonly OkaneDbContext _db;

    public ExpensesRepository(OkaneDbContext db) => _db = db;

    public Expense Add(Expense expense)
    {
        _db.Expenses.Add(expense);
        _db.SaveChanges();
        return expense;
    }

    public IEnumerable<Expense> All() => 
        _db.Expenses.Include(e => e.Category);

    public Expense? ById(int id) => 
        _db.Expenses.Include(e => e.Category).FirstOrDefault(expense => expense.Id == id);

    public Expense? Update(int id, Expense expense)
    {
        var existingExpense = ById(id);

        if (existingExpense == null)
            return null;
        
        existingExpense.Amount = expense.Amount;
        existingExpense.Category = expense.Category;
        existingExpense.Description = expense.Description;

        _db.SaveChanges();
        return existingExpense;
    }
}