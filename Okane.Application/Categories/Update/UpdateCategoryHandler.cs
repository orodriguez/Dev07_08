using Okane.Application.Responses;

namespace Okane.Application.Categories.Update;

public class UpdateCategoryHandler
{
    private readonly ICategoriesRepository _categoriesRepository;

    public UpdateCategoryHandler(ICategoriesRepository categoriesRepository) =>
        _categoriesRepository = categoriesRepository;

    public IResponse Handle(int id, UpdateCategoryRequest request)
    {
        var category = _categoriesRepository.ById(id);

        if (category == null)
            return new NotFoundResponse();
        
        category.Update(request);

        _categoriesRepository.Update(category);

        return category.ToResults();
    }
}