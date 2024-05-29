using FluentResults;
using MediatR;

namespace Okane.Application.Categories.ById;

public record Request(int Id) : IRequest<Result<Response>>;