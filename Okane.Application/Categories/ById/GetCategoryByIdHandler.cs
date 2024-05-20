using Okane.Application.Responses;

namespace Okane.Application.Categories.ById;

public class GetCategoryByIdHandler
{
    private readonly ICategoriesRepository _categoriesRepository;

    public GetCategoryByIdHandler(ICategoriesRepository categoriesRepository) => 
        _categoriesRepository = categoriesRepository;

    public IResponse Handle(int id)
    {
        var category = _categoriesRepository.ById(id);

        if (category == null)
            return new NotFoundResponse();
        
        return category.ToResults();
    }
}