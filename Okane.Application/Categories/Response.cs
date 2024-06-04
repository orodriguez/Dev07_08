using Okane.Domain;

namespace Okane.Application.Categories;

public record Response(int Id, string Name)
{
    public static Response From(Category category) => 
        new(category.Id, category.Name);
}