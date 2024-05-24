using MediatR;

namespace Okane.Application.Expenses.Update;

public record UpdateExpenseRequest(int Id, int Amount, string CategoryName, string? Description = null)
    : IRequest<IUpdateExpenseResponse>;