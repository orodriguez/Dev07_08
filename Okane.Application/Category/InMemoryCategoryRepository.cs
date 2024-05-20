namespace Okane.Application.Category;

// Check
public class InMemoryCategoryRepository : ICategoryRepository
{
    private int _nextId = 1;
    private readonly List<Domain.Category> _categories;

    public InMemoryCategoryRepository() => _categories = new List<Domain.Category>();

    public Domain.Category Add(Domain.Category category)
    {
        category.Id = _nextId++;
        _categories.Add(category);
        return category;
    }

    public IEnumerable<Domain.Category> All() => _categories;

    public Domain.Category? ById(int id) =>
        _categories.FirstOrDefault(category => category.Id == id);
}