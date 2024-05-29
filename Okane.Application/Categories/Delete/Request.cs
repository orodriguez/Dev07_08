using FluentResults;
using MediatR;

namespace Okane.Application.Categories.Delete;

public record Request(int Id) : IRequest<Result<Response>>;