using MediatR;
using Okane.Application.Responses;

namespace Okane.Application.Categories.Delete;

public class DeleteCategoryHandler 
    : IRequestHandler<DeleteCategoryRequest, IDeleteCategoryResponse>
{
    private readonly ICategoriesRepository _categories;

    public DeleteCategoryHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public Task<IDeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = _categories.ById(request.Id);

        if (category == null)
            return Task.FromResult<IDeleteCategoryResponse>(new NotFoundResponse());
        
        _categories.Delete(category);
        return Task.FromResult<IDeleteCategoryResponse>(CategoryResponse.From(category));
    }
}