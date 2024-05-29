using FluentResults;
using MediatR;
using Okane.Application.Results;

namespace Okane.Application.Categories.ById;

public class Handler : IRequestHandler<Request, Result<Response>>
{
    private readonly ICategoriesRepository _categories;

    public Handler(ICategoriesRepository categories) => 
        _categories = categories;

    public Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var category = _categories.ById(request.Id);

        if (category == null)
            return Task.FromResult(ErrorResult.RecordNotFound<Response>());
        
        return Task.FromResult(Result.Ok(Response.From(category)));
    }
}