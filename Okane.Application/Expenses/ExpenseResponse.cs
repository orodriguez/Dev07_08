using Okane.Application.Expenses.Create;
using Okane.Application.Responses;

namespace Okane.Application.Expenses;

public record ExpenseResponse(int Id, 
    int Amount, 
    string CategoryName, 
    string? Description, 
    DateTime CreatedAt,
    int UserId) : ISuccessResponse, ICreateExpenseResponse;