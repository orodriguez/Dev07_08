using Okane.Application.Budget.Create;
using Okane.Application.Responses;

namespace Okane.Application.Budget;

public record BudgetResponse(int CategoryId, int Maximum) : ISuccessResponse,
    ICreateBudgetResponse;