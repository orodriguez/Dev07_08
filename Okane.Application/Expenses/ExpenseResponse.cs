using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Delete;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;

namespace Okane.Application.Expenses;

public record ExpenseResponse(int Id, 
    int Amount, 
    string CategoryName, 
    string? Description, DateTime CreatedAt) 
    : ISuccessResponse, 
        ICreateExpenseResponse,
        IGetExpenseByIdResponse,
        IUpdateExpenseResponse, IDeleteExpenseResponse;