using Okane.Domain;

namespace Okane.Application.Categories.Create;


public record CreateCategoryRequest(int Id, string CategoryName)
{
    public Category ToCategory() =>
        new()
        {
            Id = Id,
            Name = CategoryName
        };
}