using Okane.Application.Expenses;
using Okane.Application.Responses;

namespace Okane.Application.Categories.RetrieveByCategory;

public class RetrieveExpensesByCategoryHandler
{
    private readonly ICategoriesRepository _categories;
    private readonly IExpensesRepository _expenses;

    public RetrieveExpensesByCategoryHandler(
        ICategoriesRepository categories,
        IExpensesRepository expenses)
    {
        _categories = categories;
        _expenses = expenses;
    }

    public IRetrieveExpensesByCategoryResponse Handle(int id)
    {
        var category = _categories.ById(id);

        if (category == null)
            return new NotFoundResponse();

        var expenses = _expenses
            .All()
            .Where(c => c.Category.Id == id)
            .Select(expense => expense.ToExpenseResponse())
            .ToList();

        return new RetrieveExpensesByCategoryResponse(expenses);
    }
    
}
