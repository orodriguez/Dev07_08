using Okane.Application.Category;
using Okane.Application.Expenses;

namespace Okane.Application;

public record NotFoundResponseExpenses : IExpenseResponse;
// Done / usando NotFoundResponseCategory 
public record NotFoundResponseCategory : ICategoryResponse;

