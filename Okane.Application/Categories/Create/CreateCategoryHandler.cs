using MediatR;
using Okane.Application.Responses;

namespace Okane.Application.Categories.Create;

public class CreateCategoryHandler 
    : IRequestHandler<CreateCategoryRequest, ICreateCategoryResponse>
{
    private readonly ICategoriesRepository _categories;

    public CreateCategoryHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public Task<ICreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var nameExists = _categories.NameExists(request.Name);

        if (nameExists)
            return Task.FromResult<ICreateCategoryResponse>(new ConflictResponse($"Category with Name '{request.Name}' already exists."));
        
        var category = request.ToCategory();

        _categories.Add(category);
        
        return Task.FromResult<ICreateCategoryResponse>(CategoryResponse.From(category));
    }
}