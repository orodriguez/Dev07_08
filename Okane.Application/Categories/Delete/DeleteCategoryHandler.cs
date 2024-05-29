using FluentResults;
using MediatR;
using Okane.Application.Results;

namespace Okane.Application.Categories.Delete;

public class DeleteCategoryHandler 
    : IRequestHandler<Request, Result<Response>>
{
    private readonly ICategoriesRepository _categories;

    public DeleteCategoryHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var category = _categories.ById(request.Id);

        if (category == null)
            return Task.FromResult(ErrorResult.RecordNotFound<Response>());
        
        _categories.Delete(category);
        return Task.FromResult(Result.Ok(Response.From(category)));
    }
}