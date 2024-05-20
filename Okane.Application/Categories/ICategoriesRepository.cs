using Okane.Domain;

namespace Okane.Application.Categories;

public interface ICategoriesRepository
{
    Category ByName(string categoryName);
    Category Add(Category category);
    IEnumerable<Category> All();
    bool Update(Category category);
    bool Delete(Category category);
    Category? ById(int id);
}