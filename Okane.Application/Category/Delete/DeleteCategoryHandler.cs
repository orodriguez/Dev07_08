using Okane.Application.Expenses;

namespace Okane.Application.Category.Delete;

public class DeleteCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IExpensesRepository _expensesRepository;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository, IExpensesRepository expensesRepository)
    {
        _categoryRepository = categoryRepository;
        _expensesRepository = expensesRepository;
    }
    
    public ICategoryResponse Handle(int id)
    {
        var category = _categoryRepository.ById(id);
        if (category == null)
        {
            return new NotFoundResponseCategory();
        }

        if (_expensesRepository.HasExpensesForCategory(id))
        {
            return new ConflictResponse();
        }
        
        _categoryRepository.Delete(id);
        return category.ToCategoryResponse();
    }
}