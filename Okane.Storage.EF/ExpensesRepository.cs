using Okane.Application.Expenses;
using Okane.Application.Expenses.Update;
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
        _db.Expenses;

    public Expense? ById(int id) => 
        _db.Expenses.FirstOrDefault(expense => expense.Id == id);

    public Expense? Update(int id, UpdateExpenseRequest request)
    {
        var expense = ById(id);

        if (expense == null)
            return null;
        
        expense.Amount = request.Amount;
        expense.Category = request.Category;
        expense.Description = request.Description;

        _db.SaveChanges();
        return expense;
    }
}