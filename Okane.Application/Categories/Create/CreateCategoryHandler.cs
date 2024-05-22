using Okane.Application.Responses;

namespace Okane.Application.Categories.Create;

public class CreateCategoryHandler
{
    private readonly ICategoriesRepository _categories;

    public CreateCategoryHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public ICreateCategoryResponse Handle(CreateCategoryRequest request)
    {
        var nameExists = _categories.NameExists(request.Name);

        if (request.Name.Length > 100)
        {
            return new ConflictResponse($"Category with Name '{request.Name}' cannot have more than 100 characters.");
        }
        if (nameExists)
            return new ConflictResponse($"Category with Name '{request.Name}' already exists.");
        
        var category = request.ToCategory();

        _categories.Add(category);
        
        return CategoryResponse.From(category);
    }
}