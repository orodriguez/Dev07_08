using Microsoft.EntityFrameworkCore;
using Okane.Application.Categories;
using Okane.Domain;

namespace Okane.Storage.EF;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly OkaneDbContext _db;

    public CategoriesRepository(OkaneDbContext db) => _db = db;

    public Category ByName(string categoryName) => 
        _db.Categories.First(c => c.Name == categoryName);

    public Category Add(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
        return category;
    }

    public IEnumerable<Category> All() =>
        _db.Categories;

    public bool Update(Category category) =>
        _db.SaveChanges() > 0;

    public bool Delete(Category category)
    {
        _db.Categories.Remove(category);
        return _db.SaveChanges() > 0;
    }

    public Category? ById(int id) =>
        _db.Categories
            .FirstOrDefault(category => category.Id == id);

}