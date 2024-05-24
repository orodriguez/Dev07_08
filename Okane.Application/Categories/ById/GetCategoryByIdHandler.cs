using MediatR;
using Okane.Application.Responses;

namespace Okane.Application.Categories.ById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, IGetCategoryByIdResponse>
{
    private readonly ICategoriesRepository _categories;

    public GetCategoryByIdHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public Task<IGetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var category = _categories.ById(request.Id);

        if (category == null)
            return Task.FromResult<IGetCategoryByIdResponse>(new NotFoundResponse());
        
        return Task.FromResult<IGetCategoryByIdResponse>(CategoryResponse.From(category));
    }
}