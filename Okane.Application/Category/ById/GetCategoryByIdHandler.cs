namespace Okane.Application.Category.ById;

public class GetCategoryByIdHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository) => 
        _categoryRepository = categoryRepository;

    public ICategoryResponse Handle(int id)
    {
        var category = _categoryRepository
            .ById(id);

        if (category == null)
            return new NotFoundResponseCategory();
        
        return category.ToCategoryResponse();
    }
}