using Okane.Domain;

namespace Okane.Application.Categories.Create;

public record CreateCategoryRequest(string Name)
{
    public Category ToCategory() =>
        new Category
        {
            Name = Name
        };
}