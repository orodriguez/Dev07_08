using Okane.Application.Categories;
using Okane.Domain;

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

    public IExpenseResponse Handle(int id, UpdateExpenseRequest request)
    {
        var category = _categoriesRepository.ByName(request.CategoryName);
        
        var expense = new Expense
        {
            Amount = request.Amount,
            Category = category,
            Description = request.Description
        };
        
        var updatedExpense = _expensesRepository.Update(id, expense);

        if (updatedExpense == null)
            return new NotFoundResponse();
        
        return updatedExpense.ToExpenseResponse();
    }
}