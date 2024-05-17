namespace Okane.Application.Expenses;

public interface IExpenseResponse
{
}

public class ExpenseResponse : IExpenseResponse {
    public int Id {get; set;}
    public int Amount { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
}

