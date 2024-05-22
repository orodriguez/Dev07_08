using Okane.Application.Responses;

namespace Okane.Application.Categories.ById;

public class GetCategoryByIdHandler
{
    private readonly ICategoriesRepository _categories;

    public GetCategoryByIdHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public IGetCategoryByIdResponse Handle(int id)
    {
        var category = _categories.ById(id);

        if (category == null)
            return new NotFoundResponse();
        
        return CategoryResponse.From(category);
    }
}