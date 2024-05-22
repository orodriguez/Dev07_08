using FluentValidation;
using Okane.Application.Responses;

namespace Okane.Application.Categories.Create;

public class CreateCategoryHandler
{
    private readonly IValidator<CreateCategoryRequest> _validator;
    private readonly ICategoriesRepository _categories;


    public CreateCategoryHandler(IValidator<CreateCategoryRequest> validator, ICategoriesRepository categories)
    {
        _categories = categories;
        _validator = validator;
    }

    public ICreateCategoryResponse Handle(CreateCategoryRequest request)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return (ValidationErrorsResponse.From(validation) as ICreateCategoryResponse)!;
        var category = request.ToCategory();
        if (_categories.NameExists(category.Name))
            return new ConflictResponse($"Category with Name '{request.Name}' already exists.");
        _categories.Add(category);
        return CategoryResponse.From(category);
    }
}