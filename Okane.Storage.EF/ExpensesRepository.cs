using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

    public IEnumerable<Expense> All() => IncludeCategories();

    public Expense? ById(int id) => 
        IncludeCategories().FirstOrDefault(expense => expense.Id == id);

    public bool Update(Expense expense) => 
        _db.SaveChanges() > 0;

    public bool Delete(Expense expense)
    {
        _db.Expenses.Remove(expense);
        return _db.SaveChanges() > 0;
    }

    public IEnumerable<Expense> ByUserId(int userId) => 
        IncludeCategories().Where(expense => expense.UserId == userId);

    private IIncludableQueryable<Expense, Category> IncludeCategories() => 
        _db.Expenses.Include(e => e.Category);
}