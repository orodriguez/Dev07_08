using MediatR;

namespace Okane.Application.Expenses.ById;

public record GetExpenseByIdRequest(int Id) : IRequest<IGetExpenseByIdResponse>;