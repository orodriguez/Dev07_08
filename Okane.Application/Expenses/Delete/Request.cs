using FluentResults;
using MediatR;

namespace Okane.Application.Expenses.Delete;

public record Request(int Id) : IRequest<Result<Response>>;