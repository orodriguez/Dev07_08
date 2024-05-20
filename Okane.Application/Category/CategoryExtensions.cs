namespace Okane.Application.Category;

// Check
public static class CategoryExtensions
{
    public static CategorySuccessResponse ToCategoryResponse(this Domain.Category category) =>
        new(category.Id, category.Name);
}