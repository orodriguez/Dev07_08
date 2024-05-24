using MediatR;

namespace Okane.Application.Expenses.Retrieve;

public record RetrieveExpensesRequest : IRequest<RetrieveExpensesResponse>
{
}