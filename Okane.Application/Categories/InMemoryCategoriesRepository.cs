using Okane.Domain;

namespace Okane.Application.Categories;

public class InMemoryCategoriesRepository : ICategoriesRepository
{
    private readonly IList<Category> _categories;
    private readonly List<Expense> _expenses;

    private int _nextId = 1;

    public InMemoryCategoriesRepository()
    {
        _categories = new List<Category>();
        _expenses = new List<Expense>();
    }

    public Category? ByName(string categoryName) =>
        _categories.FirstOrDefault(c => c.Name == categoryName);

    public Category Add(Category category)
    {
        category.Id = _nextId++;
        _categories.Add(category);
        return category;
    }


    public IList<Expense> GetExpensesByCategoryId(int categoryId) =>
        _expenses.Where(e => e.CategoryId == categoryId).ToList();

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
    }

    public Category? ById(int id) =>
        _categories.FirstOrDefault(c => c.Id == id);

    public bool NameExists(string name) =>
        _categories.Any(c => c.Name == name);

    public bool Delete(Category category) =>
        _categories.Remove(category);
}