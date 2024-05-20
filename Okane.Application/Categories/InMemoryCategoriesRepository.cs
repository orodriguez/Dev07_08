using Okane.Domain;

namespace Okane.Application.Categories;

public class InMemoryCategoriesRepository : ICategoriesRepository
{
    private readonly IList<Category> _categories;
    private int _nextId = 1;

    public InMemoryCategoriesRepository() => 
        _categories = new List<Category>();

    public Category ByName(string categoryName) => 
        _categories.First(c => c.Name == categoryName);

    public Category? ById(int id) =>
        _categories.FirstOrDefault(category => category.Id == id);

    public IEnumerable<Category> All() =>
        _categories;

    public bool Update(Category category) => true;
    
    public bool Delete(Category category) => 
        _categories.Remove(category);
    
    public Category Add(Category category)
    {
        category.Id = _nextId++;
        _categories.Add(category);
        return category;
    }
}