using Okane.Application.Responses;

namespace Okane.Application.Categories.Delete;

public class DeleteCategoryHandler
{
    private readonly ICategoriesRepository _categories;

    public DeleteCategoryHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public IDeleteCategoryResponse Handle(int id)
    {
        var category = _categories.ById(id);

        if (category == null)
            return new NotFoundResponse();
        
        _categories.Delete(category);
        return CategoryResponse.From(category);
    }
}