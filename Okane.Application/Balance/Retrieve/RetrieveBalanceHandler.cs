using Okane.Application.Budget;
using Okane.Application.Categories;
using Okane.Application.Expenses;

namespace Okane.Application.Balance.Retrieve;

public class RetrieveBalanceHandler
{
    private readonly IBudgetRepository _budgetRepository;
    private readonly IReadOnlyExpensesRepository _expensesRepository;
    private readonly ICategoriesRepository _categoriesRepository;

    public RetrieveBalanceHandler(
        IBudgetRepository budgetRepository,
        IReadOnlyExpensesRepository expensesRepository,
        ICategoriesRepository categoriesRepository)
    {
        _budgetRepository = budgetRepository;
        _expensesRepository = expensesRepository;
        _categoriesRepository = categoriesRepository;
    }

    public IEnumerable<BalanceResponse> Handle(DateTime fromDate, DateTime toDate)
    {
        var budgets = _budgetRepository.All();
        var expenses = _expensesRepository.BetweenDates(fromDate, toDate);

        return budgets.Select(budget =>
        {
            var category = _categoriesRepository.ById(budget.CategoryId);
            var expended = expenses
                .Where(e => e.CategoryId == budget.CategoryId)
                .Sum(e => e.Amount);

            return BalanceResponse.From(budget, category, expended);
        });
    }
}