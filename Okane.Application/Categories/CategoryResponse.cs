using Okane.Application.Categories.ById;
using Okane.Application.Categories.Create;
using Okane.Application.Categories.Delete;
using Okane.Application.Categories.RetrieveByCategory;
using Okane.Application.Expenses;
using Okane.Application.Responses;
using Okane.Domain;

namespace Okane.Application.Categories;
public record CategoryResponse(int Id, string Name) : ISuccessResponse, 
    ICreateCategoryResponse, 
    IGetCategoryByIdResponse,
    IDeleteCategoryResponse,
    IRetrieveExpensesByCategoryResponse
{
    public static CategoryResponse From(Category category) => 
        new(category.Id, category.Name);
}