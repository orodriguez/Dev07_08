namespace Okane.Application.Budget.Create;

public record CreateBudgetRequest(int CategoryId, int Maximum)
{
    public Domain.Budget ToBudget() =>
        new() { CategoryId = CategoryId, Maximum = Maximum };
}