namespace Okane.Application.Categories.Create;

public class CreateCategoryHandler
{
    private readonly ICategoriesRepository _categories;

    public CreateCategoryHandler(ICategoriesRepository categories) => 
        _categories = categories;

    public ICreateCategoryResponse Handle(CreateCategoryRequest request)
    {
        var category = request.ToCategory();
        
        _categories.Add(category);
        
        return CategoryResponse.From(category);
    }
}