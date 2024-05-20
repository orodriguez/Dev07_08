using Okane.Application.Categories.Update;
using Okane.Domain;

namespace Okane.Application.Categories;

public static class CategoryExtensions
{
    public static CategoryResponse ToResults(this Category category) =>
        new(category.Id, category.Name);

    public static void Update(this Category category, UpdateCategoryRequest request) =>
        category.Name = request.Name;

}