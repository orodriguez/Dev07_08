using Okane.Application.Expenses;
using Okane.Application.Responses;
using Okane.Domain;

namespace Okane.Application.Categories.RetrieveByCategory;

public interface IRetrieveExpensesByCategoryResponse : IResponse
{
}
public record RetrieveExpensesByCategoryResponse(List<ExpenseResponse> Expenses) : IRetrieveExpensesByCategoryResponse
{
    public List<ExpenseResponse> Expenses { get; set; } = Expenses;
}