using FluentResults;
using MediatR;

namespace Okane.Application.Categories;

public class CategoriesService
{
    private readonly IMediator _mediator;

    public CategoriesService(IMediator mediator) => _mediator = mediator;

    public Task<Result<Response>> Create(string name) => 
        _mediator.Send(new Create.CreateCategoryRequest(name));

    public Task<Result<Response>> ById(int id) => 
        _mediator.Send(new ById.Request(id));

    public Task<Result<Response>> Delete(int id) => 
        _mediator.Send(new Delete.Request(id));
}