using Okane.Application.Categories;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly ICategoriesRepository _categoriesRepository;

    public UpdateExpenseHandler(
        IExpensesRepository expensesRepository, 
        ICategoriesRepository categoriesRepository)
    {
        _expensesRepository = expensesRepository;
        _categoriesRepository = categoriesRepository;
    }

    public IResponse Handle(int id, UpdateExpenseRequest request)
    {
        var category = _categoriesRepository.ByName(request.CategoryName);

        if (category == null)
            throw new NotImplementedException();
        
        var existingExpense = _expensesRepository.ById(id);

        if (existingExpense == null)
            return new NotFoundResponse();

        existingExpense.Update(request, category);

        _expensesRepository.Update(existingExpense);
        
        return existingExpense.ToExpenseResponse();
    }
}