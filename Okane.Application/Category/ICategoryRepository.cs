namespace Okane.Application.Category;
    // Check
public interface ICategoryRepository 
{
    Domain.Category Add(Domain.Category category);
    IEnumerable<Domain.Category> All();
    Domain.Category? ById(int id);
}