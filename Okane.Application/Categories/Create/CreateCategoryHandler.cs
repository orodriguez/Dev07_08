using FluentValidation;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;

namespace Okane.Application.Categories.Create;

public class CreateCategoryHandler
{
    // private readonly IValidator<CreateCategoryRequest> _validator;
    private readonly ICategoriesRepository _categoriesRepository;

    public CreateCategoryHandler(
        ICategoriesRepository categoriesRepository)
    {
        // _validator = validator;
        _categoriesRepository = categoriesRepository;
    }

    public IResponse Handle(CreateCategoryRequest createCategoryRequest)
    {
        // var validation = _validator.Validate(createCategoryRequest);
        //
        // if (!validation.IsValid)
        //     return ValidationErrorsResponse.From(validation);

        var category = createCategoryRequest.ToCategory();

        _categoriesRepository.Add(category);

        return category.ToResults();
    }
}