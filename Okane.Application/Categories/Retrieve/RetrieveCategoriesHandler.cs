namespace Okane.Application.Categories.Retrieve;

public class RetrieveCategoriesHandler
{
    private readonly ICategoriesRepository _categoriesRepository;

    public RetrieveCategoriesHandler(ICategoriesRepository categoriesRepository) =>
        _categoriesRepository = categoriesRepository;

    public IEnumerable<CategoryResponse> Handle() =>
        _categoriesRepository
            .All()
            .Select(category => category.ToResults());
}