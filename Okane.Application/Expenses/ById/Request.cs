using FluentResults;
using MediatR;

namespace Okane.Application.Expenses.ById;

public record Request(int Id) : IRequest<Result<Response>>;