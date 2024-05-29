using FluentResults;
using MediatR;
using Okane.Domain;

namespace Okane.Application.Categories.Create;

public record CreateCategoryRequest(string Name) : IRequest<Result<Response>>
{
    public Category ToCategory() => new() { Name = Name };
}