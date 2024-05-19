using FluentValidation;

namespace Okane.Application.Category.Create;

public class CreateCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IValidator<CreateCategoryRequest> _validator;

    public CreateCategoryHandler(IValidator<CreateCategoryRequest> validator, ICategoryRepository categoryRepository)
    {
        _validator = validator;
        _categoryRepository = categoryRepository;
    }

    public ICategoryResponse Handle(CreateCategoryRequest createCategoryRequest)
    {
        var validation = _validator.Validate(createCategoryRequest);

        if (!validation.IsValid)
            return (ICategoryResponse)ValidationErrorsResponse.From(validation);

        var category = createCategoryRequest.ToCategory();
        var addedCategory = _categoryRepository.Add(category);

        return CategorySuccessResponse.From(addedCategory);
    }
}