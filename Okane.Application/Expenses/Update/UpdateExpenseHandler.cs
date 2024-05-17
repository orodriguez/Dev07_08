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

        var existingExpense = _expensesRepository.ById(id);

        if (existingExpense == null)
            return new NotFoundResponse();
        
        existingExpense.Amount = expense.Amount;
        existingExpense.Category = expense.Category;
        existingExpense.Description = expense.Description;
        
        _expensesRepository.Update(id, expense);
        
        return existingExpense.ToExpenseResponse();
    }
}