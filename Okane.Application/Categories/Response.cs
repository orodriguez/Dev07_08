using Okane.Application.Categories.Create;
using Okane.Application.Responses;
using Okane.Domain;

namespace Okane.Application.Categories;

public record Response(int Id, string Name) : ISuccessResponse, 
    ICreateCategoryResponse, IResponse
{
    public static Response From(Category category) => 
        new(category.Id, category.Name);
}