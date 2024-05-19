namespace Okane.Application.Category;

// Fake DB Para probar el codigo
public class InMemoryCategoryRepository : ICategoryRepository
{
    private readonly List<Domain.Category> _categories = new();
    private int _nextId = 1;
    public Domain.Category Add(Domain.Category category)
    {
        category.Id = _nextId++;
        _categories.Add(category);
        return category;
    }
    public IEnumerable<Domain.Category> All()
    {
        return _categories;
    }
    public Domain.Category? ById(int id)
    {
        return _categories.FirstOrDefault(category => category.Id == id);
    }
}