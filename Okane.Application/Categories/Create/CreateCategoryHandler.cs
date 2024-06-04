using FluentResults;
using MediatR;
using Okane.Application.Results;

namespace Okane.Application.Categories.Create;

public class CreateCategoryHandler 
    : IRequestHandler<Request, Result<Response>>
{
    private readonly ICategoriesRepository _categories;

    public CreateCategoryHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var nameExists = _categories.NameExists(request.Name);

        if (nameExists)
            return Task.FromResult(Result.Fail<Response>(
                new ConflictError($"Category with Name '{request.Name}' already exists.")));
        
        var category = request.ToCategory();

        _categories.Add(category);
        
        return Task.FromResult(Result.Ok(Response.From(category)));
    }
}