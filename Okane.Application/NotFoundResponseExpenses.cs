using Okane.Application.Category;
using Okane.Application.Expenses;

namespace Okane.Application;

public record NotFoundResponseExpenses : IExpenseResponse;
// Me falta GetByID, implementare en los siguientes commits
public record NotFoundResponseCategory : ICategoryResponse;

