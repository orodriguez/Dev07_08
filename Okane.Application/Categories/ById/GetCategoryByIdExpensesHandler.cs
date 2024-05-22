using Okane.Application.Expenses;
using Okane.Application.Responses;

namespace Okane.Application.Categories.ById;

public class GetCategoryByIdExpensesHandler
{
    private readonly ICategoriesRepository _categories;

    public GetCategoryByIdExpensesHandler(ICategoriesRepository categories) =>
        _categories = categories;

    public IGetCategoryByIdExpensesResponse Handle(int categoryId)
    {
        var category = _categories.ById(categoryId);
        if (category == null)
            return new NotFoundResponse();

        var expenses = _categories.GetExpensesByCategoryId(categoryId)
            .Select(e => new ExpenseResponse(
                e.Id,
                e.Amount,
                category.Name,
                e.Description,
                e.CreatedAt
            )).ToList();

        return new GetCategoryByIdExpensesResponse(category.Id, category.Name, expenses);
    }
}