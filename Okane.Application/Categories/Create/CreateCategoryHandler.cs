using FluentValidation;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;

namespace Okane.Application.Categories.Create;

public class CreateCategoryHandler
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CreateCategoryHandler(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public IResponse Handle(CreateCategoryRequest createCategoryRequest)
    {
        var category = createCategoryRequest.ToCategory();

        _categoriesRepository.Add(category);

        return category.ToResults();
    }
}