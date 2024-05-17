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

    public bool Update(int id, Expense expense) => 
        _db.SaveChanges() > 0;

    public bool Delete(Expense expense)
    {
        _db.Expenses.Remove(expense);
        return _db.SaveChanges() > 0;
    }
}