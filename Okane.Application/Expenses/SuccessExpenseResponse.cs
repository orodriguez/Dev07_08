namespace Okane.Application.Expenses;

public record SuccessExpenseResponse(int Id, 
    int Amount, 
    string CategoryName, 
    string? Description, DateTime CreatedAt) : IExpenseResponse;