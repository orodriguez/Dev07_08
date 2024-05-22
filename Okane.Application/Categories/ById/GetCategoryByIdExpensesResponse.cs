using Okane.Application.Expenses;

namespace Okane.Application.Categories.ById;

public record GetCategoryByIdExpensesResponse(int Id, string Name, List<ExpenseResponse> Expenses)
    : IGetCategoryByIdExpensesResponse;