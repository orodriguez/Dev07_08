using Microsoft.EntityFrameworkCore;
using Okane.Application.Budget;
using Okane.Domain;

namespace Okane.Storage.EF;

public class BudgetsRepository : IBudgetRepository
{
    private readonly OkaneDbContext _db;
    public BudgetsRepository(OkaneDbContext db) => _db = db;

    public void Add(Budget budget)
    {
        _db.Budgets.Add(budget);
        _db.SaveChanges();
        //  throw new NotImplementedException();
    }

    public Budget? GetByCategoryId(int categoryId) =>
        _db.Budgets.FirstOrDefault(b => b.CategoryId == categoryId);

    public IEnumerable<Budget> All() =>
        _db.Budgets.Include(b => b.Category).ToList();
}