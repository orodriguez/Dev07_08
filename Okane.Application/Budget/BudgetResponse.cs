using Okane.Application.Budget.Create;
using Okane.Application.Responses;

namespace Okane.Application.Budget;

public record BudgetResponse(int CategoryId, int Maximum) : ISuccessResponse,
    ICreateBudgetResponse
{
    public static  BudgetResponse From(Domain.Budget budget) => 
        new(budget.CategoryId ,budget.Maximum);
}


    
    