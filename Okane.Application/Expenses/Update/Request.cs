using FluentResults;
using MediatR;

namespace Okane.Application.Expenses.Update;

public record Request(int Id, int Amount, string CategoryName, string? Description = null)
    : IRequest<Result<Response>>;