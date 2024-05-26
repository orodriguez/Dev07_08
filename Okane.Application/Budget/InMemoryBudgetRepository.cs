namespace Okane.Application.Budget;

public class InMemoryBudgetRepository : IBudgetRepository
{
    private readonly IList<Domain.Budget> _budget;

    public InMemoryBudgetRepository() =>
        _budget = new List<Domain.Budget>();

    public void Add(Domain.Budget budget)
    {
        _budget.Add(budget);
    }

    public Domain.Budget? GetByCategoryId(int categoryId) =>
        _budget.FirstOrDefault(b => b.CategoryId == categoryId);

    public IEnumerable<Domain.Budget> All()
    {
        throw new NotImplementedException();
    }
}