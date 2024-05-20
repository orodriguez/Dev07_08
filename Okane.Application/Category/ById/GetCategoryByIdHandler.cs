namespace Okane.Application.Category.ById;

public class GetCategoryByIdHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository) => 
        _categoryRepository = categoryRepository;

    public ICategoryResponse Handle(int id)
    {
        var expense = _categoryRepository
            .ById(id);

        if (expense == null)
            return new NotFoundResponseCategory();
        
        return expense.ToCategoryResponse();
    }
}