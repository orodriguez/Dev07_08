namespace Okane.Application.Budget.Create;

public class CreateBudgetRequest(int categoryId, int Maximum)
{
    public Domain.Budget ToBudget() =>
        new() { CategoryId = categoryId, Maximum = Maximum };
}