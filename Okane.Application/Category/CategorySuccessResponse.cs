namespace Okane.Application.Category;

public record CategorySuccessResponse (int Id, string Name) : ICategoryResponse
{
    public static CategorySuccessResponse From(Domain.Category category)
    {
        return new CategorySuccessResponse(category.Id, category.Name);
    }
}