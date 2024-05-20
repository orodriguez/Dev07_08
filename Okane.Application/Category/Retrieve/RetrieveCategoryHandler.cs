namespace Okane.Application.Category.Retrieve;

// Done
public class RetrieveCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    
    
    public RetrieveCategoryHandler(ICategoryRepository categoryRepository) => 
        _categoryRepository = categoryRepository;
    
    public IEnumerable<CategorySuccessResponse> Handle() =>
        _categoryRepository
            .All()
            .Select(category => category.ToCategoryResponse());
    
}