using Okane.Application.Categories;
using Okane.Domain;

namespace Okane.Application.Balance;

public record BalanceResponse(CategoryResponse Category, int Maximum, int Expended, int Remaining)
{
    public static BalanceResponse From(Domain.Budget budget, Category? category, int expended)
    {
        var remaining = budget.Maximum - expended;
        return new BalanceResponse(CategoryResponse.From(budget.Category), budget.Maximum, expended, remaining);
    }
}