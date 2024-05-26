namespace Okane.Application.Budget;

public interface IBudgetRepository
{
    void Add(Domain.Budget budget);
    Domain.Budget? GetByCategoryId(int categoryId);
}