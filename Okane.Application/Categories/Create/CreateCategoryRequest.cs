using MediatR;
using Okane.Domain;

namespace Okane.Application.Categories.Create;

public record CreateCategoryRequest(string Name) : IRequest<ICreateCategoryResponse>
{
    public Category ToCategory() => 
        new() { Name = Name };
}