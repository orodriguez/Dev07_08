using Okane.Application.Responses;

namespace Okane.Application.Categories.Delete;

public class DeleteCategoryHandler
{
    private readonly ICategoriesRepository _categoriesRepository;

    public DeleteCategoryHandler(ICategoriesRepository categoriesRepository) =>
        _categoriesRepository = categoriesRepository;

    public IResponse Handle(int id)
    {
        var category = _categoriesRepository.ById(id);

        if (category == null)
            return new NotFoundResponse();

        _categoriesRepository.Delete(category);
        return category.ToResults();
    }
}