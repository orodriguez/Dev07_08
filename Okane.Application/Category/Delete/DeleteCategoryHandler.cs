namespace Okane.Application.Category.Delete;

public class DeleteCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository) =>
        _categoryRepository = categoryRepository;

    public ICategoryResponse Handle(int id)
    {
        var expense = _categoryRepository.ById(id);
        if (expense == null)
        {
            return new NotFoundResponseCategory();
        }

        _categoryRepository.Delete(id);
        return expense.ToCategoryResponse();
    }
}