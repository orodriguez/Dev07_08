using FluentResults;
using MediatR;

namespace Okane.Application.Expenses.Delete;

public record DeleteExpenseRequest(int Id) : IRequest<Result<Response>>;