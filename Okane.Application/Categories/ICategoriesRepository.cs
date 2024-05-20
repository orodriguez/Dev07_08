using Okane.Domain;

namespace Okane.Application.Categories;

public interface ICategoriesRepository
{
    Category ByName(string categoryName);
    Category Add(Category category);
    Category? ById(int id);
    bool NameExists(string name);
    bool Delete(Category category);
}